using System.ComponentModel.DataAnnotations;

namespace ProteinApi.Dto
{
    public class CountryDto
    {
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
