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
    public partial class FormEditLoad : Form
    {
        CathedraDBDataContext _db;

        public FormEditLoad(CathedraDBDataContext bd)
        {
            InitializeComponent();
            _db = bd;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitComboBoxs();
            UpdateSotrList();
            UpdataGrid();
        }

        private void UpdataGrid()
        {
            dataGridView1.DataSource = from plan in _db.LoadInCoursePlan
                                       join work in _db.CourseInWork on plan.CourseInWorkID equals work.ID
                                       where work.SchoolYearID == (int)comboBoxYear.SelectedValue
                                       select new
                                       {
                                           Course = work.Course.Name,
                                           SortLoad = plan.SortLoad.Name,
                                           Hourse = plan.CountHours,
                                           Owner = work.Employee.Fio,
                                           Year = work.SchoolYearID,
                                           Semestr = work.Semestr,
                                           Doc = work.DocumentId,
                                           Forma = work.FormStudy
                                       };
            dataGridView1.Refresh();
            if (dataGridView1.RowCount != 0)
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0];
        }

        private void InitComboBoxs()
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

            var osen = new { ID = (short?)null, Name = "---" };
            var listSemestr = (new[] { osen }).ToList();
            listSemestr.Add(new { ID = (short?)1, Name = "Осенний" });
            listSemestr.Add(new { ID = (short?)2, Name = "Весенний" });
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

            cbGroup1.DataSource = from gs in _db.GroupInSemestr
                                  join g in _db.Group on gs.GroupID equals g.ID
                                  where gs.SchoolYear == (int)comboBoxYear.SelectedValue && gs.Semestr == ((short?)cbSemestr.SelectedValue ?? 2) && gs.Group.IsOchniki == (bool?)cbFormStudy.SelectedValue
                                  select new { ID = gs.ID, Name = g.Group1 };
            cbGroup1.DisplayMember = "Name";
            cbGroup1.ValueMember = "ID";
            cbGroup1.SelectedValue = -1;

            cbCourseName.DataSource = _db.Course;
            cbCourseName.DisplayMember = "Name";

            cbEmployee.DataSource = _db.Employee.Where(x => x.NonActive == false);
            cbEmployee.DisplayMember = "Fio";
            cbEmployee.ValueMember = "Id";
        }

        private void AddComboBoxGroup()
        {
            ComboBox comboBox;
            comboBox = new System.Windows.Forms.ComboBox();
            panelGroups.Controls.Add(comboBox);
            int x = 0;
            int y = 24;
            comboBox.FormattingEnabled = true;
            comboBox.Location = new System.Drawing.Point(x, y * (panelGroups.Controls.Count - 1));   //	 panelGroups.Controls.Count
            comboBox.Name = "cbGroup" + panelGroups.Controls.Count.ToString();
            comboBox.Size = new System.Drawing.Size(121, 21);
            comboBox.TabIndex = 0;
            comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;

            this.btnGroupAdd.Location = new System.Drawing.Point(btnGroupAdd.Location.X, btnGroupAdd.Location.Y + y);
            this.btnGroupDelete.Location = new System.Drawing.Point(btnGroupDelete.Location.X, btnGroupDelete.Location.Y + y);


            comboBox.DataSource = from gs in _db.GroupInSemestr
                                  join g in _db.Group on gs.GroupID equals g.ID
                                  where gs.SchoolYear == (int)comboBoxYear.SelectedValue && gs.Semestr == ((short?)cbSemestr.SelectedValue ?? 2) && g.IsOchniki == (bool)cbFormStudy.SelectedValue
                                  select new { ID = gs.ID, Name = g.Group1 };
            comboBox.DisplayMember = "Name";
            comboBox.ValueMember = "ID";
            comboBox.SelectedValue = -1;
        }

        private void UpdateSotrList()
        {
            var listSortLoad = from slt in _db.SortLoadInCourseType
                               join sl in _db.SortLoad on slt.SortLoadID equals sl.Id
                               join t in _db.CourseType on slt.CourseTypeID equals t.Id
                               where t.Id == (int)comboBoxType.SelectedValue
                               select sl;
            if (listSortLoad.Count() != 0)
            {
                ctlSortLoads.Rows.Clear();
                foreach (var workLoad in listSortLoad.OrderBy(item => item.Id))
                {
                    ctlSortLoads.Rows.Add(workLoad.Id, workLoad.Name, 0);
                }
                ctlSortLoads.Rows.Add("", "Часов всего", 0);
                int countRows = ctlSortLoads.Rows.Count;
                ctlSortLoads.Rows[countRows - 1].Cells[2].ReadOnly = true;
            }
        }

        private void comboBoxYear_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBoxDocument.DataSource = _db.Documents.Where(x => x.DateDocument == (int)comboBoxYear.SelectedValue);
            comboBoxDocument.Refresh();

            cbGroup1.DataSource = from gs in _db.GroupInSemestr
                                  join g in _db.Group on gs.GroupID equals g.ID
                                  where gs.SchoolYear == (int)comboBoxYear.SelectedValue && gs.Semestr == (short)cbSemestr.SelectedValue && (bool)cbFormStudy.SelectedValue
                                  select new { ID = gs.ID, Name = g.Group1 };
            cbGroup1.Refresh();
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

        private void ctlSortLoads_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            decimal countHours;
            decimal totalHours = 0;
            
            for (int i = 0; i < ctlSortLoads.RowCount - 1; i++)
            {
                ctlSortLoads.Rows[i].Cells[2].Value = ctlSortLoads.Rows[i].Cells[2].Value.ToString().Replace(".", ",");
                if (Decimal.TryParse(ctlSortLoads.Rows[i].Cells[2].Value.ToString(), out countHours) == true)
                {
                    totalHours += countHours;
                }
            }
            int countRows = ctlSortLoads.Rows.Count;
            ctlSortLoads.Rows[countRows - 1].Cells[2].Value = totalHours;
        }

        private void cbSemestr_SelectedValueChanged(object sender, EventArgs e)
        {
            cbGroup1.DataSource = from gs in _db.GroupInSemestr
                                  join g in _db.Group on gs.GroupID equals g.ID
                                  where gs.SchoolYear == (int)comboBoxYear.SelectedValue && gs.Semestr == ((short?)cbSemestr.SelectedValue ?? 2) && g.IsOchniki == (bool?)cbFormStudy.SelectedValue
                                  select new { ID = gs.ID, Name = g.Group1 };
            cbGroup1.Refresh();
        }

        private void cbFormStudy_SelectedValueChanged(object sender, EventArgs e)
        {
            cbGroup1.DataSource = from gs in _db.GroupInSemestr
                                  join g in _db.Group on gs.GroupID equals g.ID
                                  where gs.SchoolYear == (int)comboBoxYear.SelectedValue && gs.Semestr == ((short?)cbSemestr.SelectedValue ?? 2) && g.IsOchniki == (bool?)cbFormStudy.SelectedValue
                                  select new { ID = gs.ID, Name = g.Group1 };
            cbGroup1.SelectedIndex = -1;
            cbGroup1.Refresh();
        }

        private void comboBoxType_SelectedValueChanged(object sender, EventArgs e)
        {
            UpdataGrid();
            UpdateSotrList();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var CourseID = ((Course)cbCourseName.SelectedValue).ID;
            var SchoolYearID = (int)comboBoxYear.SelectedValue;
            var Semestr = (short?)cbSemestr.SelectedValue;
            int? EmployeeID = null;
            if (!(cbEmployee.SelectedIndex == -1 || cbEmployee.SelectedValue == null))
                EmployeeID = (int)cbEmployee.SelectedValue;
            var FormStudy = (bool?)cbFormStudy.SelectedValue;
            var DocumentId = (int)comboBoxDocument.SelectedValue;
            var work = new CourseInWork()
            {
                CourseID = CourseID,
                SchoolYearID = SchoolYearID,
                Semestr = Semestr,
                EmployeeID = EmployeeID,
                FormStudy = FormStudy,
                DocumentId = DocumentId
            };
            _db.CourseInWork.InsertOnSubmit(work);

            for(int i = 0; i < ctlSortLoads.RowCount - 1; i++)
            {
                decimal countHours;
                if (Decimal.TryParse(ctlSortLoads.Rows[i].Cells[2].Value.ToString(), out countHours) == true && countHours != 0)
                {
                    _db.LoadInCoursePlan.InsertOnSubmit(new LoadInCoursePlan()
                    {
                        CountHours = countHours,
                        CourseInWork = work,
                        SortLoadID = (int)ctlSortLoads.Rows[i].Cells[0].Value
                    });
                }
            }

            for (int i = 0; i < panelGroups.Controls.Count; i++)
            {
                ComboBox comboBox = (ComboBox)panelGroups.Controls[i];
                if (comboBox.SelectedValue != null && comboBox.SelectedIndex != -1)
                {
                    _db.GroupInCourse.InsertOnSubmit(new GroupInCourse()
                    {
                        GroupInSemestrID = (int)comboBox.SelectedValue,
                        CourseInWork = work
                    });
                    //comboBox.SelectedIndex = -1;
                }
            }
            _db.SubmitChanges();
            UpdataGrid();
            UpdateSotrList();
        }

        private void btnGroupAdd_Click(object sender, EventArgs e)
        {
            if (panelGroups.Controls.Count < 5)
            {
                AddComboBoxGroup();
            }
        }

        private void btnGroupDelete_Click(object sender, EventArgs e)
        {
            if (panelGroups.Controls.Count == 1)
            {
                cbGroup1.SelectedValue = -1;
            }
            if (panelGroups.Controls.Count > 1)
            {
                ComboBox comboBox = (ComboBox)panelGroups.Controls[panelGroups.Controls.Count - 1];
                comboBox.Dispose();

                int y = 24;
                Button button = (Button)sender;
                button.Location = new System.Drawing.Point(button.Location.X, button.Location.Y - y);
                this.btnGroupAdd.Location = new System.Drawing.Point(this.btnGroupAdd.Location.X, this.btnGroupAdd.Location.Y - y);
            }
        }

        private void cbCourseName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var owner = ((Course)cbCourseName.SelectedValue).EmployeeID;
            if(owner != null)
                cbEmployee.SelectedValue = owner;
        }
    }
}
