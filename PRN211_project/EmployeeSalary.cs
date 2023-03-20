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
    public partial class EmployeeSalary : Form
    {
        public int idEmp;
        private readonly PRN_projectContext _context = new PRN_projectContext();
        public EmployeeSalary(int id)
        {
            idEmp = id;
            InitializeComponent();
        }

        private void EmployeeSalary_Load(object sender, EventArgs e)
        {
            var list = _context.Salaries.Where(x => x.EmployeeId == idEmp).Select(x => new { x.HardSalary, x.Bonus }).ToList();
            dataGridView1.DataSource = list;
            if (list.Count != 0)
            {
                button1.Visible = false; button2.Visible = true;
                numericUpDown1.Value = Convert.ToUInt32(dataGridView1.Rows[0].Cells[1].Value);
                numericUpDown2.Value = Convert.ToUInt32(dataGridView1.Rows[0].Cells[0].Value);

            }
            else {
                button1.Visible = true; button2.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int salary = Convert.ToInt32(numericUpDown1.Value);
            int bonus = Convert.ToInt32(numericUpDown2.Value);
            Salary sal = new Salary() {Bonus = bonus, EmployeeId = idEmp, HardSalary = salary};
            _context.Salaries.Add(sal);
            _context.SaveChanges();
            EmployeeSalary_Load(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Salary sal = _context.Salaries.FirstOrDefault(x=>x.EmployeeId == idEmp);
            sal.Bonus = Convert.ToInt32(numericUpDown1.Value);
            sal.HardSalary= Convert.ToInt32(numericUpDown2.Value);
            _context.Update(sal);
            _context.SaveChanges();
            EmployeeSalary_Load(null, null);

        }
    }
}
