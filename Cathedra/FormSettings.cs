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
    public partial class FormSettings : Form
    {
        CathedraDBDataContext _db;

        public FormSettings(CathedraDBDataContext db)
        {
            InitializeComponent();
            _db = db;
            cbSchoolYear.DataSource = _db.SchoolYear;
            cbSchoolYear.SelectedValue = Repository.GetSchollYearID();
            numericUpDown1.Value = Repository.GetLoadPercent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Repository.InstallSettings((int)cbSchoolYear.SelectedValue, (int)numericUpDown1.Value);
                Close();
            }
            catch(ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
