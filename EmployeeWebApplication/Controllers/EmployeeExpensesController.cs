using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeWebApplication.Data;
using EmployeeWebApplication.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using EmployeeWebApplication.Authorization;

namespace EmployeeWebApplication.Controllers
{
    
    public class EmployeeExpensesController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly ApplicationDbContext _context;

        public EmployeeExpensesController(IAuthorizationService authorizationService, ApplicationDbContext context)
        {
            _authorizationService = authorizationService;
            _context = context;
        }

        // GET: EmployeeExpenses
        [Route("Employees/Details/{employeeId:guid}/EmployeeExpenses")]
        public async Task<IActionResult> Index(string employeeId)
        {
            var authorizationResult = await _authorizationService
                .AuthorizeAsync(User, _context.Users.Find(employeeId), EmployeeOperations.ListExpenses);

            if (authorizationResult.Succeeded)
            {
                var employeeExpenses = await _context.EmployeeExpenses
                    .Where(contact => contact.EmployeeId == employeeId)
                    .ToListAsync();

                ViewBag.EmployeeId = employeeId;
                return View(employeeExpenses);
            }
            else
            {
                return Forbid();
            }
        }

        // GET: EmployeeExpenses/Details/5
        [Route("Employees/Details/{employeeId:guid}/EmployeeExpenses/Details/{employeeExpenseId:int}")]
        public async Task<IActionResult> Details(string employeeId, int employeeExpenseId)
        {

            var employeeExpenseReport = await LoadEmployeeExpenseAsync(employeeId, employeeExpenseId);
            if (employeeExpenseReport == null)
            {
                return NotFound();
            }

            return View(employeeExpenseReport);
        }


        // GET: EmployeeExpenses/Create
        [Route("Employees/Details/{employeeId:guid}/EmployeeExpenses/Create")]
        public IActionResult Create(string employeeId)
        {
            return View();
        }

        // POST: EmployeeExpenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Employees/Details/{employeeId:guid}/EmployeeExpenses/Create")]
        public async Task<IActionResult> Create(string employeeId, [Bind("Id,EmployeeId,Reimbursement,CardNumber,CardEnabled,CurrentBalance")] EmployeeExpenses employeeExpenses)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeExpenses);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { 
                    employeeId
                });
            }
            return View(employeeExpenses);
        }

        // GET: EmployeeExpenses/Edit/5
        [Route("Employees/Details/{employeeId:guid}/EmployeeExpenses/Edit/{employeeExpenseId:int}")]
        public async Task<IActionResult> Edit(string employeeId, int employeeExpenseId)
        {
            var employeeExpenseReport = await LoadEmployeeExpenseAsync(employeeId, employeeExpenseId);
            if (employeeExpenseReport == null)
            {
                return NotFound();
            }

            return View(employeeExpenseReport);
        }

        // POST: EmployeeExpenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Employees/Details/{employeeId:guid}/EmployeeExpenses/Edit/{employeeExpenseId:int}")]
        public async Task<IActionResult> Edit(string employeeId, int employeeExpenseId, [Bind("Id,EmployeeId,Reimbursement,CardNumber,CardEnabled,CurrentBalance")] EmployeeExpenses employeeExpenses)
        {
            if (employeeId != employeeExpenses.EmployeeId && employeeExpenseId != employeeExpenses.Id)
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
                    if (!await EmployeeEmergencyContactExistsAsync(employeeId, employeeExpenseId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { 
                    employeeId
                });
            }
            return View(employeeExpenses);
        }

        // GET: EmployeeExpenses/Delete/5
        [Route("Employees/Details/{employeeId:guid}/EmployeeExpenses/Delete/{employeeExpenseId:int}")]
        public async Task<IActionResult> Delete(string employeeId, int employeeExpenseId)
        {
            var employeeExpenseRecord = await LoadEmployeeExpenseAsync(employeeId, employeeExpenseId);

            if (employeeExpenseRecord == null)
            {
                return NotFound();
            }

            return View(employeeExpenseRecord);
        }

        // POST: EmployeeExpenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Employees/Details/{employeeId:guid}/EmployeeExpenses/Delete/{employeeExpenseId:int}")]
        public async Task<IActionResult> DeleteConfirmed(string employeeId, int employeeExpenseId)
        {
            var employeeExpenses = await LoadEmployeeExpenseAsync(employeeId, employeeExpenseId);
            _context.EmployeeExpenses.Remove(employeeExpenses);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index),new {
                employeeId
            });
        }

        private async Task<bool> EmployeeEmergencyContactExistsAsync(string employeeId, int expenseid)
        {
            return await _context.EmployeeExpenses
                   .AnyAsync(contact => contact.EmployeeId == employeeId && contact.Id == expenseid);
        }

        private async Task<EmployeeExpenses> LoadEmployeeExpenseAsync(string employeeId, int expenseId)
        {
            var employeeExpenseRecord = await _context.EmployeeExpenses
                .FirstOrDefaultAsync(expense => expense.EmployeeId == employeeId && expense.Id == expenseId);

            if (employeeExpenseRecord == null)
            {
                return null;
            }

            return employeeExpenseRecord;
        }
    }
}
