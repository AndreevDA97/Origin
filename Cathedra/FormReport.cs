using Cathedra.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cathedra
{
    public partial class FormReport : Form
    {
        private CathedraDBDataContext myDatabase = new CathedraDBDataContext();

        public FormReport()
        {
            InitializeComponent();
            schoolYearBindingSource.DataSource = myDatabase.SchoolYear;
            semestrBindingSource.DataSource = myDatabase.Semestr;
            documentsBindingSource.DataSource = myDatabase.Documents;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            SchoolYear sy = (SchoolYear)schoolYearBindingSource.Current;
            Semestr semestr = (Semestr)semestrBindingSource.Current;

            List<string> ls = new List<string>();

            var q = from cif in myDatabase.CourseInWork
                    where
                        cif.SchoolYear.ID == sy.ID &&
                        cif.Semestr == semestr.ID &&
                        cif.FormStudy == radioButtonOchniki.Checked && cif.DocumentId == (int)comboBox1.SelectedValue
                    orderby cif.Course.ID, cif.ID
                    select cif;

            ls.Add("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//EN\" \"http://www.w3.org/TR/html4/loose.dtd\">");
            ls.Add("<html>");
            ls.Add(" <head>");
            ls.Add("  <meta http-equiv=\"Content-Type\" content=\"text/html; charset=windows-1251\">");
            ls.Add("  <title>Распределение учебной нагрузки</title>");
            ls.Add(" </head>");
            ls.Add(" <body>");
            ls.Add("<p align=\"center\">Для составления расписания занятий со студентами представить в учебный отдел к _______________ 20 __ г.</p>");
            ls.Add("<p align=\"right\"><b>Кафедра АСУ</b></p>");
            ls.Add("<h1 align=\"center\">РАСПРЕДЕЛЕНИЕ</h1>");
            string s = String.Format("учебной нагрузки для {0} {1} на {2} семестр {3} учебного года", 
                (int)comboBox1.SelectedValue == 13 ? "магистрантов" : "бакалавров", 
                radioButtonOchniki.Checked ? "очников" : "заочников", semestr.Name.ToLower(), sy.Years);
            ls.Add("<p align=\"center\">" + s + "</p>");
            ls.Add("<table border=\"1\">");
            ls.Add("<thead>");
            ls.Add("<tr>");
            ls.Add("<td><b>Дисциплина</b></td>");
            ls.Add("<td><b>Вид занятий</b></td>");
            ls.Add("<td><b>Номера учебных групп</b></td>");
            ls.Add("<td><b>Ученое звание, должность, фамилия и инициалы преподавателя</b></td>");
            ls.Add("<td><b>Номера лабораторий</b></td>");
            ls.Add("<td><b>Примечание</b></td>");
            ls.Add("</tr>");
            ls.Add("<tr>");
            ls.Add("<td align=\"center\">1</td>");
            ls.Add("<td align=\"center\">2</td>");
            ls.Add("<td align=\"center\">3</td>");
            ls.Add("<td align=\"center\">4</td>");
            ls.Add("<td align=\"center\">5</td>");
            ls.Add("<td align=\"center\">6</td>");
            ls.Add("</tr>");
            ls.Add("</thead>");
            ls.Add("<tbody>");
            int counter = 1;

            foreach (CourseInWork cif in q)
            {

                int rowspan = cif.LoadInCoursePlan.Count(p => p.SortLoad.IsClass);
                if (rowspan > 0)
                {

                    string rs = "";

                    rs += "<tr id=\"datarow\">";

                    rs += String.Format("<td rowspan=\"{0}\">{1}</td>", rowspan, counter++ + ". " + cif.Course.Name);

                    bool isfirstline = true;
                    foreach (var licp in cif.LoadInCoursePlan.Where(p => p.SortLoad.IsClass))
                    {
                        if (!isfirstline) rs += "</tr>"; else isfirstline = false;

                        rs += "<td>" + licp.SortLoad.ShortName + "</td>";
                        rs += "<td>" + cif.Groups + "</td>";

                        string emps = "";
                        foreach (LoadInCourseFact licf in licp.LoadInCourseFact)
                        {
                            if (!String.IsNullOrEmpty(emps)) emps += ", ";
                            emps += licf.Employee.ShortName;
                        }
                        rs += "<td>" + emps + "</td>";
                        rs += "<td>" + licp.LoadInCourseFact.FirstOrDefault()?.ClassRoom?.Number ?? "" + "</td>";
                        rs += "<td></td>";
                        rs += "</tr>";
                    }
                    ls.Add(rs);
                }
            }

            ls.Add("</tbody>");
            ls.Add("</table>");
            ls.Add(" </body>");
            ls.Add("</html>");

            File.WriteAllLines("Shedule" + (int)comboBox1.SelectedValue + semestr.ToString() + radioButtonOchniki.Checked.ToString() + ".html", ls.ToArray(), Encoding.GetEncoding(1251));
            Process.Start("Shedule" + (int)comboBox1.SelectedValue + semestr.ToString() + radioButtonOchniki.Checked.ToString() + ".html");
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
