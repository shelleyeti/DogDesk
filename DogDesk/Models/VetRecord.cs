﻿using System;
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
        public int PetId { get; set; }
        public string VetName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }


        public string ZipCode { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string WorkPhone { get; set; }

        public string Allergy { get; set; }
        public bool Altered { get; set; }

        [DataType(DataType.Date)]
        public DateTime Rabies { get; set; }
        public DateTime? Bordetella { get; set; }
    }
}
