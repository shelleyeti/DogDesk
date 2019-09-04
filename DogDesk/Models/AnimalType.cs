using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogDesk.Models
{
    public class AnimalType
    {
        public int Id { get; set; }
        public string Animal { get; set; }

        //public List<SelectListItem> getAnimalTypeList()
        //{
        //    List<SelectListItem> List = new List<SelectListItem>();
        //    var data = new[]{
        //         new SelectListItem{ Value="1", Text="Dog"},
        //         new SelectListItem{ Value="2", Text="Cat"}
        //     };
        //    List = data.ToList();
        //    return List;
        //}
    }
}
