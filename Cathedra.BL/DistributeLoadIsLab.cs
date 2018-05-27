using Cathedra.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cathedra.BL
{
    public class DistributeLoadIsLab
    {
        Repository _repository;
        int _maxDelta;

        public DistributeLoadIsLab(Repository repository, int maxDelta)
        {
            _repository = repository;
            _maxDelta = maxDelta;
        }

        public IEnumerable<LoadInCourseFact> DistributeLoad()
        {
            var loadLab = _repository.GetTableLoadInCoursePlan().Where(x => x.SortLoad.Algorithm == 2);
            return DistributeLoad(loadLab, true);
        }

        public IEnumerable<LoadInCourseFact> DistributeLoad(IEnumerable<LoadInCoursePlan> loadLab, bool saveData)
        {
            var lf = new List<LoadInCourseFact>();
            lf.AddRange(DistributeLoadIsOwner(loadLab, saveData));
            lf.AddRange(DistributeLoadSecondEmployee(saveData));
            return lf;
        }

        public IEnumerable<LoadInCourseFact> DistributeLoadIsOwner(IEnumerable<LoadInCoursePlan> loadLab, bool saveData)
        {
            var loadInCourseFact = new List<LoadInCourseFact>();

            foreach (var load in loadLab)
            {
                Employee emp = load.OwnerIsCourse;
                int countEmployee = load.CourseInWork.IsDivisionLab ? 2 : 1;
                if (emp != null)
                {
                    if (!emp.NonActive && emp.CheckFreeHourse(load.CountHours))
                    {
                        var lf = new LoadInCourseFact()
                        {
                            CountHours = load.CountHours / countEmployee,
                            LoadInCoursePlanID = load.Id,
                            EmployeeID = emp.Id,
                            Approved = null,
                            ClassRoomID = _repository.GetClassRoomIDAtPreviousYears(load)
                        };
                        loadInCourseFact.Add(lf);
                        _repository.AddLoadInCourseFact(lf);
                    }
                }
            }
            return loadInCourseFact;
        }

        public IEnumerable<LoadInCourseFact> DistributeLoadSecondEmployee(bool saveData)
        {
            var loadInCourseFact = new List<LoadInCourseFact>();
            _repository = new Repository(new CathedraDBDataContext());
            var emp = _repository.GetActiveEmployee();
            var lempLab = new List<Employee>();
            foreach (var item in emp)
            {
                if(item.ListLoadLabInit(_repository))
                {
                    lempLab.Add(item);
                }    
            }
            var str = "";
            lempLab = lempLab.OrderByDescending(x => x.SummHorseOnLab).ToList();
            for (int d = 0; d < _maxDelta; d++)
            {
                for (int i = 0; i < lempLab.Count - 1; i++)
                {
                    int mask = lempLab[i].Mask;
                    while (mask > 0)
                    {
                        for (int j = 1; j < lempLab.Count; j++)
                        {
                            var hourseEmpOwner = lempLab[i].GetSumOnMask(mask);
                            var hourseEmpSecond = lempLab[j].GetSumOnMask(lempLab[j].Mask);
                            if (i != j && lempLab[j].Mask != 0 && Math.Abs(hourseEmpOwner - hourseEmpSecond) <= d)
                            {
                                str += string.Format("{0} -> {1} : {2} ({3})\n{4} -> {5} : {6} ({7})\n\n",
                                    lempLab[i].Fio,
                                    lempLab[j].Fio,
                                    hourseEmpOwner,
                                    lempLab[i].ListLoadLab.Select(x => x.CountHourse.ToString()).Aggregate((x, y) => y = x + " , " + y),
                                    lempLab[j].Fio,
                                    lempLab[i].Fio,
                                    hourseEmpSecond,
                                    lempLab[j].ListLoadLab.Select(x => x.CountHourse.ToString()).Aggregate((x, y) => y = x + " , " + y));

                                loadInCourseFact.AddRange(lempLab[i].AddLoadLab(lempLab[j].GetLoadOnMask(lempLab[j].Mask)));
                                loadInCourseFact.AddRange(lempLab[j].AddLoadLab(lempLab[i].GetLoadOnMask(mask)));
                                lempLab[i].DeleteLoadOnMask(mask);
                                lempLab[j].DeleteLoadOnMask(lempLab[j].Mask);

                                mask = lempLab[i].Mask + 1;
                                break;
                            }
                        }
                        mask--;
                    }
                }
            }

            if (saveData)
                _repository.SubmitChanges();

            foreach (var item in lempLab.Where(x => x.Mask != 0))
            {
                str += string.Format("У {0}: {1} часов не распределено ({2})\n",
                    item.Fio,
                    item.GetSumOnMask(item.Mask),
                    item.ListLoadLab.Select(x => x.CountHourse.ToString()).Aggregate((x, y) => y = x + " , " + y));
            }

            File.WriteAllText("lab.txt", str);

            return loadInCourseFact;

        }
    }
}
