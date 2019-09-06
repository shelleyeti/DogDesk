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
        public string Name { get; set; }
        public int GenderId { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public int SizeId { get; set; }
        public string Color1 { get; set; }
        public string Color2 { get; set; }
        public int AnimalTypeId { get; set; }
        public string Breed { get; set; }


        public List<VetRecord> VetRecords { get; set; }
        public virtual ICollection<PetOwner> PetOwners { get; set; }
        public List<EmergencyContact> EmergencyContacts { get; set; }
        public List<ServicePet> ServicePets { get; set; }

    }
}
