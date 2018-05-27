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
using System.Configuration;

namespace Cathedra
{
    public partial class MainForm : Form
    {

        CathedraDBDataContext _db = new CathedraDBDataContext();
        Repository _rep;

        public MainForm()
        {
            InitializeComponent();
            _db = new CathedraDBDataContext();
            _rep = new Repository(_db);
        }

        static string GetConnectionStrings()
        {
            var settings = ConfigurationManager.ConnectionStrings;

            if (settings != null)
            {
                foreach (ConnectionStringSettings cs in settings)
                {
                    if (cs.Name == "iCathedraUniversityConnectionString")
                        return cs.ConnectionString;
                }
            }
            return null;
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
        
        private void поРаспределеннойНагрузкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var str = "";
            var collection = (from licp in _db.LoadInCoursePlan
                              join ciw in _db.CourseInWork on licp.CourseInWorkID equals ciw.ID
                              join sl in _db.SortLoad on licp.SortLoadID equals sl.Id
                              join slict in _db.SortLoadInCourseType on sl.Id equals slict.SortLoadID
                              join d in _db.Documents on ciw.DocumentId equals d.DocumentId
                              join ct in _db.CourseType on slict.CourseTypeID equals ct.Id
                              where d.CourseTypeInDocument.Any(x => x.CourseTypeId == ct.Id)
                               && ciw.SchoolYearID == Repository.SchoolYear
                              select new
                              {
                                  Plan = licp,
                                  Doc = d,
                                  Type = ct,
                                  Work = ciw
                              });

            foreach (var item in collection.GroupBy(x => x.Doc))
            {
                str += item.Key.Name + "\r\n";
                foreach (var item2 in item.GroupBy(x => x.Type))
                {
                    str += "\t" + item2.Key.Name + "\r\n";
                    foreach (var item3 in item2.GroupBy(x => x.Work.FormStudy))
                    {
                        str += "\t\t" + (item3.Key == true ? "Очники" : "Заочники") + "\r\n";
                        foreach (var item4 in item3.GroupBy(x => x.Work.Semestr1))
                        {
                            str += string.Format("\t\t\t{0} семестр. \r\n\t\t\t\tПо плану: \t{1} часов. \r\n\t\t\t\tРаспределено: \t{2} часов.\r\n",
                                item4.Key?.Name ?? "---", item4.Sum(x => x.Plan.CountHours), item4.Sum(x => x.Plan.LoadInCourseFact.Sum(y => y.CountHours)));
                        }
                        str += string.Format("\t\t{0} / {1}\r\n", item3.Sum(x => x.Plan.CountHours), item3.Sum(x => x.Plan.LoadInCourseFact.Sum(y => y.CountHours)));
                    }
                    str += string.Format("\t{0} / {1}\r\n", item2.Sum(x => x.Plan.CountHours), item2.Sum(x => x.Plan.LoadInCourseFact.Sum(y => y.CountHours)));
                }
                str += string.Format("{0} / {1}\r\n\r\n", item.Sum(x => x.Plan.CountHours), item.Sum(x => x.Plan.LoadInCourseFact.Sum(y => y.CountHours)));
            }
            str += string.Format("Всего по плану {0} часов.\r\nРаспределено {1}", 
                _db.LoadInCoursePlan.Where(p => p.CourseInWork.SchoolYearID == Repository.SchoolYear).Sum(x => x.CountHours), 
                _db.LoadInCourseFact.Where(f => f.LoadInCoursePlan.CourseInWork.SchoolYearID == Repository.SchoolYear).Sum(x => x.CountHours));
            var form = new FormViewLoadEmployee(str);
            form.ShowDialog();
        }


        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormSettings(_db);
            form.ShowDialog();
        }

        private void сотрудниковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormViewEmployee(_db);
            form.MdiParent = this;
            form.Show();
        }

        private void ставокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormViewRate(_db);
            form.MdiParent = this;
            form.Show();
        }

        private void должностейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormViewPost(_db);
            form.MdiParent = this;
            form.Show();
        }

        private void окладовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormViewPostScalary(_db);
            form.MdiParent = this;
            form.Show();
        }

        private void автоматическоеРаспределениеНагрузкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormDistriduteLoad(_db, _rep);
            form.MdiParent = this;
            form.Show();
        }

        private void связаннаяНагрузкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormDistributionVKR(_db, _rep, 0.05m);
            form.MdiParent = this;
            form.Show();
        }

        private void поКурсамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormViewLoadFact(_db);
            form.MdiParent = this;
            form.Show();
        }

        private void поПреподавателямToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormReportEmployee(_db);
            form.ShowDialog();
        }

        private void добавитьНагрузкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormEditLoad(_db);
            form.MdiParent = this;
            form.Show();
        }
    }
}
