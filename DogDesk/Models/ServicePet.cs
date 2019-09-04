using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogDesk.Models
{
    public class ServicePet
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ServiceType { get; set; }
        public int PetId { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime CheckoutDate { get; set; }
    }
}
