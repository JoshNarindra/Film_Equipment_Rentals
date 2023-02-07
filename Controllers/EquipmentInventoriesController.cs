using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Film_Equipment_Rentals.Data;
using Film_Equipment_Rentals.Models;

namespace Film_Equipment_Rentals.Controllers
{
    public class EquipmentInventoriesController : Controller
    {
        private readonly Film_Equipment_RentalsContext _context;

        public EquipmentInventoriesController(Film_Equipment_RentalsContext context)
        {
            _context = context;
        }

        // GET: EquipmentInventories
        public async Task<IActionResult> Index()
        {
              return View(await _context.EquipmentInventory.ToListAsync());
        }

        // GET: EquipmentInventories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EquipmentInventory == null)
            {
                return NotFound();
            }

            var equipmentInventory = await _context.EquipmentInventory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipmentInventory == null)
            {
                return NotFound();
            }

            return View(equipmentInventory);
        }

        // GET: EquipmentInventories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EquipmentInventories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type,Price,Inventory")] EquipmentInventory equipmentInventory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipmentInventory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(equipmentInventory);
        }

        // GET: EquipmentInventories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EquipmentInventory == null)
            {
                return NotFound();
            }

            var equipmentInventory = await _context.EquipmentInventory.FindAsync(id);
            if (equipmentInventory == null)
            {
                return NotFound();
            }
            return View(equipmentInventory);
        }

        // POST: EquipmentInventories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,Price,Inventory")] EquipmentInventory equipmentInventory)
        {
            if (id != equipmentInventory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipmentInventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipmentInventoryExists(equipmentInventory.Id))
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
            return View(equipmentInventory);
        }

        // GET: EquipmentInventories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EquipmentInventory == null)
            {
                return NotFound();
            }

            var equipmentInventory = await _context.EquipmentInventory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipmentInventory == null)
            {
                return NotFound();
            }

            return View(equipmentInventory);
        }

        // POST: EquipmentInventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EquipmentInventory == null)
            {
                return Problem("Entity set 'Film_Equipment_RentalsContext.EquipmentInventory'  is null.");
            }
            var equipmentInventory = await _context.EquipmentInventory.FindAsync(id);
            if (equipmentInventory != null)
            {
                _context.EquipmentInventory.Remove(equipmentInventory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipmentInventoryExists(int id)
        {
          return _context.EquipmentInventory.Any(e => e.Id == id);
        }
    }
}
