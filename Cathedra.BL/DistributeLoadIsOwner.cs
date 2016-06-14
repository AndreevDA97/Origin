using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cathedra.Data;

namespace Cathedra.BL
{
    public class DistributeLoadIsOwner
    {
        Repository _repository;

        public DistributeLoadIsOwner(Repository repository)
        {
            _repository = repository;
        }

        public IEnumerable<LoadInCourseFact> DistributeLoad()
        {
            var loadInCourseFact = new List<LoadInCourseFact>();
            var loadIsOwner = _repository.GetTableLoadInCoursePlan().Where(x => x.SortLoad.Algorithm == 1);

            foreach (var load in loadIsOwner)
            {
                var emp = load.OwnerIsCourse;
                if (emp != null)
                {
                    if (!emp.NonActive && emp.CheckFreeHourse(load.CountHours))
                    {
                        var lf = new LoadInCourseFact()
                        {
                            CountHours = load.CountHours,
                            LoadInCoursePlanID = load.Id,
                            EmployeeID = emp.Id,
                            Approved = true
                        };
                        loadInCourseFact.Add(lf);
                        _repository.AddLoadInCourseFact(lf);
                    }
                }
            }
            return loadInCourseFact;
        }
    }
}
