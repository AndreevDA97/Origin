using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cathedra.Data;

namespace Cathedra
{
    public partial class FormPreferencesEmployeeWorkTogether : Form
    {
        CathedraDBDataContext _db;
        Employee _emp;

        public FormPreferencesEmployeeWorkTogether(CathedraDBDataContext db, Employee emp)
        {
            InitializeComponent();
            _db = db;
            _emp = emp;
        }

        private void FormPreferencesEmployeeWorkTogether_Load(object sender, EventArgs e)
        {
            employeeBindingSource.DataSource = _db.Employee;
            preferencesEmployeeWorkTogetherBindingSource.DataSource = _db.PreferencesEmployeeWorkTogether.Where(x => x.Employee == _emp).OrderBy(x => x.Priority);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            preferencesEmployeeWorkTogetherBindingSource.MoveLast();
            var last = (PreferencesEmployeeWorkTogether)preferencesEmployeeWorkTogetherBindingSource.Current;
            preferencesEmployeeWorkTogetherBindingSource.Add(new PreferencesEmployeeWorkTogether() { EmployeeFirstID = _emp.Id, Priority = last.Priority + 1 });
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            preferencesEmployeeWorkTogetherBindingSource.MoveLast();
            preferencesEmployeeWorkTogetherBindingSource.RemoveCurrent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            _db.SubmitChanges();
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
