using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeWebApplication.Data;
using EmployeeWebApplication.Models;

namespace EmployeeWebApplication.Controllers
{
    public class EmployeeEmergencyContactsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeEmergencyContactsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeEmergencyContacts
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployeeEmergencyContact.ToListAsync());
        }

        // GET: EmployeeEmergencyContacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeEmergencyContact = await _context.EmployeeEmergencyContact
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeEmergencyContact == null)
            {
                return NotFound();
            }

            return View(employeeEmergencyContact);
        }

        // GET: EmployeeEmergencyContacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeEmergencyContacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,PhoneNumber,Email,PhoneType,RelationshipToEmployee")] EmployeeEmergencyContact employeeEmergencyContact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeEmergencyContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeEmergencyContact);
        }

        // GET: EmployeeEmergencyContacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeEmergencyContact = await _context.EmployeeEmergencyContact.FindAsync(id);
            if (employeeEmergencyContact == null)
            {
                return NotFound();
            }
            return View(employeeEmergencyContact);
        }

        // POST: EmployeeEmergencyContacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,PhoneNumber,Email,PhoneType,RelationshipToEmployee")] EmployeeEmergencyContact employeeEmergencyContact)
        {
            if (id != employeeEmergencyContact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeEmergencyContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeEmergencyContactExists(employeeEmergencyContact.Id))
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
            return View(employeeEmergencyContact);
        }

        // GET: EmployeeEmergencyContacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeEmergencyContact = await _context.EmployeeEmergencyContact
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeEmergencyContact == null)
            {
                return NotFound();
            }

            return View(employeeEmergencyContact);
        }

        // POST: EmployeeEmergencyContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeEmergencyContact = await _context.EmployeeEmergencyContact.FindAsync(id);
            _context.EmployeeEmergencyContact.Remove(employeeEmergencyContact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeEmergencyContactExists(int id)
        {
            return _context.EmployeeEmergencyContact.Any(e => e.Id == id);
        }
    }
}
