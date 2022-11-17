using System.ComponentModel.DataAnnotations;

namespace Labb2_Api_Angular.Models
{
    public class Employee
    {
        [Key]
        public Guid EmployeeId { get; set; }
        public string EmpFirstName { get; set; }
        public string EmpLastName { get; set; }
        public string EmpEmail { get; set; }
        public string EmpPhone { get; set; }
        public string EmpGender { get; set; }
        public int DepartmentID { get; set; }
        public Department? Department { get; set; }
        public decimal Salary { get; set; }

    }
}
