using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DogDesk.Data;
using DogDesk.Models;
using Microsoft.AspNetCore.Identity;

namespace DogDesk
{
    public class ServicePetsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public ServicePetsController(ApplicationDbContext context,
                          UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            var servicePet = _context.ServicePets
                .Include(x => x.IdOfPet)
                .Include(x => x.NameOfService);

            foreach(var item in servicePet)
            {
                var userName = _context.ApplicationUsers.FirstOrDefault(x => x.Id == item.UserId);
                if (userName != null)
                {
                    item.UserId = userName.FullName;
                }
            }

            return View(servicePet);
        }

        // GET: ServicePets/MainCalendar
        public async Task<IActionResult> MainCalendar()
        {
            ViewData["ServiceTypes"] = GetLongServiceTypes();

            return View(await _context.ServicePets.ToListAsync());
        }

        // GET: ServicePets/TmeLineCalendar
        public async Task<IActionResult> TimeLineCalendar()
        {
            ViewData["ServiceTypes"] = GetShortServiceTypes();

            return View(await _context.ServicePets.ToListAsync());
        }

        // GET: ServicePets/ListViewCalendar
        public async Task<IActionResult> ListViewCalendar()
        {
            //ViewData["ServiceTypes"] = GetShortServiceTypes();

            return View(await _context.ServicePets.ToListAsync());
        }


        // GET: ServicePets/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var servicePet = await _context.ServicePets
                .Include(x => x.IdOfPet)
                .Include(x => x.NameOfService)
                .FirstOrDefaultAsync(m => m.Id == id);

            var userName = _context.ApplicationUsers.FirstOrDefault(x => x.Id == servicePet.UserId);
            if (userName != null)
            {
            servicePet.UserId = userName.FullName;
            }

            if (servicePet == null)
            {
                return NotFound();
            }

