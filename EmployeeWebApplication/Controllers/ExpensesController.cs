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
    public class ExpensesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ExpensesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Expenses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeExpenses>>> GetEmployeeExpenses()
        {
            return await _context.EmployeeExpenses.ToListAsync();
        }

        // GET: api/Expenses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeExpenses>> GetEmployeeExpenses(int id)
        {
            var employeeExpenses = await _context.EmployeeExpenses.FindAsync(id);

            if (employeeExpenses == null)
            {
                return NotFound();
            }

            return employeeExpenses;
        }

        // PUT: api/Expenses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeExpenses(int id, EmployeeExpenses employeeExpenses)
        {
            if (id != employeeExpenses.Id)
            {
                return BadRequest();
            }

            _context.Entry(employeeExpenses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExpensesExists(id))
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

        // POST: api/Expenses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EmployeeExpenses>> PostEmployeeExpenses(EmployeeExpenses employeeExpenses)
        {
            _context.EmployeeExpenses.Add(employeeExpenses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeExpenses", new { id = employeeExpenses.Id }, employeeExpenses);
        }

        // DELETE: api/Expenses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeExpenses>> DeleteEmployeeExpenses(int id)
        {
            var employeeExpenses = await _context.EmployeeExpenses.FindAsync(id);
            if (employeeExpenses == null)
            {
                return NotFound();
            }

            _context.EmployeeExpenses.Remove(employeeExpenses);
            await _context.SaveChangesAsync();

            return employeeExpenses;
        }

        private bool EmployeeExpensesExists(int id)
        {
            return _context.EmployeeExpenses.Any(e => e.Id == id);
        }
    }
}
