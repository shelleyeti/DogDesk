﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public string Size { get; set; }
        public string Color1 { get; set; }
        public string Color2 { get; set; }
        public int AnimalTypeId { get; set; }
        public List<VetRecord> VetRecords { get; set; }
    }
}
