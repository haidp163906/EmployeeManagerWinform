using Microsoft.Data.SqlClient;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PRN211_project
{
    public partial class EmployeeManager : Form
    {
        private readonly PRN_projectContext _context = new PRN_projectContext();
        public EmployeeManager()
        {

            InitializeComponent();
        }
        static string connectionString = "Data Source=LAPTOP-9SHDL910\\SQLEXPRESS;Initial Catalog=PRN_project;User ID=sa;password=123;";
        SqlConnection connection = new SqlConnection(connectionString);
        void cleanText() {
            textBox1.Text = null;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            textBox2.Text = null;
            comboBox1.SelectedItem = 1;
            textBox4.Text = null;
            textBox5.Text = null;
        }
        private void EmployeeManager_Load(object sender, EventArgs e)
        {
            var listEmp = from c in _context.Employees
                          join d in _context.Departments on c.DepartmentId equals d.DepartmentId
                          select new {c.EmployeeId, c.FullName, c.Gender, c.BirthDate, c.HireDate, c.Phone, d.Name, c.UserName, c.Password };
            dataGridView1.DataSource = listEmp.ToList();
            dataGridView1.Columns[0].Visible = false;
            button5.Visible = false;
            
            }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) {
                button5.Visible = true;
                DataGridViewRow rowSelected = dataGridView1.SelectedRows[0];
                textBox1.Text = rowSelected.Cells[1].Value.ToString();
                if (rowSelected.Cells[2].Value.ToString().Equals("Nam")) { radioButton1.Checked = true;} else { radioButton2.Checked = true; }               
                dateTimePicker1.Value = (DateTime)rowSelected.Cells[3].Value;
                dateTimePicker2.Value = (DateTime)rowSelected.Cells[4].Value;
                textBox2.Text = rowSelected.Cells[5].Value.ToString();
                comboBox1.SelectedItem = rowSelected.Cells[6].Value.ToString();
                textBox4.Text = rowSelected.Cells[7].Value.ToString();
                textBox5.Text = rowSelected.Cells[8].Value.ToString();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells[0].Value);

                String name = textBox1.Text;
                String gender = radioButton1.Checked ? "Male" : "Female";
                DateTime bd = dateTimePicker1.Value;
                DateTime hd = dateTimePicker2.Value;
                String phone = textBox2.Text;
                int depart = comboBox1.SelectedIndex + 1;
                String username = textBox4.Text;
                String pass = textBox5.Text;
                Employee emp = _context.Employees.FirstOrDefault(x => x.EmployeeId == id);
                if (emp != null)
                {
                    emp.FullName = name; emp.Gender = gender; emp.BirthDate = bd; emp.HireDate = hd; emp.Phone = phone; emp.DepartmentId = depart; emp.UserName = username; emp.Password = pass;
                }
                //   Employee emp = new Employee() { FullName = name, Gender = gender, BirthDate = bd, HireDate = hd, Phone = phone, DepartmentId = depart };
                _context.Employees.Update(emp);
                _context.SaveChanges();
                EmployeeManager_Load(null, null);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells[0].Value);
                Employee emp = _context.Employees.FirstOrDefault(x => x.EmployeeId == id);
                _context.Employees.Remove(emp);
                _context.SaveChanges();
                EmployeeManager_Load(null, null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String name = textBox1.Text;
            String gender = radioButton1.Checked ? "Male" : "Female";
            DateTime bd = dateTimePicker1.Value;
            DateTime hd = dateTimePicker2.Value;
            String phone = textBox2.Text;
            int depart = comboBox1.SelectedIndex + 1;
            String username = textBox4.Text;
            String pass = textBox5.Text;
            Employee emp = new Employee() { FullName = name, Gender = gender, BirthDate = bd, HireDate = hd, Phone = phone, DepartmentId = depart, UserName = username, Password = pass };
            _context.AddRange(emp);
            _context.SaveChanges();
            EmployeeManager_Load(null, null);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            EmployeeManager_Load(null, null);
            cleanText();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EmployeeSalary employeeSalary = new EmployeeSalary(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
            employeeSalary.Show();
        }
        void search()
        {
            String name = textBox3.Text;

            connection.Open();
            string query = "select e.FullName, e.Gender, e.BirthDate, e.HireDate, e.Phone, d.Name, e.UserName, e.Password from Employees e  left join Departments d on d.DepartmentID = e.DepartmentID where e.FullName like '%" + name + "%' ";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt.AsDataView();
            connection.Close();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            search();
        }
    }
}
