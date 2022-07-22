using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProteinApi.Dto
{
    public class FolderDto
    {
        [Required]
        [MaxLength(20)]
        [Display(Name = "FolderId")]
        public int FolderId { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "EmpId")]
        public int EmpId { get; set; }

        [Required]
        [MaxLength(500)]
        [Display(Name = "AccessType")]
        public string AccessType { get; set; }
    }
}
