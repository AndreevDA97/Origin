using Cathedra.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cathedra
{
    public partial class FormReportEmployee : Form
    {
        CathedraDBDataContext _db;

        public FormReportEmployee(CathedraDBDataContext db)
        {
            InitializeComponent();
            _db = db;
            employeeBindingSource.DataSource = _db.Employee.Where(x => !x.NonActive);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var q = from emp in _db.Employee
                    where !emp.NonActive
                    select emp;
            string alldata = "";

            var sy = (from schoolYear in _db.SchoolYear
                      where schoolYear.ID == 8
                      select schoolYear).FirstOrDefault();

            foreach (Employee employee in q)
            {
                alldata += employee.GetEmployeeInfo(sy) + "\r\n";
            }
            File.WriteAllText("Employee.txt", alldata, Encoding.GetEncoding(1251));
            MessageBox.Show(@"Сформирован файл Employee.txt в текущем каталоге", @"Результаты", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var employee = (Employee)employeeBindingSource.Current;
            var sy = (from s in _db.SchoolYear
                      where s.ID == Repository.GetSchollYearID()
                      select s).FirstOrDefault();
            var form = new FormViewLoadEmployee(employee.GetEmployeeInfo(sy));
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
