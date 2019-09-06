using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DogDesk.Models
{
    public class ServicePet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string UserId { get; set; }

        [Display(Name = "Service Type")]
        public int ServiceType { get; set; }

        public int PetId { get; set; }

        [Display(Name = "Date of Service")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Checkout Date")]
        [DataType(DataType.Date)]
        public DateTime CheckoutDate { get; set; }
    }
}
