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
    public partial class FormViewPostScalary : Form
    {
        CathedraDBDataContext _db;

        public FormViewPostScalary(CathedraDBDataContext db)
        {
            InitializeComponent();
            _db = db;
            postBindingSource.DataSource = _db.Post;
            postSalaryBindingSource.DataSource = _db.PostSalary;
            schoolYearBindingSource.DataSource = _db.SchoolYear;
              
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            _db.SubmitChanges();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
