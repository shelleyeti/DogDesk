using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogDesk.Models
{
    public class PetOwner
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public int OwnerId { get; set; }
    }
}
