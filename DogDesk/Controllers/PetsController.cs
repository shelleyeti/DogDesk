﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DogDesk.Data;
using DogDesk.Models;
using Microsoft.AspNetCore.Identity;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace DogDesk
{
    public class PetsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHostingEnvironment _appEnvironment;

        public PetsController(ApplicationDbContext context,
                          UserManager<ApplicationUser> userManager,
                          IHostingEnvironment appEnvironment)
        {
            _userManager = userManager;
            _context = context;
            _appEnvironment = appEnvironment;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Pets
        public IActionResult Index(string searchString)
        {
            var pets = new List<Pet>();

            if (!String.IsNullOrEmpty(searchString))
            {
                pets = _context.Pets.Where(o => o.Name
                .Contains(searchString, StringComparison.InvariantCultureIgnoreCase))
                .ToList();
                return View(pets);
            }

            var attributes = _context.Pets
                .Include(p => p.GenderOfAnimal)
                .Include(p => p.SizeOfAnimal)
                .Include(p => p.TypeOfAnimal);

            return View(attributes);
        }

        // GET: Pets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _context.Pets
                .Include(p => p.GenderOfAnimal)
                .Include(p => p.SizeOfAnimal)
                .Include(p => p.TypeOfAnimal)
                .Include(p => p.PetOwners)
                .Include(p => p.VetRecords)
                .Include(p => p.PetContacts)
                .Include(p => p.ServicePets)
                .ThenInclude(x => x.NameOfService)
                .FirstOrDefaultAsync(m => m.Id == id);

            pet.PetOwners.ToList().ForEach(x => x.Owner = _context.Owners.FirstOrDefault(y => y.Id == x.OwnerId));
            pet.PetContacts.ToList().ForEach(x => x.EmergencyContact = _context.EmergencyContacts.FirstOrDefault(y => y.Id == x.EmergencyContactId));
            pet.VetRecords = pet.VetRecords.OrderByDescending(x => x.Id).Take(3).ToList();

            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        // GET: Pets/Create
        public IActionResult Create(int? id = null)
        {
            var petOwner = new PetOwner();
            if(id != null)
            {
                ViewData["animalType"] = GetAnimalType();
                ViewData["animalSize"] = GetAnimalSize();
                ViewData["animalGender"] = GetAnimalGender();

                petOwner.OwnerId = (int)id;

                var owner = _context.Owners
                    .FirstOrDefault(x => x.Id == id);
                petOwner.Owner = owner;

                return View(petOwner);
            }

            ViewData["animalType"] = GetAnimalType();
            ViewData["animalSize"] = GetAnimalSize();
            ViewData["animalGender"] = GetAnimalGender();

            return View();
        }

        // POST: Pets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PetOwner petOwner)
        {
            if (ModelState.IsValid)
            {
                petOwner.Id = 0;
                _context.Pets.Add(petOwner.Pet);
                await _context.SaveChangesAsync();

                petOwner.PetId = petOwner.Pet.Id;

                _context.PetOwners.Add(petOwner);
                await _context.SaveChangesAsync();

                var petId = petOwner.PetId;
                return RedirectToAction("Details", "Pets", new { id = petId });
            }
            return View();
        }

        public JsonResult GetOwnerList(string name)
        {
            var list = _context.Owners
                .Where(x => x.FullName.StartsWith(name, StringComparison.InvariantCultureIgnoreCase))
                .Take(10)
                .ToList();
            return Json(list);
        }

        // GET: Pets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.animalGenders = _context.AnimalGenders.ToDictionary(x => x.Id, y => y.Gender);
            ViewBag.animalSizes = _context.AnimalSizes.ToDictionary(x => x.Id, y => y.Size);
            ViewBag.animalTypes = _context.AnimalTypes.ToDictionary(x => x.Id, y => y.Animal);

            var pet = await _context.Pets.FindAsync(id);

            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        // POST: Pets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OwnerId,Name,GenderId,BirthDate,SizeId,Color1,Color2,AnimalTypeId,Breed,AmountFood,PetNote,PetImage")] Pet pet)
        {
            if (id != pet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetExists(pet.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                var petId = pet.Id;
                return RedirectToAction("Details", "Pets", new { id = petId });
            }
            return View(pet);
        }

        // GET: Pets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _context.Pets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        // POST: Pets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost("FileUpload")]
        public async Task<IActionResult> UploadImage(PetImage model)
        {
            var formFile = model.ImageFile;
            var originalFilename = Path.GetFileName(formFile.FileName);
            var newFileName = Path.GetFileNameWithoutExtension(formFile.FileName) + "_" + model.PetId + ".jpg";

            var uploadpath = Path.Combine(_appEnvironment.WebRootPath, "images");
            //using (var fileStream = new FileStream(Path.Combine(uploadpath, newFileName), FileMode.Create))
           // {
                var bitMap = new Bitmap(formFile.OpenReadStream());
                Size original = new Size(bitMap.Width, bitMap.Height);

                int maxSize = 300;

                float percent = (new List<float> { (float)maxSize / (float)original.Width, (float)maxSize / (float)original.Height }).Min();

                Size resultSize = new Size((int)Math.Floor(original.Width * percent), (int)Math.Floor(original.Height * percent));

                Bitmap target = new Bitmap(resultSize.Width, resultSize.Height);
                Graphics graphic = Graphics.FromImage(target);

                graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphic.SmoothingMode = SmoothingMode.HighQuality;
                graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphic.CompositingQuality = CompositingQuality.HighQuality;
                graphic.DrawImage(bitMap, 0, 0, resultSize.Width, resultSize.Height);


                target.Save(Path.Combine(uploadpath, newFileName), ImageFormat.Jpeg);
                //await formFile.CopyToAsync(fileStream);
                string filePath = "images\\" + newFileName;
                string baseUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            //}

            var pet = _context.Pets.FirstOrDefault(x => x.Id == model.PetId);

            if(pet != null)
            {
                pet.PetImage = newFileName;

                _context.Update(pet);
                await _context.SaveChangesAsync();
            }

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return RedirectToAction("Details", "Pets", new { id = model.PetId });
        }

        private bool PetExists(int? id)
        {
            return _context.Pets.Any(e => e.Id == id);
        }

        private List<SelectListItem> GetAnimalType()
        {
            var selectItems = _context.AnimalTypes
                .Select(program => new SelectListItem
                {
                    Text = program.Animal,
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

        private List<SelectListItem> GetAnimalSize()
        {
            var selectItems = _context.AnimalSizes
                .Select(program => new SelectListItem
                {
                    Text = program.Size,
                    Value = program.Id.ToString()
                })
                .ToList();

            selectItems.Insert(0, new SelectListItem
            {
                Text = "Choose size...",
                Value = "0"
            });
            return selectItems;
        }

        private List<SelectListItem> GetAnimalGender()
        {
            var selectItems = _context.AnimalGenders
                .Select(program => new SelectListItem
                {
                    Text = program.Gender,
                    Value = program.Id.ToString()
                })
                .ToList();

            selectItems.Insert(0, new SelectListItem
            {
                Text = "Choose gender...",
                Value = "0"
            });
            return selectItems;
        }

    }
}
