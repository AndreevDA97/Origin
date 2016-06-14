using Cathedra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cathedra.BL
{
    public class EmployeeLinkType
    {
        private CathedraDBDataContext _db;
        private Employee _emp;
        private LoadInCoursePlan _lilcp;
        private decimal _sum;

        public EmployeeLinkType(Employee emp, CathedraDBDataContext db, LoadInCoursePlan lilcp, decimal sum)
        {
            _emp = emp;
            _db = db;
            _lilcp = lilcp;
            _sum = sum;
        }

        public decimal PerStudent
        {
            get
            {
                _sum = 0;
                var coll = _db.LoadInCoursePlan
                    .Where(x => x.CourseInWork.GroupInCourse.First().GroupInSemestr
                        == _lilcp.CourseInWork.GroupInCourse.First().GroupInSemestr) //дороботать
                    .Where(x => x.SortLoad.SortLoadLink.Single().SortLoadLinkTypeID == _lilcp.SortLoad.SortLoadLink.Single().SortLoadLinkTypeID);
                foreach (var item in coll)
                {
                    _sum += (decimal)item.SortLoad.PerStudent;
                }
                return _sum;
            }
        }

        public Employee Employee
        {
            get
            {
                return _emp;
            }
        }

        public string Name
        {
            get
            {
                return _lilcp.SortLoad.SortLoadLink.Single().SortLoadLinkType.Name;
            }
        }

        public string Groups
        {
            get
            {
                return _lilcp.CourseInWork.GroupInCourse.Select(x => x.GroupInSemestr.Group.Group1)
                    .Aggregate((x, acc) => acc = x + ", " + acc);
            }
        }

        public int CountStudents
        {
            get
            {
                return (int)(_emp.LoadInCourseFact.Where(x => x.LoadInCoursePlanID == _lilcp.Id)
                    .Select(x => x.CountHours / x.LoadInCoursePlan.SortLoad.PerStudent).FirstOrDefault() ?? 0);
            }
        }

        public int TotalStudent
        {
            get
            {
                return GetTotalLoad(_lilcp);
            }
        }

        public int UnallocatedStudent
        {
            get
            {
                return GetNoDistributionlLoad(_lilcp);
            }
        }

        public void AddStudent()
        {
            var coll = _db.LoadInCoursePlan
                    .Where(x => x.CourseInWork.GroupInCourse.First().GroupInSemestr
                        == _lilcp.CourseInWork.GroupInCourse.First().GroupInSemestr) //дороботать
                    .Where(x => x.SortLoad.SortLoadLink.Single().SortLoadLinkTypeID == _lilcp.SortLoad.SortLoadLink.Single().SortLoadLinkTypeID);
            foreach (var item in coll)
            {
                var z = (item.LoadInCourseFact.Where(x => x.LoadInCoursePlan.Id == item.Id && _emp.Id == x.EmployeeID));
                if (z.Count() != 0)
                {
                    z.Single().CountHours += (decimal)item.SortLoad.PerStudent;
                }
                else
                {
                    _db.LoadInCourseFact.InsertOnSubmit(new LoadInCourseFact()
                    {
                        Employee = _emp,
                        CountHours = (decimal)item.SortLoad.PerStudent,
                        LoadInCoursePlan = item,
                        Approved = true
                    });
                }
                _db.SubmitChanges();
            }
        }

        public void DeleteStudent()
        {
            var coll = _db.LoadInCoursePlan
                    .Where(x => x.CourseInWork.GroupInCourse.First().GroupInSemestr
                        == _lilcp.CourseInWork.GroupInCourse.First().GroupInSemestr) //дороботать
                    .Where(x => x.SortLoad.SortLoadLink.Single().SortLoadLinkTypeID == _lilcp.SortLoad.SortLoadLink.Single().SortLoadLinkTypeID);
            foreach (var item in coll)
            {
                var z = item.LoadInCourseFact.Where(x => x.LoadInCoursePlan.Id == item.Id && _emp.Id == x.EmployeeID);
                if (z.Count() != 0)
                {
                    z.Single().CountHours -= (decimal)item.SortLoad.PerStudent;
                    if (z.Single().CountHours == 0)
                    {
                        _db.LoadInCourseFact.DeleteOnSubmit(z.Single());
                    }
                }
            }
            _db.SubmitChanges();
        }

        int GetTotalLoad(LoadInCoursePlan sllt)
        {
            return ((int)(sllt.CountHours / sllt.SortLoad.PerStudent));
        }

        int GetNoDistributionlLoad(LoadInCoursePlan sllt)
        {
            var s = from sllts in _db.SortLoadLinkType
                    join sll in _db.SortLoadLink on sllts.Id equals sll.SortLoadLinkTypeID
                    join sl in _db.SortLoad on sll.SortLoadID equals sl.Id
                    join lp in _db.LoadInCoursePlan on sl.Id equals lp.SortLoadID
                    join work in _db.CourseInWork on lp.CourseInWorkID equals work.ID
                    join fact in _db.LoadInCourseFact on lp.Id equals fact.LoadInCoursePlanID
                    where lp.Id == sllt.Id
                    select new
                    {
                        count = fact.CountHours / sl.PerStudent,
                    };
            var ss = (int)(s.Sum(x => x.count) ?? 0);
            return (GetTotalLoad(sllt) - ss);
        }
    }
}
