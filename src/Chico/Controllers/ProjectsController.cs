using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Chico.Models;
using Chico.Data;
using System.Security.Claims;

namespace Chico.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly chicoContext _context;

        public ProjectsController(chicoContext context)
        {
            _context = context;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            var chicoContext = _context.Project.Include(p => p.CurrencyNavigation);
            return View(await chicoContext.ToListAsync());
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .Include(p => p.CurrencyNavigation)
                .SingleOrDefaultAsync(m => m.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            ViewData["Currency"] = new SelectList(_context.Currency, "CurrencyId", "CurrencyName");
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectId,Name,CurrentMileStone,Summary,Priority,TotalBudget,Currency,StartDate,EndDate")] Project project)
        {
            var claimsIdentity = (ClaimsIdentity) User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.UserData);
            var partyId = claim?.Value;
            if (partyId == null) return BadRequest();
            if (ModelState.IsValid)
            {
                Party party = await _context.Party.FirstOrDefaultAsync(p => p.PartyId == Convert.ToInt64(partyId));
                ProjectParty pp = new ProjectParty();
                pp.Party = party;
                pp.Project = project;
                pp.OverseeingParty = null;
                pp.PartyRoleInProjectNavigation  = _context.Role.Find(1);
                pp.AssignmentDate = DateTime.Now;

                _context.Add(project);
                _context.Add(pp);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Currency"] = new SelectList(_context.Currency, "CurrencyId", "CurrencyName", project.Currency);
            return View(project);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project.SingleOrDefaultAsync(m => m.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }
            ViewData["Currency"] = new SelectList(_context.Currency, "CurrencyId", "CurrencyName", project.Currency);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectId,Name,CurrentMileStone,Summary,Priority,TotalBudget,Currency,StartDate,EndDate")] Project project)
        {
            if (id != project.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.ProjectId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["Currency"] = new SelectList(_context.Currency, "CurrencyId", "CurrencyName", project.Currency);
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .Include(p => p.CurrencyNavigation)
                .SingleOrDefaultAsync(m => m.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Project.SingleOrDefaultAsync(m => m.ProjectId == id);
            _context.Project.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProjectExists(int id)
        {
            return _context.Project.Any(e => e.ProjectId == id);
        }
    }
}