            return View(servicePet);
        }

        // GET: ServicePets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["ServiceTypes"] = GetServiceTypes();

            var servicePetDetails = _context.ServicePets
                .Include(x => x.IdOfPet)
                .Include(x => x.NameOfService);

            foreach (var item in servicePetDetails)
            {
                var userName = _context.ApplicationUsers.FirstOrDefault(x => x.Id == item.UserId);
                if (userName != null)
                {
                    item.UserId = userName.FullName;
                }
            }

            if (id == null)
            {
                return NotFound();
            }

            var servicePet = await _context.ServicePets.FindAsync(id);

            if (servicePet == null)
            {
                return NotFound();
            }
            return View(servicePet);
        }

        // POST: ServicePets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ServiceType,PetId,StartDate,CheckoutDate,ServiceNote")] ServicePet servicePet)
        {
            if (id != servicePet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicePet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicePetExists(servicePet.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(MainCalendar));
            }
            return View(servicePet);
        }

        // GET: ServicePets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicePet = await _context.ServicePets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servicePet == null)
            {
                return NotFound();
            }

            return View(servicePet);
        }

        // POST: ServicePets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servicePet = await _context.ServicePets.FindAsync(id);
            _context.ServicePets.Remove(servicePet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(MainCalendar));
        }

        private bool ServicePetExists(int id)
        {
            return _context.ServicePets.Any(e => e.Id == id);
        }

        public JsonResult GetPetNameList(string name)
        {
            var list = _context.Pets
                .Where(x => x.Name.StartsWith(name, StringComparison.InvariantCultureIgnoreCase))
                .Take(10)
                .ToList();
            return Json(list);
        }

        public JsonResult LookupPet(int petId)
        {
            var pet = _context.Pets.FirstOrDefault(x => x.Id == petId);

            return Json(pet);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePet([FromBody]ServicePet servicePet)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            servicePet.UserId = user.Id;

            _context.Add(servicePet);
                _context.SaveChanges();
                return Json(servicePet);
        }

        [HttpPost]
        public IActionResult UpdatePetService([FromBody]ServicePet servicePet)
        {
            servicePet.UserId = _userManager.GetUserAsync(HttpContext.User).Result.Id;

            _context.Update(servicePet);
            _context.SaveChanges();
            return Json(servicePet);
        }

        [HttpPost]
        public IActionResult CheckInPet(ServicePet servicePet)
        {
            servicePet.CheckinTime = DateTime.Now;

            _context.Update(servicePet);
            _context.SaveChanges();
            Json(servicePet);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult CheckOutPet(ServicePet servicePet)
        {
            servicePet.CheckoutTime = DateTime.Now;

            _context.Update(servicePet);
            _context.SaveChanges();
            Json(servicePet);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult GetAllServicePets()
        {
            var servicePets = _context.ServicePets;

            foreach(var sp in servicePets)
            {
                sp.IdOfPet = new Pet
                {
                    Name = _context.Pets.FirstOrDefault(p => p.Id == sp.PetId).Name
                };

                sp.NameOfService = new ServiceType
                {
                    ServiceName = _context.ServiceTypes.FirstOrDefault(s => s.Id == sp.ServiceType).ServiceName
                };
            }
            //.Include(p => p.IdOfPet)
            //.Include(s => s.NameOfService).ToListAsync();

            //servicePets.ToList().ForEach(p => p.IdOfPet = _context.Pets.FirstOrDefault(pt => pt.Id == p.PetId));
            //servicePets.ToList().ForEach(s => s.NameOfService = _context.ServiceTypes.FirstOrDefault(st => st.Id == s.ServiceType));

            return Json(servicePets.ToList());
        }

        public IActionResult GetShortServicePets()
        {
            var servicePets = _context.ServicePets
                .Where(x => x.ServiceType == 6 || x.ServiceType == 7 || x.ServiceType == 8 || x.ServiceType == 9);

            foreach (var sp in servicePets)
            {
                sp.IdOfPet = new Pet
                {
                    Name = _context.Pets.FirstOrDefault(p => p.Id == sp.PetId).Name
                };

                sp.NameOfService = new ServiceType
                {
                    ServiceName = _context.ServiceTypes.FirstOrDefault(s => s.Id == sp.ServiceType).ServiceName
                };
            }
            return Json(servicePets.ToList());
        }

        public IActionResult GetLongServicePets()
        {
            var servicePets = _context.ServicePets
                .Where(x => x.ServiceType == 5 || x.ServiceType == 1 || x.ServiceType == 3 || x.ServiceType == 2 || x.ServiceType == 4);

            foreach (var sp in servicePets)
            {
                sp.IdOfPet = new Pet
                {
                    Name = _context.Pets.FirstOrDefault(p => p.Id == sp.PetId).Name
                };

                sp.NameOfService = new ServiceType
                {
                    ServiceName = _context.ServiceTypes.FirstOrDefault(s => s.Id == sp.ServiceType).ServiceName
                };
            }
            return Json(servicePets.ToList());
        }

        private List<SelectListItem> GetServiceTypes()
        {
            var selectItems = _context.ServiceTypes
                .Select(program => new SelectListItem
                {
                    Text = program.ServiceName,
                    Value = program.Id.ToString()
                })
                .ToList();

            selectItems.Insert(0, new SelectListItem
            {
                Text = "Choose type...",
                Value = "0"
            });
            return selectItems;
        }

        private List<SelectListItem> GetLongServiceTypes()
        {
            var selectItems = _context.ServiceTypes
                .Where(x => x.ServiceName == "Small Dog Boarding" || x.ServiceName == "Medium Dog Boarding" || x.ServiceName == "Large Dog Boarding" || x.ServiceName == "Cat Boarding" || x.ServiceName == "Day Care")
                .Select(program => new SelectListItem
                {
                    Text = program.ServiceName,
                    Value = program.Id.ToString()
                })
                .ToList();

            selectItems.Insert(0, new SelectListItem
            {
                Text = "Choose type...",
                Value = "0"
            });
            return selectItems;
        }

        private List<SelectListItem> GetShortServiceTypes()
        {
            var selectItems = _context.ServiceTypes
                .Where(x => x.ServiceName == "Nail Trim" || x.ServiceName == "Small Dog Bath" || x.ServiceName == "Medium Dog Bath" || x.ServiceName == "Large Dog Bath")
                .Select(program => new SelectListItem
                {
                    Text = program.ServiceName,
                    Value = program.Id.ToString()
                })
                .ToList();

            selectItems.Insert(0, new SelectListItem
            {
                Text = "Choose type...",
                Value = "0"
            });
            return selectItems;
        }
    }
}
