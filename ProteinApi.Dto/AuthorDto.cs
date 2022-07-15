using ProteinApi.Base;
using System.ComponentModel.DataAnnotations;

namespace ProteinApi.Dto
{
    public class AuthorDto : BaseDto
    {
        [Required]
        [MaxLength(500)]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(500)]
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [EmailAddress]
        [MaxLength(500)]
        public string Email { get; set; }

        [Phone]
        [MaxLength(25)]
        public string Phone { get; set; }


        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
