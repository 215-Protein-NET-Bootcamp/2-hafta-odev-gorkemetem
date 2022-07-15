using System;
using System.ComponentModel.DataAnnotations;

namespace ProteinApi.Base
{
    public abstract class BaseDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }


        [MaxLength(500)]
        [Display(Name = "CreatedBy")]
        public string CreatedBy { get; set; }

        public bool Available { get; set; }
    }
}
