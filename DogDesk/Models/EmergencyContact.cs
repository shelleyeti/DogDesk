using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DogDesk.Models
{
    public class EmergencyContact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PetId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string HomePhone { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string CellPhone { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string WorkPhone { get; set; }
    }
}
