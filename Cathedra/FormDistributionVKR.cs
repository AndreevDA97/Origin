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
using Cathedra.BL;

namespace Cathedra
{
    public partial class FormDistributionVKR : Form
    {
        CathedraDBDataContext _db;
        Repository _rep;
        decimal _percentageDeviation;

        public FormDistributionVKR(CathedraDBDataContext db, Repository rep, decimal percentageDeviation)
        {
            InitializeComponent();
            _db = db;
            _rep = rep;
            _percentageDeviation = percentageDeviation;
            UpdateDataGridView();
        }

        public IEnumerable<DataGridViewColumn> InitColumns(EmployeeExtended empe)
        {
            var colums = new List<DataGridViewColumn>();
            colums.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Fio",
                HeaderText = "ФИО",
                ReadOnly = true,
                Frozen = true,
                Width = 200
            });
            foreach (var item2 in empe.Elt)
            {
                colums.Add(new DataGridViewTextBoxColumn()
                {
                    Name = item2.Name,
                    HeaderText = item2.Name + "\n" + item2.Groups,
                    ReadOnly = true,
                    Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleRight },
                    SortMode = DataGridViewColumnSortMode.NotSortable
                });
                colums.Add(new DataGridViewButtonColumn()
                {
                    Name = item2.Name + "+",
                    HeaderText = "",
                    Width = 20,
                    Resizable = DataGridViewTriState.False,
                    SortMode = DataGridViewColumnSortMode.NotSortable
                });
                colums.Add(new DataGridViewButtonColumn()
                {
                    Name = item2.Name + "-",
                    HeaderText = "",
                    Width = 20,
                    Resizable = DataGridViewTriState.False,
                    SortMode = DataGridViewColumnSortMode.NotSortable
                });
            }
            colums.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Total",
                HeaderText = "Всего",
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            colums.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Secure",
                HeaderText = "Загруженно",
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            colums.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Free",
                HeaderText = "Свободно",
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            return colums;
        }

        public DataGridViewRow InitRowHeader(EmployeeExtended empe)
        {
            var row = new DataGridViewRow();

            row.Cells.Add(new DataGridViewTextBoxCell());
            row.Frozen = true;
            foreach (var item2 in empe.Elt)
            {
                var cell = new DataGridViewTextBoxCell();
                cell.Style = new DataGridViewCellStyle() { WrapMode = DataGridViewTriState.True };
                cell.Value = "Всего   : " + item2.TotalStudent.ToString() +
                             "\nОсталось: " + item2.UnallocatedStudent.ToString() + 
                             "\nНа студента: " + item2.PerStudent;
                int position = row.Cells.Add(cell);
                row.Cells.Add(new DataGridViewTextBoxCell());
                row.Cells.Add(new DataGridViewTextBoxCell());

                if (item2.TotalStudent - item2.UnallocatedStudent == item2.TotalStudent)
                {
                    dataGridView1.Columns[position].DefaultCellStyle = new DataGridViewCellStyle()
                    {
                        SelectionBackColor = Color.LightGreen,
                        BackColor = Color.LightGreen,
                        Alignment = DataGridViewContentAlignment.MiddleRight
                    };
                }
                else if (item2.TotalStudent - item2.UnallocatedStudent > item2.TotalStudent)
                {
                    dataGridView1.Columns[position].DefaultCellStyle = new DataGridViewCellStyle()
                    {
                        SelectionBackColor = Color.Red,
                        BackColor = Color.Red,
                        Alignment = DataGridViewContentAlignment.MiddleRight
                    };
                }
                else
                {
                    dataGridView1.Columns[position].DefaultCellStyle = new DataGridViewCellStyle()
                    {
                        Alignment = DataGridViewContentAlignment.MiddleRight
                    };
                }
            }
            row.Cells.Add(new DataGridViewTextBoxCell());
            row.Cells.Add(new DataGridViewTextBoxCell());
            row.Cells.Add(new DataGridViewTextBoxCell());

            return row;
        }

        public DataGridViewRow InitRow(EmployeeExtended empe)
        {
            var dgvr = new DataGridViewRow();
            dgvr.Cells.Add(new DataGridViewTextBoxCell() { Value = empe.Fio });

            foreach (var item2 in empe.Elt)
            {
                var cell = new DataGridViewTextBoxCell();
                cell.Value = item2.CountStudents;
                dgvr.Cells.Add(cell);
                dgvr.Cells.Add(new DataGridViewButtonCell() { Value = "+", Tag = item2 });
                dgvr.Cells.Add(new DataGridViewButtonCell() { Value = "-", Tag = item2 });
            }
            dgvr.Cells.Add(new DataGridViewTextBoxCell() { Value = empe.Total });
            dgvr.Cells.Add(new DataGridViewTextBoxCell() { Value = empe.Secure });
            dgvr.Cells.Add(new DataGridViewTextBoxCell() { Value = empe.Free });

            if (empe.Free > empe.Total * _percentageDeviation)
            {
                dgvr.DefaultCellStyle = new DataGridViewCellStyle()
                {
                    SelectionBackColor = Color.LightGray,
                    BackColor = Color.White
                };
            }
            else if (empe.Free < -empe.Total * _percentageDeviation)
            {
                dgvr.DefaultCellStyle = new DataGridViewCellStyle()
                {
                    SelectionBackColor = Color.Red,
                    BackColor = Color.LightCoral
                };
            }
            else
            {
                dgvr.DefaultCellStyle = new DataGridViewCellStyle()
                {
                    SelectionBackColor = Color.Green,
                    BackColor = Color.LightGreen
                };
            }

            return dgvr;
        }

        public void UpdateDataGridView()
        {
            DataTable dataTable = new DataTable();

            var oldSelect = dataGridView1.CurrentCell?.RowIndex ?? 0;
            dataGridView1.Rows.Clear();
            foreach (var item in _db.Employee.Where(x => !x.NonActive))
            {
                var empe = new EmployeeExtended(item, _db, _rep);

                if (dataGridView1.Columns.Count == 0)
                {
                    var colums = InitColumns(empe);
                    dataGridView1.Columns.AddRange(colums.ToArray());
                }
                
                var dgvr = new DataGridViewRow();
                if (dataGridView1.Rows.Count == 0)
                {
                    var rovHeader = InitRowHeader(empe);
                    dataGridView1.Rows.Add(rovHeader);
                }

                var row = InitRow(empe);
                dataGridView1.Rows.Add(row);
                
            }
            dataGridView1.CurrentCell = dataGridView1.Rows[oldSelect].Cells[0];
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if ((cell.Tag as EmployeeLinkType) != null)
                {
                    if ((string)cell.Value == "+")
                        ((EmployeeLinkType)cell.Tag).AddStudent();
                    if ((string)cell.Value == "-")
                        ((EmployeeLinkType)cell.Tag).DeleteStudent();
                    UpdateDataGridView();
                }
            }
        }

        private void FormDistributionVKR_Load(object sender, EventArgs e)
        {

        }
    }
}