using System.ComponentModel.DataAnnotations;

namespace ProteinApi.Dto
{
    public class DepartmentDto
    {
        [Required]
        [MaxLength(20)]
        [Display(Name = "DepartmentId")]
        public int DepartmentId { get; set; }

        [Required]
        [MaxLength(500)]
        [Display(Name = "DeptName")]
        public string DeptName { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "CountryId")]
        public int CountryId { get; set; }

    }
}
