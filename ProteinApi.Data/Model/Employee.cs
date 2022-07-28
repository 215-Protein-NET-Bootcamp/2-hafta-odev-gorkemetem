using System.ComponentModel.DataAnnotations;

namespace ProteinApi.Data
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int DeptId { get; set; }

    }
}
