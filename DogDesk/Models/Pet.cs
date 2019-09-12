using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DogDesk.Models
{
    public class Pet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Gender")]
        public int GenderId { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        [Display(Name = "Size")]
        public int SizeId { get; set; }

        [Required]
        [Display(Name = "Primary Color")]
        public string Color1 { get; set; }

        [Display(Name = "Secondary Color")]
        public string Color2 { get; set; }

        [Required]
        [Display(Name = "Species")]
        public int AnimalTypeId { get; set; }

        public string Breed { get; set; }


        public ICollection<VetRecord> VetRecords { get; set; }
        public virtual ICollection<PetOwner> PetOwners { get; set; }
        public virtual ICollection<PetContact> PetContacts { get; set; }
        public ICollection<EmergencyContact> EmergencyContacts { get; set; }
        public ICollection<ServicePet> ServicePets { get; set; }

        [ForeignKey("GenderId")]
        public AnimalGender GenderOfAnimal { get; set; }

        [ForeignKey("SizeId")]
        public AnimalSize SizeOfAnimal { get; set; }

        [ForeignKey("AnimalTypeId")]
        public AnimalType TypeOfAnimal { get; set; }

    }
}
