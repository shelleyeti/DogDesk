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

        [Display(Name = "Created By")]
        public string UserId { get; set; }

        public int ServiceType { get; set; }

        public int PetId { get; set; }

        [Display(Name = "Start of Service")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End of Service")]
        [DataType(DataType.Date)]
        public DateTime CheckoutDate { get; set; }

        [ForeignKey("PetId")]
        [Display(Name = "Pet Name")]
        public Pet IdOfPet { get; set; }

        [ForeignKey("ServiceType")]
        [Display(Name = "Service Type")]
        public ServiceType NameOfService { get; set; }

        public string ServiceNote { get; set; }

        [Display(Name = "Check-In Time")]
        public DateTime CheckinTime { get; set; }

        [Display(Name = "Check-Out Time")]
        public DateTime CheckoutTime { get; set; }
    }
}
