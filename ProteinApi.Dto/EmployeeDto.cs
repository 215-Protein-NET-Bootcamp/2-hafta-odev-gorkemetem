using System.ComponentModel.DataAnnotations;

namespace ProteinApi.Dto
{
    public class EmployeeDto
    {
        [Required]
        [MaxLength(20)]
        [Display(Name = "EmpId")]
        public int EmpId { get; set; }

        [Required]
        [MaxLength(500)]
        [Display(Name = "EmpName")]
        public string EmpName { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "DeptId")]
        public int DeptId { get; set; }
    }
}
