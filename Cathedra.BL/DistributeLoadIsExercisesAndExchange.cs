using Cathedra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cathedra.BL
{
    public class DistributeLoadIsExercisesAndExchange
    {
        Repository _repository;

        public DistributeLoadIsExercisesAndExchange(Repository repository)
        {
            _repository = repository;
        }

        public IEnumerable<LoadInCourseFact> DistributeLoad()
        {
            var load = _repository.GetTableLoadInCoursePlan().Where(x => x.SortLoad.Algorithm == 4);

            return DistributeLoad(load, true);
        }

        public IEnumerable<LoadInCourseFact> DistributeLoad(IEnumerable<LoadInCoursePlan> load, bool saveData)
        {
            var loadInCourseFact = new List<LoadInCourseFact>();

            foreach (var l in load)
            {
                Employee empOwner = l.OwnerIsCourse;
                Employee emp = empOwner;
                int priority = 0;
                if (empOwner != null)
                {
                    do
                    {
                        if (!emp.NonActive && _repository.CheckFreeHourse(emp, l.CountHours))
                        {
                            var lf = new LoadInCourseFact()
                            {
                                CountHours = l.CountHours,
                                LoadInCoursePlanID = l.Id,
                                EmployeeID = emp.Id,
                                Approved = null
                            };
                            loadInCourseFact.Add(lf);
                            if (saveData)
                                _repository.AddLoadInCourseFact(lf);
                            priority = 0;
                        }
                        else
                        {
                            emp = empOwner.GetEmployeeWorkTogether(++priority)
                                ?? _repository.GetEmployeeLowLoad()?.LastOrDefault() ?? empOwner;
                        }
                    } while (priority != 0);
                }
            }
            return loadInCourseFact;
        }
    }
}
