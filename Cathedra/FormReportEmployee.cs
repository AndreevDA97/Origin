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

        private void button4_Click(object sender, EventArgs e)
        {
            string returnString = "Фамилия".PadRight(30) + "|" +
                "Должность".PadRight(20) + "|" +
                "Ставка".PadRight(10) + "|" +
                "Часов по ставке".PadRight(15) + "|" +
                "Факт. нагрузка".PadRight(14) + "|" +
                "Перегрузка".PadRight(10) + "|" +
                "Недогрузка".PadRight(10) + "|" + Environment.NewLine;

            decimal workloadForm = 0;
            decimal overload = 0;
            decimal underload = 0;
            decimal workloadFact = 0;

            List<Employee> employeeList = (from emp in _db.Employee
                                           where emp.NonActive == false
                                           select emp).ToList();

            foreach (Employee eisy in employeeList)
            {
                if (eisy.RateInHours != 0 ||
                    eisy.Overload != 0 ||
                    eisy.Underload != 0)
                {
                    returnString += eisy.Fio.PadRight(30) + "|" +
                        eisy.Post.Name.PadRight(20) + "|" +
                        eisy.Rate.FirstOrDefault(x => x.SchoolYearID==8).Rate1.ToString().PadRight(10) + "|" +
                        eisy.RateInHours.ToString().PadLeft(15) + "|" +
                        eisy.WorkLoad.ToString().PadLeft(15) + "|" +
                        eisy.Overload.ToString().PadLeft(10) + "|" +
                        eisy.Underload.ToString().PadLeft(10) + "|" + Environment.NewLine;

                    workloadForm += eisy.RateInHours;
                    overload += eisy.Overload;
                    underload += eisy.Underload;
                    workloadFact += eisy.WorkLoad;
                }
            }
            returnString += "\n";
            returnString += "ИТОГО: ".PadRight(30) + "|" +
                    "".PadRight(20) + "|" +
                    "".PadRight(10) + "|" +
                    workloadForm.ToString().PadLeft(15) + "|" +
                    workloadFact.ToString().PadLeft(15) + "|" +
                    overload.ToString().PadLeft(10) + "|" +
                    underload.ToString().PadLeft(10) + "|" + Environment.NewLine;

            FormViewLoadEmployee foemEditor = new FormViewLoadEmployee(returnString);
            foemEditor.ShowDialog();
        }
    }
}
