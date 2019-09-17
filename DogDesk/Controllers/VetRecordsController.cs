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
    public class VetRecordsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public VetRecordsController(ApplicationDbContext context,
                          UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: VetRecords
        public IActionResult Index()
        {
            var vetRecord = _context.VetRecords
                .Include(x => x.Pet)
                .Where(x => x.Id == x.PetId);

            return View(vetRecord);
        }

        // GET: VetRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vetRecord = await _context.VetRecords
                .Include(x => x.Pet)
                .Where(x => x.Id == x.PetId)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vetRecord == null)
            {
                return NotFound();
            }

            return View(vetRecord);
        }

        // GET: VetRecords/Create
        public IActionResult Create(int? PetId = null)
        {
            var petRecord = new VetRecord();

            if(PetId != null)
            {
                petRecord.Id = (int)PetId;

                var pet = _context.Pets
                    .FirstOrDefault(x => x.Id == PetId);
                petRecord.Pet = pet;

                return View(petRecord);
            }

            return View();
        }

        // POST: VetRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PetId,VetName,StreetAddress,City,State,ZipCode,WorkPhone,Allergy,Altered,Rabies,Bordetella")] VetRecord vetRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vetRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vetRecord);
        }

        // GET: VetRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petName = _context.VetRecords
                .Include(x => x.Pet)
                .FirstOrDefault(x => x.Id == x.PetId);

            var vetRecord = await _context.VetRecords.FindAsync(id);

            if (vetRecord == null)
            {
                return NotFound();
            }
            return View(vetRecord);
        }

        // POST: VetRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PetId,VetName,StreetAddress,City,State,ZipCode,WorkPhone,Allergy,Altered,Rabies,Bordetella")] VetRecord vetRecord)
        {
            if (id != vetRecord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vetRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VetRecordExists(vetRecord.Id))
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
            return View(vetRecord);
        }

        // GET: VetRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vetRecord = await _context.VetRecords
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vetRecord == null)
            {
                return NotFound();
            }

            return View(vetRecord);
        }

        // POST: VetRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vetRecord = await _context.VetRecords.FindAsync(id);
            _context.VetRecords.Remove(vetRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VetRecordExists(int id)
        {
            return _context.VetRecords.Any(e => e.Id == id);
        }
    }
}
