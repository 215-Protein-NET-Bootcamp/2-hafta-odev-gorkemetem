using ProteinApi.Base;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProteinApi.Dto
{
    public class PersonDto :BaseDto
    {

        [Required]
        [MaxLength(25)]
        [Display(Name = "StaffId")]
        public string StaffId { get; set; }

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

        [MaxLength(500)]
        public string Description { get; set; }

        [Phone]
        [MaxLength(25)]
        public string Phone { get; set; }

        [Required]
        [DateOfBirth]
        [DataType(DataType.Date)]
        [JsonConverter(typeof(DateTimeConverter))]
        [Display(Name = "DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
