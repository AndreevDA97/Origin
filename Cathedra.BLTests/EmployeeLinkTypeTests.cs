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
    public class EmployeeLinkTypeTests
    {
        Data.CathedraDBDataContext db;
        private LoadInCoursePlan plan;
        private EmployeeLinkType classTest;
        private bool saveData;

        [TestInitialize()]
        public void Initialize()
        {
            db = new Data.CathedraDBDataContext();
            plan = db.LoadInCoursePlan.Single(x => x.Id == 5460);
            classTest = new EmployeeLinkType(db.Employee.First(), db, plan, 0);
            saveData = false;
        }

        [TestMethod()]
        public void AddStudentTest()
        {
            var result = classTest.AddStudent(saveData);

            Assert.AreEqual(result, 15);
        }

        [TestMethod()]
        public void DeleteStudentTest()
        {
            var result = classTest.DeleteStudent(saveData);

            Assert.AreEqual(result, 0);
        }
    }
}