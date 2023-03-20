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
    public partial class ViewTask : Form
    {
        public int idEmp;
        Boolean isEmp;
        private PRN_projectContext _context = new PRN_projectContext();
        public ViewTask(int id, bool isemp)
        {
            InitializeComponent();
            idEmp = id;
            isEmp = isemp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (isEmp == true)
                {
                    var task = _context.Tasks.FirstOrDefault(x => x.TaskId == Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                    task.Status = "Done";
                    _context.Tasks.Update(task);
                    _context.SaveChanges();
                    ViewTask_Load(null, null);
                }
                else { 
                var task = _context.Tasks.FirstOrDefault(x => x.TaskId == Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                _context.Tasks.Remove(task);
                _context.SaveChanges();
                ViewTask_Load(null, null);
            }
            }
        }

        private void ViewTask_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _context.Tasks.Where(x => x.EmployeeId == idEmp).Select(x => new {x.TaskId, x.Title, x.Description, x.Status}).ToList();
            dataGridView1.Columns[0].Visible = false;
            if (isEmp == true)
            {
                button1.Text = "Done";
            }
            else {
                button1.Text = "Delete";
            }

        }
    }
}
