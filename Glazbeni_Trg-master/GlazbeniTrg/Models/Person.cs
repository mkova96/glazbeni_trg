using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GlazbeniTrg.Models
{
    public class Person
    {

        
        [Key]
        public Guid PersonID { get; set; }

        [Required]
        public String FirstName { get; set; }

        
        public String LastName { get; set; }

        [DataType(DataType.MultilineText)]
        public String Bio { get; set; }


        private ICollection<SongPerson> SongPersons { get; } = new List<SongPerson>();
       
    }
}
