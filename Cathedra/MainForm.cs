using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cathedra.BL;
using Cathedra.Data;
using System.IO;

namespace Cathedra
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            employeeBindingSource.DataSource = new CathedraDBDataContext().Employee.Where(x => !x.NonActive);
        }

        private void поВладельцамКурсовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Действительно распределить нагрузку?", "",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var ownerLoad = new DistributeLoadIsOwner(new Repository(new CathedraDBDataContext()));
                ownerLoad.DistributeLoad();
                MessageBox.Show("Распределение завершенно");
            }
        }

        private void лабараторныеРаботыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Действительно распределить нагрузку?", "",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var labLoad = new DistributeLoadIsLab(new Repository(new CathedraDBDataContext()), 10);
                labLoad.DistributeLoad();
                MessageBox.Show("Распределение завершенно");
            }
        }

        private void вКРИРуководствоМагистрантовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Действительно распределить нагрузку?", "",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var exchange = new DistributeLoadIsExercisesAndExchange(new Repository(new CathedraDBDataContext()));
                exchange.DistributeLoad();
                MessageBox.Show("Распределение завершенно");
            }
        }

        private void вКРИРуководствоМагистрантовToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var db = new CathedraDBDataContext();
            var rep = new Repository(db);
            var form = new FormDistributionVKR(db, rep, 0.1m);
            form.ShowDialog();
        }

        private void поАудиторнымЗанятиямToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormReport();
            form.ShowDialog();
        }

        private void поПреподователямToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var q = from emp in new CathedraDBDataContext().Employee
                    where !emp.NonActive
                    select emp;
            string alldata = "";

            var sy = (from schoolYear in new CathedraDBDataContext().SchoolYear
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

        private void дляВыбранногоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var employee = (Employee)employeeBindingSource.Current;
            var sy = (from s in new CathedraDBDataContext().SchoolYear
                      where s.ID == 8
                      select s).FirstOrDefault();
            var form = new FormViewLoadEmployee(employee.GetEmployeeInfo(sy));
            form.ShowDialog();
        }
    }
}
