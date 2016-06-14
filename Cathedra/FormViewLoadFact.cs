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
    public partial class FormViewLoadFact : Form
    {
        CathedraDBDataContext _db;

        public FormViewLoadFact(CathedraDBDataContext db)
        {
            InitializeComponent();
            _db = db;
        }

        private void FormViewLoadFact_Load(object sender, EventArgs e)
        {
            InitComboBox();
            UpdateDataGridView();
        }

        void InitComboBox()
        {
            comboBoxYear.DataSource = _db.SchoolYear;
            comboBoxYear.DisplayMember = "Years";
            this.comboBoxYear.ValueMember = "ID";

            comboBoxDocument.DataSource = _db.Documents.Where(x => x.DateDocument == (int)comboBoxYear.SelectedValue);
            comboBoxDocument.DisplayMember = "Name";
            comboBoxDocument.ValueMember = "DocumentId";

            comboBoxType.DataSource = from typeInDoc in _db.CourseTypeInDocument
                                      join doc in _db.Documents on typeInDoc.DocumentId equals doc.DocumentId
                                      join type in _db.CourseType on typeInDoc.CourseTypeId equals type.Id
                                      where typeInDoc.DocumentId == (int)comboBoxDocument.SelectedValue
                                      select type; ;
            comboBoxType.DisplayMember = "Name";
            comboBoxType.ValueMember = "Id";

            var osen = new { ID = (int?)null, Name = "---" };
            var listSemestr = (new[] { osen }).ToList();
            listSemestr.Add(new { ID = (int?)1, Name = "Осенний" });
            listSemestr.Add(new { ID = (int?)2, Name = "Весенний" });
            cbSemestr.DataSource = listSemestr;
            cbSemestr.DisplayMember = "Name";
            cbSemestr.ValueMember = "ID";

            var och = new { IsOch = (bool?)null, Name = "---" };
            var listFormStudy = (new[] { och }).ToList();
            listFormStudy.Add(new { IsOch = (bool?)true, Name = "Очная" });
            listFormStudy.Add(new { IsOch = (bool?)false, Name = "Заочная" });
            cbFormStudy.DataSource = listFormStudy;
            cbFormStudy.DisplayMember = "Name";
            cbFormStudy.ValueMember = "IsOch";
        }

        void UpdateDataGridView()
        {
            dataGridView1.DataSource = _db.LoadInCourseFact
                .Where(x => x.LoadInCoursePlan.CourseInWork.SchoolYearID == (int?)comboBoxYear.SelectedValue 
                    && x.LoadInCoursePlan.CourseInWork.Semestr == (int?)cbSemestr.SelectedValue
                    && x.LoadInCoursePlan.CourseInWork.FormStudy == (bool?)cbFormStudy.SelectedValue
                    && x.LoadInCoursePlan.CourseInWork.DocumentId == (int?)comboBoxDocument.SelectedValue
                    && _db.SortLoadInCourseType.Where(z => z.CourseTypeID == (int)comboBoxType.SelectedValue).Select(y => y.SortLoad).Contains(x.LoadInCoursePlan.SortLoad)
                    //&& x.LoadInCoursePlan.SortLoad.IsClass
                    )
                .Select(x => new
                {
                    ID = x.Id,
                    Course = x.LoadInCoursePlan.CourseInWork.Course.Name,
                    Sort = x.LoadInCoursePlan.SortLoad.Name,
                    Employee = x.Employee.Fio,
                    Hourse = x.CountHours,
                    Groups = x.LoadInCoursePlan.CourseInWork.Groups,
                    Class = x.ClassRoom.Number
                }).OrderBy(x => x.Course).ThenBy(x => x.Sort.Length);
            dataGridView1.Refresh();
        }

        private void comboBoxYear_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBoxDocument.DataSource = _db.Documents.Where(x => x.DateDocument == (int)comboBoxYear.SelectedValue);
            comboBoxDocument.Refresh();
        }

        private void comboBoxDocument_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBoxType.DataSource = from typeInDoc in _db.CourseTypeInDocument
                                      join doc in _db.Documents on typeInDoc.DocumentId equals doc.DocumentId
                                      join type in _db.CourseType on typeInDoc.CourseTypeId equals type.Id
                                      where typeInDoc.DocumentId == (int)comboBoxDocument.SelectedValue
                                      select type;
            comboBoxType.Refresh();
        }

        private void udateGridView_SelectedValueChanged(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var form = new FormEditLoadFact(_db, (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            form.ShowDialog();
            UpdateDataGridView();
        }
    }
}
