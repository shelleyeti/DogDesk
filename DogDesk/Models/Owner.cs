using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DogDesk.Models
{
    public class Owner
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }

        public string State { get; set; }

        [DataType(DataType.PostalCode)]
        public int ZipCode { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string HomePhone { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string CellPhone { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string WorkPhone { get; set; }

        [NotMapped]
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            { return $"{FirstName} {LastName}"; }
        }

        public List<PetOwner> PetOwners { get; set; }
    }
}
