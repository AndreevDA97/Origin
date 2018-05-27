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
    public partial class FormEditLoadFact : Form
    {
        int _loadFactID;
        CathedraDBDataContext _db;

        public FormEditLoadFact(CathedraDBDataContext db, int loadFactID)
        {
            InitializeComponent();
            _loadFactID = loadFactID;
            _db = db;
            InitComboBox();
        }

        void InitComboBox()
        {
            comboBoxClass.DataSource = _db.ClassRoom;
            comboBoxClass.DisplayMember = "Number";
            comboBoxClass.ValueMember = "Id";
            comboBoxClass.SelectedValue = _db.ClassRoom.Where(x => x.Id == x.LoadInCourseFact.Where(y => y.Id == _loadFactID).Single().ClassRoom.Id).FirstOrDefault()?.Id ?? 1;

            cbEmployee.DataSource = _db.Employee.Where(x => !x.NonActive);
            cbEmployee.DisplayMember = "Fio";
            cbEmployee.ValueMember = "Id";
            cbEmployee.SelectedValue = _db.Employee.Where(x => x.LoadInCourseFact.Where(y => y.Id == _loadFactID).Single().Employee == x).FirstOrDefault()?.Id ?? 1;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            _db.LoadInCourseFact.Single(x => x.Id == _loadFactID).EmployeeID = (int)cbEmployee.SelectedValue;
            _db.LoadInCourseFact.Single(x => x.Id == _loadFactID).ClassRoomID = (int)comboBoxClass.SelectedValue;
            _db.SubmitChanges();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Действительно разбить нагрузку?", "",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var loadFact = _db.LoadInCourseFact.Single(x => x.Id == _loadFactID);
                loadFact.CountHours = loadFact.CountHours / 2;
                _db.LoadInCourseFact.InsertOnSubmit(new LoadInCourseFact
                {
                    Approved = true,
                    ClassRoomID = loadFact.ClassRoomID,
                    CountHours = loadFact.CountHours,
                    EmployeeID = loadFact.EmployeeID,
                    LoadInCoursePlanID = loadFact.LoadInCoursePlanID
                });
                _db.SubmitChanges();
                Close();
            }
        }
    }
}
