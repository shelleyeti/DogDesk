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

namespace DogDesk
{
    public class OwnersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public OwnersController(ApplicationDbContext context,
                          UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Owners
        public async Task<IActionResult> Index(string searchString)
        {
            var owners = new List<Owner>();

            if (!String.IsNullOrEmpty(searchString))
            {
                owners = _context.Owners.Where(o => o.FullName
                .Contains(searchString, StringComparison.InvariantCultureIgnoreCase))
                .ToList();
                return View(owners);
            }

            return View(await _context.Owners.ToListAsync());
        }

        // GET: Owners Existing
        public IActionResult AddOwnerExisting(string searchString, int? PetId)
        {
            var owners = _context.Owners
                    .Include(o => o.PetOwners)
                    .ToList();
            if (PetId != null)
            {
                ViewData["PetId"] = PetId;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                owners = owners
                    .Where(o => o.FullName.Contains(searchString, StringComparison.InvariantCultureIgnoreCase)).ToList();
                return View(owners);
            }

            return View(owners);
        }

        // POST: Owners/AddOwnerExisting
        [HttpPost]
        public async Task<IActionResult> AddOwnerExisting(PetOwner petOwner)
        {
            _context.PetOwners.Add(petOwner);
            await _context.SaveChangesAsync();

            var petId = petOwner.PetId;
            return RedirectToAction("Details", "Pets", new { id = petId });
        }

        // POST: Owners/Delete/ExistingOwner
        [HttpPost]
        public async Task<IActionResult> DeleteExisting(int id)
        {
            var petOwner = await _context.PetOwners.FindAsync(id);
            _context.PetOwners.Remove(petOwner);
            await _context.SaveChangesAsync();

            var petId = petOwner.PetId;
            return RedirectToAction("Details", "Pets", new { id = petId });
        }

        // GET: Owners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _context.Owners
                .Include(p => p.PetOwners)
                .FirstOrDefaultAsync(m => m.Id == id);

            owner.PetOwners.ToList().ForEach(x => x.Pet = _context.Pets.FirstOrDefault(y => y.Id == x.PetId));

            if (owner == null)
            {
                return NotFound();
            }

            return View(owner);
        }

        // GET: Owners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Owners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,StreetAddress,City,State,ZipCode,HomePhone,CellPhone,WorkPhone")] Owner owner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(owner);
                await _context.SaveChangesAsync();
                var ownerId = owner.Id;
                return RedirectToAction("Create", "Pets", new { id = ownerId });
            }
            return View(owner);
        }

        // GET: Owners/AddOwner
        public IActionResult AddOwner(int PetId)
        {
            var newPetOwner = new PetOwner();
            var pet = _context.Pets.FirstOrDefault(x => x.Id == PetId);
            newPetOwner.Pet = pet;

            return View(newPetOwner);
        }

        // POST: Owners/AddOwner
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOwner(PetOwner petOwner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(petOwner.Owner);
                await _context.SaveChangesAsync();

                petOwner.OwnerId = petOwner.Owner.Id;
                _context.PetOwners.Add(petOwner);
                await _context.SaveChangesAsync();

                var petId = petOwner.PetId;
                return RedirectToAction("Details", "Pets", new { id = petId });
            }
            return View(petOwner);
        }

        // GET: Owners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _context.Owners.FindAsync(id);

            if (owner == null)
            {
                return NotFound();
            }
            return View(owner);
        }

        // POST: Owners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,FirstName,LastName,StreetAddress,City,State,ZipCode,HomePhone,CellPhone,WorkPhone")] Owner owner)
        {
            if (id != owner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(owner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OwnerExists(owner.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(owner);
        }

        // GET: Owners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _context.Owners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (owner == null)
            {
                return NotFound();
            }

            return View(owner);
        }

        // POST: Owners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var owner = await _context.Owners.FindAsync(id);
            _context.Owners.Remove(owner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OwnerExists(int? id)
        {
            return _context.Owners.Any(e => e.Id == id);
        }
    }
}
