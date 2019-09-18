using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DogDesk.Models;
using DogDesk.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace DogDesk.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHostingEnvironment _appEnvironment;

        public HomeController(ApplicationDbContext context,
                          UserManager<ApplicationUser> userManager,
                          IHostingEnvironment appEnvironment)
        {
            _userManager = userManager;
            _context = context;
            _appEnvironment = appEnvironment;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public async Task<IActionResult> Index()
        {
            var pet = await _context.Pets
                .Include(p => p.GenderOfAnimal)
                .Include(p => p.SizeOfAnimal)
                .Include(p => p.TypeOfAnimal)
                .Include(p => p.PetOwners)
                .Include(p => p.VetRecords)
                .Include(p => p.PetContacts)
                .Include(p => p.ServicePets)
                .ThenInclude(x => x.NameOfService)
                .ToListAsync();

            //pet.PetOwners.ToList().ForEach(x => x.Owner = _context.Owners.FirstOrDefault(y => y.Id == x.OwnerId));
            //pet.PetContacts.ToList().ForEach(x => x.EmergencyContact = _context.EmergencyContacts.FirstOrDefault(y => y.Id == x.EmergencyContactId));
            //pet.VetRecords = pet.VetRecords.OrderByDescending(x => x.Id).Take(3).ToList();

            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
