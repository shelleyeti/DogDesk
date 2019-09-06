using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DogDesk.Models
{
    public class VetRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Pet Name")]
        public int PetId { get; set; }

        [Display(Name = "Vet Name")]
        public string VetName { get; set; }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }


        public string ZipCode { get; set; }

        [Display(Name = "Work Phone")]
        [DataType(DataType.PhoneNumber)]
        public string WorkPhone { get; set; }

        [Display(Name = "Allergies")]
        public string Allergy { get; set; }

        public bool Altered { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Rabies { get; set; }

        public DateTime? Bordetella { get; set; }
    }
}
