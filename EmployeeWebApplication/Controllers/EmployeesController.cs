﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeWebApplication.Authorization;
using EmployeeWebApplication.Data;
using EmployeeWebApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Net.Mime;

namespace EmployeeWebApplication.Controllers
{

    public class EmployeesController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<EmployeesController> _logger;
        private readonly UserManager<Employee> _userManager;

        public EmployeesController(UserManager<Employee> userManager,
            IAuthorizationService authorizationService,
            ApplicationDbContext context,
            ILogger<EmployeesController> logger
        )
        {
            _userManager = userManager;
            _authorizationService = authorizationService;
            _context = context;
            _logger = logger;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var users = await _context.Users
                .OrderBy(user => user.LastName.ToLower())
                .ThenBy(user => user.FirstName.ToLower())
                .ToListAsync();

            var filteredUsers = new List<Employee>();

            foreach (var user in users)
            {
                var authorizationStatus = await _authorizationService
                    .AuthorizeAsync(User, user, EmployeeOperations.Read);

                if (authorizationStatus.Succeeded)
                {
                    filteredUsers.Add(user);
                }
            }

            return View(filteredUsers);
        }

        public async Task<IActionResult> Export()
        {
            var authorizationResult = await _authorizationService
                .AuthorizeAsync(User, new Employee(), EmployeeOperations.DownloadAllEmployees);

            if (!authorizationResult.Succeeded)
            {
                return Forbid();
            }

            var exporter = new EmployeeExporter(_userManager);
            var csv = await exporter.ExportAsCsvAsync(_context.Users);
            var csvBytes = Encoding.UTF8.GetBytes(csv);

            return File(csvBytes, "text/csv", "employees.csv");
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            var authorizationResult = await _authorizationService
                .AuthorizeAsync(User, employee, EmployeeOperations.Read);

            if (authorizationResult.Succeeded)
            {
                return View(employee);
            }
            else
            {
                return Forbid();
            }
        }

        // GET: Employees/Create
        public async Task<IActionResult> Create()
        {
            var authorizationResult = await _authorizationService
                .AuthorizeAsync(User, new Employee(), EmployeeOperations.Create);            

            if (authorizationResult.Succeeded)
            {
                return View();
            }
            else
            {
                return Forbid();
            }
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeEditViewModel employeeEdits, IFormCollection form)
        {
            var authorizationResult = await _authorizationService
                .AuthorizeAsync(User, new Employee(), EmployeeOperations.Create);

            if (authorizationResult.Succeeded)
            {
                if (ModelState.IsValid)
                {
                    employeeEdits.Id = Guid.NewGuid().ToString();

                    var employee = new Employee();
                    employeeEdits.ApplyTo(employee);

                    _context.Add(employee);
                    await _context.SaveChangesAsync();

                    string role = Request.Form["Role"].ToString();
                    
                    var addRole = await _userManager.AddToRoleAsync(employee, role);

                    return RedirectToAction(nameof(Index));
                }
                return View(employeeEdits);
            }
            else
            {
                return Forbid();
            }

        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Users.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            var authorizationResult = await _authorizationService
                .AuthorizeAsync(User, employee, EmployeeOperations.Update);

            if (authorizationResult.Succeeded)
            {
                return View(new EmployeeEditViewModel(employee));
            }
            else
            {
                return Forbid();
            }
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, EmployeeEditViewModel employeeEdits)
        {
            if (id != employeeEdits.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var employee = await _context.Users.FindAsync(id);

                    var authorizationResult = await _authorizationService
                        .AuthorizeAsync(User, employee, EmployeeOperations.Update);

                    if (authorizationResult.Succeeded)
                    {
                        employeeEdits.ApplyTo(employee);

                        _context.Update(employee);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        return Forbid();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employeeEdits.Id))
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

            return View(employeeEdits);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            var authorizationResult = await _authorizationService
                .AuthorizeAsync(User, employee, EmployeeOperations.Delete);

            if (authorizationResult.Succeeded)
            {
                return View(employee);
            }
            else
            {
                return Forbid();
            }
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var employee = await _context.Users.FindAsync(id);

            var authorizationResult = await _authorizationService
                .AuthorizeAsync(User, employee, EmployeeOperations.Delete);

            if (authorizationResult.Succeeded)
            {
                _context.Users.Remove(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return Forbid();
            }
        }

        private bool EmployeeExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
