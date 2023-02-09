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
    public class OrderTicketsController : Controller
    {
        private readonly Film_Equipment_RentalsContext _context;

        public OrderTicketsController(Film_Equipment_RentalsContext context)
        {
            _context = context;
        }

        // GET: OrderTickets
        public async Task<IActionResult> Index()
        {
            var film_Equipment_RentalsContext = _context.OrderTicket.Include(o => o.EquipObj);
            return View(await film_Equipment_RentalsContext.ToListAsync());
        }

        // GET: OrderTickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrderTicket == null)
            {
                return NotFound();
            }

            var orderTicket = await _context.OrderTicket
                .Include(o => o.EquipObj)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderTicket == null)
            {
                return NotFound();
            }

            return View(orderTicket);
        }

        // GET: OrderTickets/Create
        public IActionResult Create()
        {
            ViewData["EquipmentInventoryId"] = new SelectList(_context.EquipmentInventory, "Id", "Name");
            return View();
        }

        // POST: OrderTickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EquipmentInventoryId,Email,Quantity,Total,Status")] OrderTicket orderTicket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderTicket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipmentInventoryId"] = new SelectList(_context.EquipmentInventory, "Id", "Name", orderTicket.EquipmentInventoryId);
            return View(orderTicket);
        }

        // GET: OrderTickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrderTicket == null)
            {
                return NotFound();
            }

            var orderTicket = await _context.OrderTicket.FindAsync(id);
            if (orderTicket == null)
            {
                return NotFound();
            }
            ViewData["EquipmentInventoryId"] = new SelectList(_context.EquipmentInventory, "Id", "Name", orderTicket.EquipmentInventoryId);
            return View(orderTicket);
        }

        // POST: OrderTickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EquipmentInventoryId,Email,Quantity,Total,Status")] OrderTicket orderTicket)
        {
            if (id != orderTicket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderTicket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderTicketExists(orderTicket.Id))
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
            ViewData["EquipmentInventoryId"] = new SelectList(_context.EquipmentInventory, "Id", "Name", orderTicket.EquipmentInventoryId);
            return View(orderTicket);
        }

        // GET: OrderTickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrderTicket == null)
            {
                return NotFound();
            }

            var orderTicket = await _context.OrderTicket
                .Include(o => o.EquipObj)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderTicket == null)
            {
                return NotFound();
            }

            return View(orderTicket);
        }

        // POST: OrderTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrderTicket == null)
            {
                return Problem("Entity set 'Film_Equipment_RentalsContext.OrderTicket'  is null.");
            }
            var orderTicket = await _context.OrderTicket.FindAsync(id);
            if (orderTicket != null)
            {
                _context.OrderTicket.Remove(orderTicket);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderTicketExists(int id)
        {
          return _context.OrderTicket.Any(e => e.Id == id);
        }

        //Method to check whether stock for ticket available.

        //Method to approve ticket.

        //Method to disapprove ticket.
    }
}
