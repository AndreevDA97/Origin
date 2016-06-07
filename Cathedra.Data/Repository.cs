using Cathedra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cathedra.Data
{
    public class Repository
    {
        CathedraDBDataContext _db;
        int _schoolYear = Properties.Settings.Default.SchollYearID;

        public Repository(CathedraDBDataContext db)
        {
            _db = db;
        }

        public IEnumerable<LoadInCoursePlan> GetTableLoadInCoursePlan()
        {
            var d = _db.LoadInCourseFact;
            return _db.LoadInCoursePlan.Where(x => x.CourseInWork.SchoolYearID == _schoolYear);
        }

        public void AddLoadInCourseFact(LoadInCourseFact fact)
        {
            _db.LoadInCourseFact.InsertOnSubmit(fact);
            _db.SubmitChanges();
        }

        public IEnumerable<Employee> GetActiveEmployee()
        {
            return _db.LoadInCourseFact.GroupBy(x => x.Employee).Select(x => x.Key);//.Where(x => !x.NonActive);
        }

        public IEnumerable<Employee> GetEmployeeLowLoad()
        {
            return _db.Employee.Where(x => x.IsUnderload).OrderBy(x => x.Underload);
        }

        public void SubmitChanges()
        {
            _db.SubmitChanges();
        }

        public bool CheckFreeHourse(Employee emp, decimal load)
        {
            decimal empRate = GetEmployeeRateInYear(emp);
            decimal secureLoad = GetSecureCountHourseEmployee(emp);
            return (empRate + empRate * Properties.Settings.Default.LoadPercent/100) - (secureLoad + load) > 0;
        }

        public decimal GetEmployeeRateInYear(Employee employee)
        {
            var em = _db.Employee.Where(x => x.Id == employee.Id).Single();
            var rate = em.Rate.Where(x => x.SchoolYearID == _schoolYear).Single().Rate1;
            var rateInHouse = em.Post.PostSalary.Where(x => x.SchoolYearID == _schoolYear).Single().RateInHours;
            return (decimal)(rate * rateInHouse);
        }

        public decimal GetSecureCountHourseEmployee(Employee employee)
        {
            var d = _db.LoadInCourseFact
                .Where(x => x.EmployeeID == employee.Id && x.LoadInCoursePlan.CourseInWork.SchoolYearID == _schoolYear
                && (x.Approved == true || x.Approved == null));
            return d.Count() == 0 ? 0 : d.Sum(x => x.CountHours);
        }
    }

    partial class Semestr
    {
        public override string ToString()
        {
            return this.Name;
        }
    }

    partial class LoadInCoursePlan
    {
        public Employee OwnerIsCourse
        {
            get
            {
                return this.CourseInWork.Employee;
            }
        }
    }

    partial class CourseInWork
    {
        /// <summary>
        /// Общее количество запланированных часов
        /// </summary>
		public decimal TotalPlanHours
        {
            get
            {
                decimal totalCountHours = 0;
                foreach (LoadInCoursePlan loadPlan in this.LoadInCoursePlan)
                {
                    totalCountHours += loadPlan.CountHours;
                }
                return totalCountHours;
            }
        }

        /// <summary>
        /// Общее количество распределенных часов
        /// </summary>
        public decimal TotalDistributeHours
        {
            get
            {
                decimal totalCountHours = 0;

                foreach (LoadInCoursePlan loadPlan in this.LoadInCoursePlan)
                {
                    foreach (LoadInCourseFact loadFact in loadPlan.LoadInCourseFact)
                    {
                        totalCountHours += loadFact.CountHours;
                    }
                }
                return totalCountHours;
            }
        }

        /// <summary>
        /// Метод, возвращающий количество часов распределенных по указанному
        /// виду нагрузки
        /// </summary>
        /// <param name="sortLoadId">Вид нагрузки</param>
        /// <returns>Количество часов</returns>
        public decimal DistributedHoursOnLoad(int sortLoadId)
        {
            decimal distributedHours = 0;

            foreach (LoadInCoursePlan loadPlan in this.LoadInCoursePlan)
            {
                if (loadPlan.SortLoadID == sortLoadId)
                {
                    foreach (LoadInCourseFact loadFact in loadPlan.LoadInCourseFact)
                    {
                        distributedHours += loadFact.CountHours;
                    }
                }
            }
            return distributedHours;
        }

        /// <summary>
        /// Возвращает группы, назначенные на курс
        /// </summary>
        public string Groups
        {
            get
            {
                string rs = string.Empty;
                foreach (GroupInCourse groupInCourse in this.GroupInCourse)
                {
                    if (!String.IsNullOrEmpty(rs))
                        rs += ", ";
                    rs += groupInCourse.GroupInSemestr.Group.Group1;
                }
                return rs;
            }
        }

        public string SemestrString
        {
            get
            {
                return this.Semestr1?.Name ?? "";
            }
        }

        /// <summary>
        /// Свойство, возвращающее true - если лабораторные работы нужно делить
        /// или false - если не нужно
        /// </summary>
        public bool IsDivisionLab
        {
            get
            {
                bool isDivision = false;


                int countStudents = 0;

                foreach (var gic in GroupInCourse)
                {
                    countStudents += (int)(gic.GroupInSemestr.QuantityStudent ?? 0);
                }

                if (countStudents > 15)
                {
                    isDivision = true;
                }

                return isDivision;
            }
        }
    }

    partial class LoadInCourseFact
    {
        public string CourseName
        {
            get
            {
                return this.LoadInCoursePlan.CourseInWork.Course.Name;
            }
        }

        public string CourseSemestr
        {
            get
            {
                return this.LoadInCoursePlan.CourseInWork.SemestrString;
            }
        }

        public string Groups
        {
            get
            {
                if (GroupInCourseID != null)
                {
                    return this.GroupInCourse.GroupInSemestr.GroupName;
                }
                else
                {
                    return this.LoadInCoursePlan.CourseInWork.Groups;
                }
            }
        }

        ///// <summary>
        ///// Нагрузка в часах
        ///// </summary>
        //public string WorkLoad
        //{
        //    get
        //    {
        //        return "Нагрузка";
        //    }
        //}

        public string SortLoadName
        {
            get
            {
                return this.LoadInCoursePlan.SortLoad.Name;
            }
        }

        public string ClassRoomNumber
        {
            get
            {
                if (this.ClassRoom != null)
                {
                    return this.ClassRoom.Number;
                }
                else
                {
                    return "";
                }

            }
        }

        public string EmployeeFio
        {
            get { return Employee.ShortName; }
        }
    }

    partial class Employee
    {
        private List<LoadLab> _listLoadLab;

        public string ShortName
        {
            get { return this.ToString(); }
        }

        public override string ToString()
        {
            string[] _fio = this.Fio.Split(' ');
            string _f = "", _i = "", _o = "";
            if (_fio.Length >= 1) _f = _fio[0];
            if (_fio.Length >= 2) _i = _fio[1][0] + ".";
            if (_fio.Length >= 3) _o = _fio[2][0] + ".";

            return string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0} {1} {2}{3}",
                this.Post.ShortName,
                _f, _i, _o);
        }

        /// <summary>
        /// Фактическая нагрузка в часах
        /// </summary>
        public decimal WorkLoad
        {
            get
            {
                decimal workloadFrom = 0;
                int schoolYearId = Properties.Settings.Default.SchollYearID;
                foreach (LoadInCourseFact loadFact in this.LoadInCourseFact)
                {
                    if (loadFact.LoadInCoursePlan.CourseInWork != null)
                    {
                        if (loadFact.LoadInCoursePlan.CourseInWork.SchoolYearID == schoolYearId)
                        {
                            workloadFrom += loadFact.CountHours;
                        }
                    }
                }
                return workloadFrom;
            }
        }

        /// <summary>
        /// Количество часов по ставке
        /// </summary>
        public decimal RateInHours
        {
            get
            {
                int schoolYearId = Properties.Settings.Default.SchollYearID;
                decimal? rateInHours = this.Rate.SingleOrDefault(x => x.SchoolYearID == schoolYearId).Post.PostSalary.SingleOrDefault(x => x.SchoolYearID == schoolYearId).RateInHours;
                if (rateInHours == null) rateInHours = 0;
                return Math.Round(this.RateForm * (decimal)rateInHours, 3);
            }
        }

        /// <summary>
        /// Ставка по нагрузке
        /// </summary>
        public decimal RateForm
        {
            get
            {
                decimal rateForm = 0;
                int schoolYearId = Properties.Settings.Default.SchollYearID;

                rateForm = this.Rate.SingleOrDefault(x => x.SchoolYearID == schoolYearId)?.Rate1 ?? 0;

                return rateForm;
            }
        }

        public bool IsOverload
        {
            get
            {
                decimal rateFormByHours = WorkLoad;
                decimal highBound = RateForm + RateForm * Properties.Settings.Default.LoadPercent / 100m;
                return (rateFormByHours > highBound);
            }

        }

        public bool IsUnderload
        {
            get
            {
                decimal rateFormByHours = WorkLoad;
                decimal lowBound = RateForm - RateForm * Properties.Settings.Default.LoadPercent / 100m;
                return (rateFormByHours < lowBound);
            }
        }

        public decimal Overload
        {
            get
            {
                int schoolYearId = Properties.Settings.Default.SchollYearID;
                decimal overload = this.WorkLoad - this.RateInHours;
                if (overload > 0)
                    return overload;
                else
                    return 0;
            }
        }

        public decimal Underload
        {
            get
            {
                decimal underload = this.RateInHours - this.WorkLoad;
                if (underload > 0)
                    return underload;
                else
                    return 0;
            }
        }

        public bool CheckFreeHourse(decimal HourseLoad)
        {
            return (RateInHours + RateInHours * Properties.Settings.Default.LoadPercent) - (WorkLoad + HourseLoad) > 0;
        }

        public string GetEmployeeInfo(SchoolYear sy)
        {
            string returnString = "";

            returnString += "=======================================================================\r\n";
            returnString += "Данные по состоянию на " + DateTime.Now.ToString("dd MMM yyyy HH:mm:ss") + "\r\n";
            returnString += "=======================================================================\r\n";
            returnString += ("ФИО: ").PadRight(40) + Fio + "\r\n";
            returnString += ("Должность: ").PadRight(40) + Post.Name + "\r\n";
            returnString += ("Учебный год: ").PadRight(40) + sy.Years + "\r\n";
            returnString += ("Ставка по коммерческому набору: ").PadRight(40) + this.RateForm + "\r\n";
            returnString += ("Часов нагрузки согласно ставке:").PadRight(40) + this.RateInHours + "\r\n";
            returnString += "\r\n";

            #region Формальная нагрузка
            returnString += "============================================================\r\n";          

            var q = from licf in this.LoadInCourseFact
                    where licf.LoadInCoursePlan.CourseInWork.SchoolYearID == sy.ID
                    group licf by new { licf.LoadInCoursePlan.CourseInWorkID, licf.LoadInCoursePlan.CourseInWork }
                into grouping
                    orderby grouping.Key.CourseInWork.Semestr, grouping.Key.CourseInWorkID, grouping.Key.CourseInWork.Groups
                    select grouping;

            short semestr = 0;
            decimal itogoSemestr = 0;
            decimal itogo = 0;
            foreach (var course in q)
            {
                if (semestr != course.Key.CourseInWork.Semestr)
                {
                    if (semestr == 1)
                    {
                        returnString += ("Итого по семестру:").PadRight(40) + itogoSemestr + "\r\n";
                        itogoSemestr = 0;
                    }
                    semestr = (short)(course.Key.CourseInWork.Semestr ?? 2);
                    returnString += "\r\n" + course.Key.CourseInWork.Semestr1?.Name  + " семестр\r\n";
                }
                returnString += course.Key.CourseInWork.Course.Name + ", гр." + course.Key.CourseInWork.Groups + "\r\n";

                foreach (var item in course.Key.CourseInWork.LoadInCoursePlan)
                {
                    foreach (LoadInCourseFact licf in item.LoadInCourseFact.Where(p => p.EmployeeID == Id))
                    {
                        string addstr = "";
                        // Проверяем, кто является владельцем курса
                        if (licf.LoadInCoursePlan.CourseInWork.Employee != null && Id != licf.LoadInCoursePlan.CourseInWork.Employee.Id)
                            addstr += "(ответственный - " + licf.LoadInCoursePlan.CourseInWork.Employee.ShortName + ")";
                        returnString += String.Format("                    {0} - {1} {2}\r\n",
                            licf.LoadInCoursePlan.SortLoad.Name, licf.CountHours, addstr);

                        itogo += licf.CountHours;
                        itogoSemestr += licf.CountHours;
                    }
                }
            }
            returnString += ("Итого по семестру:").PadRight(40) + itogoSemestr + "\r\n";
            returnString += ("ИТОГО:").PadRight(40) + itogo + "\r\n\r\n";
            #endregion

            #region Фактическая нагрузка
            returnString += "============================================================\r\n";
            returnString += "Дополнительная информация:\r\n";

            var q2 = (from ciw in CourseInWork
                      where ciw.SchoolYearID == sy.ID
                      select ciw);

            foreach (CourseInWork ciw in q2)
            {
                foreach (var item in ciw.LoadInCoursePlan)
                {
                    foreach (LoadInCourseFact licf in item.LoadInCourseFact)
                    {
                        if (licf.EmployeeID != Id)
                            returnString += String.Format("   {0}, {1}, {2}, {3} - {4} закреплена за {5}\r\n",
                                ciw.Course.Name,
                                licf.SortLoadName,
                                licf.CourseSemestr,
                                licf.Groups,
                                licf.CountHours,
                                licf.EmployeeFio
                                );
                    }
                }
            }
            #endregion

            return returnString;
        }

        public int Mask
        {
            get
            {
                if(ListLoadLab != null)
                    return (int)(Math.Pow(2, ListLoadLab.Count()) - 1);
                return 0;
            }
        }

        public List<LoadLab> ListLoadLab
        {
            get
            {
                return _listLoadLab;
            }
        }

        public decimal SummHorseOnLab
        {
            get
            {
                return GetSumOnMask(Mask);
            }
        }

        public bool ListLoadLabInit()
        {
            var listLoad = new List<LoadLab>();

            var collection = this.LoadInCourseFact
                .Where(x => x.LoadInCoursePlan.SortLoad.Id == 7 && x.LoadInCoursePlan.CourseInWork.IsDivisionLab && x.LoadInCoursePlan.CourseInWork.EmployeeID == this.Id)
                .Select(x => new { PlanId = x.LoadInCoursePlanID, Hourse = x.CountHours });

            foreach (var item in collection)
            {
                listLoad.Add(new LoadLab((int)item.PlanId, item.Hourse));
            }
            listLoad = listLoad.OrderBy(x => x.CountHourse).ToList();

            _listLoadLab = listLoad;
            return listLoad.Count > 0;
        }

        public decimal GetSumOnMask(int mask)
        {
            decimal sum = 0;
            for (int i = 0; i < ListLoadLab.Count(); i++)
            {
                if ((((1 << i) & mask) != 0) && ListLoadLab[i].Bit)
                {
                    sum += ListLoadLab[i].CountHourse;
                }
            }
            return sum;
        }

        public List<LoadLab> GetLoadOnMask(int mask)
        {
            var load = new List<LoadLab>();

            for (int i = 0; i < ListLoadLab.Count(); i++)
            {
                if ((((1 << i) & mask) != 0) && ListLoadLab[i].Bit)
                {
                    load.Add(ListLoadLab[i]);
                }
            }
            return load;
        }

        public IEnumerable<LoadInCourseFact> AddLoadLab(List<LoadLab> list)
        {
            var loadInCourseFact = new List<LoadInCourseFact>();
            foreach (var item in list)
            {
                var lf = new LoadInCourseFact
                {
                    CountHours = item.CountHourse,
                    LoadInCoursePlanID = item.PlanID
                };
                this.LoadInCourseFact.Add(lf);
                loadInCourseFact.Add(lf);
            }
            return loadInCourseFact;
        }

        public void DeleteLoadOnMask(int mask)
        {
            for (int i = 0; i < ListLoadLab.Count(); i++)
            {
                if ((((1 << i) & mask) != 0) && ListLoadLab[i].Bit)
                {
                    ListLoadLab[i].Bit = false;
                }
            }
            ListLoadLab.RemoveAll(x => !x.Bit);
        }

        public Employee GetEmployeeWorkTogether(int priority)
        {
            var t = this.PreferencesEmployeeWorkTogether.Where(x => priority == x.Priority).SingleOrDefault();
            return t == null ? null : t.Employee1;
        }


    }

    public class LoadLab
    {
        private decimal _countHourse;
        private bool _bit = true;
        private int _planID;

        public decimal CountHourse
        {
            get
            {
                return _countHourse;
            }
        }

        public int PlanID
        {
            get
            {
                return _planID;
            }
        }

        public bool Bit
        {
            get
            {
                return _bit;
            }
            set
            {
                _bit = value;
            }
        }

        public LoadLab(int planID, decimal countHourse)
        {
            _countHourse = countHourse;
            _planID = planID;
        }
    }

    partial class SchoolYear
    {
        public override string ToString()
        {
            return string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0}", this.Years);
        }
    }

    partial class Course
    {

        public override string ToString()
        {
            return string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0}", this.Name);
        }
    }

    partial class Group
    {
        public override string ToString()
        {
            return this.Group1;
        }
    }

    partial class GroupInSemestr
    {
        public string GroupName
        {
            get
            {
                return this.Group.ToString();
            }
        }
    }

    partial class SortLoad
    {
        public string ShortName
        {
            get
            {
                if (Id == 1) return "лекции";
                else if (Id == 7) return "лаб.раб.";
                else if (Id == 6) return "упр.";
                else return Name;
            }
        }
    }
}
