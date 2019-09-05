using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DogDesk.Models
{
    public class PetOwner
    {
        public int Id { get; set; }

        [Required]
        public int PetId { get; set; }

        [Required]
        public int OwnerId { get; set; }

        public Owner Owners { get; set; }

        public Pet Pets { get; set; }

    }
}
