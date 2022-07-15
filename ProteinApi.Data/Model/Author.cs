using ProteinApi.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProteinApi.Data
{
    public class Author : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }


        [NotMapped]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
