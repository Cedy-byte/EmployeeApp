using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    public class Employee
    {
        private string iDNumber;
        private string name;
        private string surname;
        private string email;
        private string phoneNo;
        private double salary;
        private DateTime dateHired;

        public Employee(string iDNumber, string name, string surname, string email, string phoneNo, double salary, DateTime dateHired)
        {
            IDNumber = iDNumber;
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.PhoneNo = phoneNo;
            this.Salary = salary;
            this.DateHired = dateHired;
        }

        [Required(ErrorMessage = "ID number is required")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "Please enter an ID number with 13 digits")]
        public string IDNumber { get => iDNumber; set => iDNumber = value; }

        [Required(ErrorMessage = "Employee Name is required")]
        public string Name { get => name; set => name = value; }

        [Required(ErrorMessage = "Employee Surname is required")]
        public string Surname { get => surname; set => surname = value; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get => email; set => email = value; }

        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Please enter a phone number with 10 digits")]
        public string PhoneNo { get => phoneNo; set => phoneNo = value; }

        [Required(ErrorMessage = "Salary is required")]
        [Range(1, 1000000, ErrorMessage = "Salary must be between 1 and 1000000")]
        public double Salary { get => salary; set => salary = value; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime DateHired { get => dateHired; set => dateHired = value; }

        [Obsolete("This method is obsolete consider using the latest version")]
        public double calculateUIF()
        {
            double result = Salary * 0.5;
            return result;
        }

        public double calculateUpdatedUIF()
        {
            double result = Salary * 0.1;
            return result;
        }
    }
}
