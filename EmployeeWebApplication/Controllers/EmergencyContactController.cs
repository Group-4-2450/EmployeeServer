using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeWebApplication.Data;
using EmployeeWebApplication.Models;

namespace EmployeeWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmergencyContactController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmergencyContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EmergencyContact
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeEmergencyContact>>> GetEmployeeEmergencyContact()
        {
            return await _context.EmployeeEmergencyContact.ToListAsync();
        }

        // GET: api/EmergencyContact/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeEmergencyContact>> GetEmployeeEmergencyContact(int id)
        {
            var employeeEmergencyContact = await _context.EmployeeEmergencyContact.FindAsync(id);

            if (employeeEmergencyContact == null)
            {
                return NotFound();
            }

            return employeeEmergencyContact;
        }

        // PUT: api/EmergencyContact/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeEmergencyContact(int id, EmployeeEmergencyContact employeeEmergencyContact)
        {
            if (id != employeeEmergencyContact.Id)
            {
                return BadRequest();
            }

            _context.Entry(employeeEmergencyContact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeEmergencyContactExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EmergencyContact
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EmployeeEmergencyContact>> PostEmployeeEmergencyContact(EmployeeEmergencyContact employeeEmergencyContact)
        {
            _context.EmployeeEmergencyContact.Add(employeeEmergencyContact);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeEmergencyContact", new { id = employeeEmergencyContact.Id }, employeeEmergencyContact);
        }

        // DELETE: api/EmergencyContact/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeEmergencyContact>> DeleteEmployeeEmergencyContact(int id)
        {
            var employeeEmergencyContact = await _context.EmployeeEmergencyContact.FindAsync(id);
            if (employeeEmergencyContact == null)
            {
                return NotFound();
            }

            _context.EmployeeEmergencyContact.Remove(employeeEmergencyContact);
            await _context.SaveChangesAsync();

            return employeeEmergencyContact;
        }

        private bool EmployeeEmergencyContactExists(int id)
        {
            return _context.EmployeeEmergencyContact.Any(e => e.Id == id);
        }
    }
}
