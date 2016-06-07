using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cathedra.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cathedra.Data;

namespace Cathedra.BL.Tests
{
    [TestClass()]
    public class DistributeLoadIsOwnerTests
    {
        [TestMethod()]
        public void DistributeLoadTest()
        {
            var db = new CathedraDBDataContext();
            var rep = new Repository(db);

            var list = new List<LoadInCourseFact>();
            var ownerLoad = new DistributeLoadIsOwner(new Repository(new CathedraDBDataContext()));
            list.AddRange(ownerLoad.DistributeLoad());
            var labLoad = new DistributeLoadIsLab(new Repository(new CathedraDBDataContext()), 10);
            list.AddRange(labLoad.DistributeLoadIsOwner());
            list.AddRange(labLoad.DistributeLoadSecondEmployee());
            var exchange = new DistributeLoadIsExercisesAndExchange(new Repository(new CathedraDBDataContext()));
            list.AddRange(exchange.DistributeLoad());

            Assert.IsTrue(true);
        }
    }
}