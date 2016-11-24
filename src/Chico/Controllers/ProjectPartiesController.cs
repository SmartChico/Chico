using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Chico.Models;

namespace Chico.Controllers
{
    public class ProjectPartiesController : Controller
    {
        private readonly chicoContext _context;

        public ProjectPartiesController(chicoContext context)
        {
            _context = context;    
        }

        // GET: ProjectParties
        public async Task<IActionResult> Index()
        {
            var chicoContext = _context.ProjectParty.Include(p => p.OverseeingParty).Include(p => p.Party).Include(p => p.PartyRoleInProjectNavigation).Include(p => p.Project);
            return View(await chicoContext.ToListAsync());
        }

        // GET: ProjectParties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectParty = await _context.ProjectParty
                .Include(p => p.OverseeingParty)
                .Include(p => p.Party)
                .Include(p => p.PartyRoleInProjectNavigation)
                .Include(p => p.Project)
                .SingleOrDefaultAsync(m => m.ProjectId == id);
            if (projectParty == null)
            {
                return NotFound();
            }

            return View(projectParty);
        }

        // GET: ProjectParties/Create
        public IActionResult Create()
        {
            ViewData["OverseeingPartyId"] = new SelectList(_context.Party, "PartyId", "PartyId");
            ViewData["PartyId"] = new SelectList(_context.Party, "PartyId", "PartyId");
            ViewData["PartyRoleInProject"] = new SelectList(_context.Role, "RoleId", "Name");
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "Name");
            return View();
        }

        // POST: ProjectParties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectId,PartyId,PartyRoleInProject,AssignmentDate,OverseeingPartyId")] ProjectParty projectParty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectParty);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["OverseeingPartyId"] = new SelectList(_context.Party, "PartyId", "PartyId", projectParty.OverseeingPartyId);
            ViewData["PartyId"] = new SelectList(_context.Party, "PartyId", "PartyId", projectParty.PartyId);
            ViewData["PartyRoleInProject"] = new SelectList(_context.Role, "RoleId", "Name", projectParty.PartyRoleInProject);
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "Name", projectParty.ProjectId);
            return View(projectParty);
        }

        // GET: ProjectParties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectParty = await _context.ProjectParty.SingleOrDefaultAsync(m => m.ProjectId == id);
            if (projectParty == null)
            {
                return NotFound();
            }
            ViewData["OverseeingPartyId"] = new SelectList(_context.Party, "PartyId", "PartyId", projectParty.OverseeingPartyId);
            ViewData["PartyId"] = new SelectList(_context.Party, "PartyId", "PartyId", projectParty.PartyId);
            ViewData["PartyRoleInProject"] = new SelectList(_context.Role, "RoleId", "Name", projectParty.PartyRoleInProject);
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "Name", projectParty.ProjectId);
            return View(projectParty);
        }

        // POST: ProjectParties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectId,PartyId,PartyRoleInProject,AssignmentDate,OverseeingPartyId")] ProjectParty projectParty)
        {
            if (id != projectParty.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectParty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectPartyExists(projectParty.ProjectId))
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
            ViewData["OverseeingPartyId"] = new SelectList(_context.Party, "PartyId", "PartyId", projectParty.OverseeingPartyId);
            ViewData["PartyId"] = new SelectList(_context.Party, "PartyId", "PartyId", projectParty.PartyId);
            ViewData["PartyRoleInProject"] = new SelectList(_context.Role, "RoleId", "Name", projectParty.PartyRoleInProject);
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "Name", projectParty.ProjectId);
            return View(projectParty);
        }

        // GET: ProjectParties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectParty = await _context.ProjectParty
                .Include(p => p.OverseeingParty)
                .Include(p => p.Party)
                .Include(p => p.PartyRoleInProjectNavigation)
                .Include(p => p.Project)
                .SingleOrDefaultAsync(m => m.ProjectId == id);
            if (projectParty == null)
            {
                return NotFound();
            }

            return View(projectParty);
        }

        // POST: ProjectParties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectParty = await _context.ProjectParty.SingleOrDefaultAsync(m => m.ProjectId == id);
            _context.ProjectParty.Remove(projectParty);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProjectPartyExists(int id)
        {
            return _context.ProjectParty.Any(e => e.ProjectId == id);
        }
    }
}
