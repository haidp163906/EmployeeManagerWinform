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
    public partial class Login : Form
    {
        public int IdEmp = -1;
        public int IdDpart = -1;  
        Boolean IsEmp = true;

        private readonly PRN_projectContext _context = new PRN_projectContext();
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username = textBox1.Text;
            String password = textBox2.Text;
            List<Employee> listEmp = new List<Employee>();
            List<Manager> listMana= new List<Manager>();
            listEmp = _context.Employees.ToList();
            listMana = _context.Managers.ToList();
            foreach (Employee d in listEmp) {
                if (username.Equals(d.UserName) && password.Equals(d.Password)) {
                    IdEmp = d.EmployeeId;
                    ViewTask employeeTask= new ViewTask(IdEmp, IsEmp);
                    employeeTask.Show();
                    break;
                    //---------------------------
                }
            }
            foreach (Manager d in listMana)
            {
                if (username.Equals(d.UserName) && password.Equals(d.Password))
                {
                    IdDpart = d.AccountId;
                    EmployeeTask employeeTask = new EmployeeTask(IdDpart);
                    employeeTask.Show();
                    break;
                    //---------------------------
                }
            }
            if (username.Equals("admin") && password.Equals("123456")) {              
                EmployeeManager employeeManager = new EmployeeManager();
                employeeManager.Show();
            }

        }
    }
}
