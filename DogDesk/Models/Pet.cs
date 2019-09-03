using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogDesk.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Size { get; set; }
        public string Color1 { get; set; }
        public string Color2 { get; set; }
        public int AnimalTypeId { get; set; }
    }
}
