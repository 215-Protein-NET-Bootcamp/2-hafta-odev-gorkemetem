using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [Display(Name = "CountryId")]
        public int DeptId { get; set; }

        [Required]
        [MaxLength(500)]
        [Display(Name = "DeptName")]
        public string DeptName { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "CountryId")]
        public int CountryId { get; set; }

        [Required]
        [MaxLength(500)]
        [Display(Name = "CountryName")]
        public string CountryName { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Continent")]
        public string Continent { get; set; }


        [MaxLength(100)]
        [Display(Name = "Currency")]
        public string Currency { get; set; }
    }
}
