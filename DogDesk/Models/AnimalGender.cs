using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogDesk.Models
{
    public class AnimalGender
    {
        public int Id { get; set; }

        [Required]
        public string Gender { get; set; }
    }
}
