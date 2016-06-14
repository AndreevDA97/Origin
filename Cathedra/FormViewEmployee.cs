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
    public partial class FormViewEmployee : Form
    {
        CathedraDBDataContext _db;

        public FormViewEmployee(CathedraDBDataContext db)
        {
            InitializeComponent();
            _db = db;
        }

        private void FormViewEmployee_Load(object sender, EventArgs e)
        {
            employeeBindingSource.DataSource = _db.Employee;
            postBindingSource.DataSource = _db.Post;
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

        private void buttonPreference_Click(object sender, EventArgs e)
        {
            var form = new FormPreferencesEmployeeWorkTogether(_db, (Employee)employeeBindingSource.Current);
            form.ShowDialog();
        }
    }
}
