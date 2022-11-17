namespace Labb2_Api_Angular.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string DepName { get; set; }
        public List<Employee>? Employees { get; set; }
    }
}
