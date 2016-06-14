using Cathedra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cathedra.BL
{
    public class EmployeeExtended
    {
        Employee _emp;
        CathedraDBDataContext _db;
        Repository _rep;
        List<EmployeeLinkType> _elt;

        public string Fio
        {
            get
            {
                return _emp.ShortName;
            }
        }

        public decimal Total
        {
            get
            {
                return _rep.GetEmployeeRateInYear(_emp);
            }
        }

        public decimal Secure
        {
            get
            {
                return _rep.GetSecureCountHourseEmployee(_emp);
            }
        }

        public decimal Free
        {
            get
            {
                return Total - Secure;
            }
        }

        public List<EmployeeLinkType> Elt
        {
            get
            {
                return _elt;
            }
        }

        

        public EmployeeExtended(Employee emp, CathedraDBDataContext db, Repository rep)
        {
            _emp = emp;
            _db = db;
            _rep = rep;
            _elt = new List<EmployeeLinkType>();
            foreach (var item in db.SortLoadLinkType.OrderBy(x => x.Id))
            {
                var collection = item.SortLoadLink.First().SortLoad.LoadInCoursePlan;
                var sum = (decimal)item.SortLoadLink.Sum(x => x.SortLoad.PerStudent);
                foreach (var licp in collection)
                {
                    _elt.Add(new EmployeeLinkType(emp, db, licp, sum));
                }
            }
        }
    }
}
