using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogDesk.Models
{
    public class ServiceType
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }

        //public List<SelectListItem> getServiceType()
        //{
        //    List<SelectListItem> List = new List<SelectListItem>();
        //    var data = new[]{
        //         new SelectListItem{ Value="1", Text="Small Dog Boarding"},
        //         new SelectListItem{ Value="2", Text="Medium Dog Boarding"},
        //         new SelectListItem{ Value="3", Text="Large Dog Boarding"},
        //         new SelectListItem{ Value="4", Text="Cat Boarding"},
        //         new SelectListItem{ Value="5", Text="Day Care"},
        //         new SelectListItem{ Value="6", Text="Small Dog Bath"},
        //         new SelectListItem{ Value="7", Text="Medium Dog Bath"},
        //         new SelectListItem{ Value="8", Text="Large Dog Bath"},
        //         new SelectListItem{ Value="9", Text="Nail Trim"},

        //     };
        //    List = data.ToList();
        //    return List;
        //}
    }
}
