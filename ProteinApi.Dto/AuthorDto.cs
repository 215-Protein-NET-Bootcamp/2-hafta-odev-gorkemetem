using ProteinApi.Base.BaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
