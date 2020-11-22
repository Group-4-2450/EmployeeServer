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

        [Route("Employees/Details/{employeeId:guid}/EmergencyContacts")]
        public async Task<IActionResult> Index(string employeeId)
        {
            var emergencyContacts = await _context.EmployeeEmergencyContact
                .Where(contact => contact.EmployeeId == employeeId)
                .ToListAsync();

            ViewBag.EmployeeId = employeeId;
            return View(emergencyContacts);
        }

        [Route("Employees/Details/{employeeId:guid}/EmergencyContacts/Details/{emergencyContactId:int}")]
        public async Task<IActionResult> Details(string employeeId, int emergencyContactId)
        {
            var employeeEmergencyContact = await LoadEmployeeEmergencyContactAsync(employeeId, emergencyContactId);
            if (employeeEmergencyContact == null)
            {
                return NotFound();
            }

            return View(employeeEmergencyContact);
        }

        [Route("Employees/Details/{employeeId:guid}/EmergencyContacts/Create")]
        public IActionResult Create(string employeeId)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Employees/Details/{employeeId:guid}/EmergencyContacts/Create")]
        public async Task<IActionResult> Create(string employeeId, [Bind("Id,EmployeeId,FirstName,LastName,PhoneNumber,Email,PhoneType,RelationshipToEmployee")] EmployeeEmergencyContact employeeEmergencyContact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeEmergencyContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new
                {
                    employeeId
                });
            }
            return View(employeeEmergencyContact);
        }

        [Route("Employees/Details/{employeeId:guid}/EmergencyContacts/Edit/{emergencyContactId:int}")]
        public async Task<IActionResult> Edit(string employeeId, int emergencyContactId)
        {
            var employeeEmergencyContact = await LoadEmployeeEmergencyContactAsync(employeeId, emergencyContactId);
            if (employeeEmergencyContact == null)
            {
                return NotFound();
            }
            return View(employeeEmergencyContact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Employees/Details/{employeeId:guid}/EmergencyContacts/Edit/{emergencyContactId:int}")]
        public async Task<IActionResult> Edit(string employeeId, int emergencyContactId, [Bind("Id,EmployeeId,FirstName,LastName,PhoneNumber,Email,PhoneType,RelationshipToEmployee")] EmployeeEmergencyContact employeeEmergencyContact)
        {
            if (employeeId != employeeEmergencyContact.EmployeeId && emergencyContactId == employeeEmergencyContact.Id)
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
                    if (!await EmployeeEmergencyContactExistsAsync(employeeId, emergencyContactId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new
                {
                    employeeId
                });
            }
            return View(employeeEmergencyContact);
        }

        [Route("Employees/Details/{employeeId:guid}/EmergencyContacts/Delete/{emergencyContactId:int}")]
        public async Task<IActionResult> Delete(string employeeId, int emergencyContactId)
        {
            var employeeEmergencyContact = await LoadEmployeeEmergencyContactAsync(employeeId, emergencyContactId);
            if (employeeEmergencyContact == null)
            {
                return NotFound();
            }

            return View(employeeEmergencyContact);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Employees/Details/{employeeId:guid}/EmergencyContacts/Delete/{emergencyContactId:int}")]
        public async Task<IActionResult> DeleteConfirmed(string employeeId, int emergencyContactId)
        {
            var employeeEmergencyContact = await LoadEmployeeEmergencyContactAsync(employeeId, emergencyContactId);
            _context.EmployeeEmergencyContact.Remove(employeeEmergencyContact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new
            {
                employeeId
            });
        }

        private async Task<bool> EmployeeEmergencyContactExistsAsync(string employeeId, int emergencyContactId)
        {
            return await _context.EmployeeEmergencyContact
                .AnyAsync(contact => contact.EmployeeId == employeeId && contact.Id == emergencyContactId);
        }

        private async Task<EmployeeEmergencyContact> LoadEmployeeEmergencyContactAsync(string employeeId, int emergencyContactId)
        {
            var employeeEmergencyContact = await _context.EmployeeEmergencyContact
                .FirstOrDefaultAsync(contact => contact.EmployeeId == employeeId && contact.Id == emergencyContactId);

            if (employeeEmergencyContact == null)
            {
                return null;
            }

            return employeeEmergencyContact;
        }
    }
}
