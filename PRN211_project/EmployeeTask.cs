using PRN211_project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRN211_project
{
    public partial class EmployeeTask : Form
    {
        private readonly PRN_projectContext _context = new PRN_projectContext();
        public int idepart;
        public EmployeeTask(int id)
        {
            idepart = id;
            InitializeComponent();
        }

        private void EmployeeTask_Load(object sender, EventArgs e)
        {
            var list = from d in _context.Employees
                       where d.DepartmentId == idepart
                       select new { d.EmployeeId, d.FullName, d.Gender, d.Phone };
            dataGridView1.DataSource = list.ToList();
            dataGridView1.Columns[0].Visible = false;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                button3.Visible = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox1.Text = null;
                textBox2.Text = null;
            }
            else { button3.Visible = false; textBox1.Enabled = false; textBox2.Enabled = false; }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                button3.Visible = true;
                textBox1.Enabled= true;
                textBox2.Enabled = true;
                textBox1.Text = null;
                textBox2.Text = null;

            }
            else { button3.Visible = false; textBox1.Enabled = false; textBox2.Enabled = false;}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int idEmp = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                String title = textBox1.Text;
                String scrip = textBox2.Text;
                Models.Task task = new Models.Task() { EmployeeId = idEmp, Title = title, Description = scrip, Status = "Doing" };
                _context.Tasks.AddRange(task);
                _context.SaveChanges();
                EmployeeTask_Load(null, null);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewTask view = new ViewTask(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value),false);
            view.Show();

        }

        

       
    }
}
