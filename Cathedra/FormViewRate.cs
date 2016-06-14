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
    public partial class FormViewRate : Form
    {
        CathedraDBDataContext _db;

        public FormViewRate(CathedraDBDataContext db)
        {
            InitializeComponent();
            _db = db;
            employeeBindingSource.DataSource = _db.Employee;
            postBindingSource.DataSource = _db.Post;
            schoolYearBindingSource.DataSource = _db.SchoolYear;
            rateBindingSource.DataSource = _db.Rate;
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
