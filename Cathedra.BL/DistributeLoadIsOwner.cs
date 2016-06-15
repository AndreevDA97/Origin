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
            var loadIsOwner = _repository.GetTableLoadInCoursePlan().Where(x => x.SortLoad.Algorithm == 1);

            return DistributeLoad(loadIsOwner, true);
        }

        public IEnumerable<LoadInCourseFact> DistributeLoad(IEnumerable<LoadInCoursePlan> loadIsOwner, bool saveData)
        {
            var loadInCourseFact = new List<LoadInCourseFact>();

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
                        if(saveData)
                            _repository.AddLoadInCourseFact(lf);
                    }
                }
            }
            return loadInCourseFact;
        }
    }
}
