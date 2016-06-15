using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cathedra.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cathedra.BL.Tests
{
    [TestClass()]
    public class DistributeLoadIsExercisesAndExchangeTests
    {
        [TestMethod()]
        public void DistributeLoadTest()
        {
            var repository = new Data.Repository(new Data.CathedraDBDataContext());
            var plan = repository.GetTableLoadInCoursePlan().Where(x => x.SortLoad.Algorithm == 4);
            var planSumHourse = plan.Sum(x => x.CountHours);
            var classTest = new DistributeLoadIsExercisesAndExchange(repository);
            var saveData = false;

            var result = classTest.DistributeLoad(plan, saveData);
            var resultSumHourse = result.Sum(x => x.CountHours);

            Assert.AreEqual(resultSumHourse, planSumHourse);
        }
    }
}