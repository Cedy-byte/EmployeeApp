using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeApp
{
    // Code attribution , obsolete method, Employee class has its own validation
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string idNumber = txtIdNumber.Text;
            string name = txtName.Text;
            string surname = txtSurname.Text;
            string email = txtEmail.Text;
            string phoneNo = txtPhoneNumber.Text;
            double salary = Convert.ToDouble(txtSalary.Text);
            DateTime date = dtpDateHire.Value;

            Employee employee = new Employee(idNumber, name, surname, email, phoneNo, salary, date);

            List<ValidationResult> validationResults = new List<ValidationResult>();
            ValidationContext criteria = new ValidationContext(employee);
            bool validCheck = Validator.TryValidateObject(employee, criteria, validationResults, true);
            if (!validCheck)
            {
                foreach (ValidationResult result in validationResults)
                {
                    MessageBox.Show(result.ErrorMessage);
                }
            }
            else
            {
                MessageBox.Show("ID Number: " + idNumber + "\n" + "Name: " + name + "\n" + "Surname: " + surname + "\n"
                + "Email: " + email + "\n" + "Phone Number: " + phoneNo + "\n" + "Salary: R " + salary + "\n" + "Date Hired: " + date + "\n"
                + "Employee UIF: R " + employee.calculateUpdatedUIF().ToString(),"Message");
            }
        }
    }
}
