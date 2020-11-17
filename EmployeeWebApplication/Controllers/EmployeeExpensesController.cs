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
    public class EmployeeExpensesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeExpensesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeExpenses
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployeeExpenses.ToListAsync());
        }

        // GET: EmployeeExpenses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeExpenses = await _context.EmployeeExpenses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeExpenses == null)
            {
                return NotFound();
            }

            return View(employeeExpenses);
        }

        // GET: EmployeeExpenses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeExpenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Reimbursement,CardNumber,CardEnabled,CurrentBalance")] EmployeeExpenses employeeExpenses)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeExpenses);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeExpenses);
        }

        // GET: EmployeeExpenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeExpenses = await _context.EmployeeExpenses.FindAsync(id);
            if (employeeExpenses == null)
            {
                return NotFound();
            }
            return View(employeeExpenses);
        }

        // POST: EmployeeExpenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Reimbursement,CardNumber,CardEnabled,CurrentBalance")] EmployeeExpenses employeeExpenses)
        {
            if (id != employeeExpenses.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeExpenses);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExpensesExists(employeeExpenses.Id))
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
            return View(employeeExpenses);
        }

        // GET: EmployeeExpenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeExpenses = await _context.EmployeeExpenses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeExpenses == null)
            {
                return NotFound();
            }

            return View(employeeExpenses);
        }

        // POST: EmployeeExpenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeExpenses = await _context.EmployeeExpenses.FindAsync(id);
            _context.EmployeeExpenses.Remove(employeeExpenses);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExpensesExists(int id)
        {
            return _context.EmployeeExpenses.Any(e => e.Id == id);
        }
    }
}
