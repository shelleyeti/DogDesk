using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogDesk.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public string FirstName { get; set; }
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
    }
}
