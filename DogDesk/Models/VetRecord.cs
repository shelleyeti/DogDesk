using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogDesk.Models
{
    public class VetRecord
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public string VetName { get; set; }
        public string StreetAddress { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string WorkPhone { get; set; }

        public string Allergy { get; set; }
        public bool Altered { get; set; }
    }
}
