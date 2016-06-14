using Cathedra.BL;
using Cathedra.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cathedra
{
    public partial class FormDistriduteLoad : Form
    {
        CathedraDBDataContext _db;
        Repository _rep;

        public FormDistriduteLoad(CathedraDBDataContext db, Repository rep)
        {
            InitializeComponent();
            _db = db;
            _rep = rep;
        }

        private void FormViewLoadFact_Load(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        

        void UpdateDataGridView()
        {
            var s = _db.LoadInCoursePlan
                .Where(x => x.CourseInWork.SchoolYearID == Repository.GetSchollYearID()
                    && (x.LoadInCourseFact.Count == 0 || x.LoadInCourseFact.Sum(y => y.CountHours) != x.CountHours));
                
            dataGridView1.DataSource = s.Select(x => new
            {
                ID = x.Id,
                Course = x.CourseInWork.Course.Name,
                Sort = x.SortLoad.Name,
                Employee = x.OwnerIsCourse,//.Fio,
                Hourse = x.CountHours - (x.LoadInCourseFact.Count == 0 ? 0 : x.LoadInCourseFact.Sum(y => y.CountHours)),
                Groups = x.CourseInWork.Groups,
            }).OrderBy(x => x.Course).ThenBy(x => x.Sort.Length); ;
            dataGridView1.Refresh();
        }

 

        private void udateGridView_SelectedValueChanged(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //var form = new FormEditLoadFact(_db, (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            //form.ShowDialog();
            //UpdateDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Действительно распределить нагрузку?", "",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var ownerLoad = new DistributeLoadIsOwner(_rep);
                ownerLoad.DistributeLoad();
                MessageBox.Show("Распределение завершенно");
                UpdateDataGridView();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Действительно распределить нагрузку?", "",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var labLoad = new DistributeLoadIsLab(_rep, 10);
                labLoad.DistributeLoad();
                MessageBox.Show("Распределение завершенно");
                UpdateDataGridView();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Действительно распределить нагрузку?", "",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var exchange = new DistributeLoadIsExercisesAndExchange(_rep);
                exchange.DistributeLoad();
                MessageBox.Show("Распределение завершенно");
                UpdateDataGridView();
            }
        }
    }
}
