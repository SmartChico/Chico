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
    public class OrgPersonsController : Controller
    {
        private readonly chicoContext _context;

        public OrgPersonsController(chicoContext context)
        {
            _context = context;    
        }

        // GET: OrgPersons
        public async Task<IActionResult> Index()
        {
            var chicoContext = _context.OrgPerson.Include(o => o.Org).Include(o => o.OrgRole).Include(o => o.Person);
            return View(await chicoContext.ToListAsync());
        }

        // GET: OrgPersons/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orgPerson = await _context.OrgPerson
                .Include(o => o.Org)
                .Include(o => o.OrgRole)
                .Include(o => o.Person)
                .SingleOrDefaultAsync(m => m.PersonId == id);
            if (orgPerson == null)
            {
                return NotFound();
            }

            return View(orgPerson);
        }

        // GET: OrgPersons/Create
        public IActionResult Create()
        {
            ViewData["OrgId"] = new SelectList(_context.Organization, "PartyId", "Name");
            ViewData["OrgRoleId"] = new SelectList(_context.OrganizationRole, "OrgRoleId", "Name");
            ViewData["PersonId"] = new SelectList(_context.Person, "PartyId", "FirstName");
            return View();
        }

        // POST: OrgPersons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonId,OrgId,OrgRoleId,SharesOwned,AffiliationStartDate")] OrgPerson orgPerson)
        {
            if (ModelState.IsValid)
            {
                
                _context.Add(orgPerson);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["OrgId"] = new SelectList(_context.Organization, "PartyId", "Name", orgPerson.OrgId);
            ViewData["OrgRoleId"] = new SelectList(_context.OrganizationRole, "OrgRoleId", "Name", orgPerson.OrgRoleId);
            ViewData["PersonId"] = new SelectList(_context.Person, "PartyId", "FirstName", orgPerson.PersonId);
            return View(orgPerson);
        }

        // GET: OrgPersons/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orgPerson = await _context.OrgPerson.SingleOrDefaultAsync(m => m.PersonId == id);
            if (orgPerson == null)
            {
                return NotFound();
            }
            ViewData["OrgId"] = new SelectList(_context.Organization, "PartyId", "Name", orgPerson.OrgId);
            ViewData["OrgRoleId"] = new SelectList(_context.OrganizationRole, "OrgRoleId", "Name", orgPerson.OrgRoleId);
            ViewData["PersonId"] = new SelectList(_context.Person, "PartyId", "FirstName", orgPerson.PersonId);
            return View(orgPerson);
        }

        // POST: OrgPersons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("PersonId,OrgId,OrgRoleId,SharesOwned,AffiliationStartDate")] OrgPerson orgPerson)
        {
            if (id != orgPerson.PersonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orgPerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrgPersonExists(orgPerson.PersonId))
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
            ViewData["OrgId"] = new SelectList(_context.Organization, "PartyId", "Name", orgPerson.OrgId);
            ViewData["OrgRoleId"] = new SelectList(_context.OrganizationRole, "OrgRoleId", "Name", orgPerson.OrgRoleId);
            ViewData["PersonId"] = new SelectList(_context.Person, "PartyId", "FirstName", orgPerson.PersonId);
            return View(orgPerson);
        }

        // GET: OrgPersons/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orgPerson = await _context.OrgPerson
                .Include(o => o.Org)
                .Include(o => o.OrgRole)
                .Include(o => o.Person)
                .SingleOrDefaultAsync(m => m.PersonId == id);
            if (orgPerson == null)
            {
                return NotFound();
            }

            return View(orgPerson);
        }

        // POST: OrgPersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var orgPerson = await _context.OrgPerson.SingleOrDefaultAsync(m => m.PersonId == id);
            _context.OrgPerson.Remove(orgPerson);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool OrgPersonExists(long id)
        {
            return _context.OrgPerson.Any(e => e.PersonId == id);
        }
    }
}
