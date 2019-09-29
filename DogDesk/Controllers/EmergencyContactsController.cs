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
    public class EmergencyContactsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public EmergencyContactsController(ApplicationDbContext context,
                          UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: EmergencyContacts
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmergencyContacts.ToListAsync());
        }

        // GET: EmergencyContacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emergencyContact = await _context.EmergencyContacts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emergencyContact == null)
            {
                return NotFound();
            }

            return View(emergencyContact);
        }

        // GET: EmergencyContacts/Create
        public IActionResult Create(int PetId)
        {
            var newEContact = new PetContact();
            var pet = _context.Pets.FirstOrDefault(x => x.Id == PetId);
            newEContact.Pet = pet;

            return View(newEContact);
        }

        // POST: EmergencyContacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PetContact petContact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(petContact.EmergencyContact);
                await _context.SaveChangesAsync();

                petContact.EmergencyContactId = petContact.EmergencyContact.Id;
                _context.PetContacts.Add(petContact);
                await _context.SaveChangesAsync();

                var petId = petContact.PetId;
                return RedirectToAction("Details", "Pets", new { id = petId });
            }
            return View(petContact);
        }

        // GET: EmergencyContacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emergencyContact = await _context.EmergencyContacts.FindAsync(id);
            if (emergencyContact == null)
            {
                return NotFound();
            }
            return View(emergencyContact);
        }

        // POST: EmergencyContacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PetId,FirstName,LastName,HomePhone,CellPhone,WorkPhone")] EmergencyContact emergencyContact)
        {
            if (id != emergencyContact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emergencyContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmergencyContactExists(emergencyContact.Id))
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
            return View(emergencyContact);
        }

        // GET: EmergencyContacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emergencyContact = await _context.EmergencyContacts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emergencyContact == null)
            {
                return NotFound();
            }

            return View(emergencyContact);
        }

        // POST: EmergencyContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emergencyContact = await _context.EmergencyContacts.FindAsync(id);
            _context.EmergencyContacts.Remove(emergencyContact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmergencyContactExists(int id)
        {
            return _context.EmergencyContacts.Any(e => e.Id == id);
        }
    }
}
