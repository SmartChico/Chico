using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Chico.Models;
using Microsoft.AspNetCore.Authorization;

namespace Chico.Controllers
{
    public class OrganizationsController : Controller
    {
        private readonly chicoContext _context;

        public OrganizationsController(chicoContext context)
        {
            _context = context;    
        }

        // GET: Organizations
        public async Task<IActionResult> Index()
        {
            var chicoContext = _context.Organization.Where(o => o.IncludeInListing==true);
            return View(await chicoContext.ToListAsync());
        }

        // GET: Organizations/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organization = await _context.Organization.SingleOrDefaultAsync(m => m.PartyId == id);
            if (organization == null)
            {
                return NotFound();
            }

            return View(organization);
        }

        // GET: Organizations/Create
        public IActionResult Create()
        {
            ViewData["EntityTypeId"] = new SelectList(_context.EntityType, "EntityTypeId", "Name");
            ViewData["Naicscode"] = new SelectList(_context.Naics, "Description", "Description");
            ViewData["PartyId"] = new SelectList(_context.Party, "PartyId", "PartyId");
            return View();
        }

        // POST: Organizations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PartyId,ActiveStatus,ChicoSignUpDate,EntityTypeId,EstablishmentDate,IncludeInListing,ModifiedDate,Naicscode,Name,NumberOfEmployees,Purpose,RegisteredAgent,Rowguid")] Organization organization)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organization);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["EntityTypeId"] = new SelectList(_context.EntityType, "EntityTypeId", "Name", organization.EntityTypeId);
            ViewData["Naicscode"] = new SelectList(_context.Naics, "Description", "Description", organization.Naicscode);
            ViewData["PartyId"] = new SelectList(_context.Party, "PartyId", "PartyId", organization.PartyId);
            return View(organization);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Organizations/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organization = await _context.Organization.SingleOrDefaultAsync(m => m.PartyId == id);
            if (organization == null)
            {
                return NotFound();
            }
            ViewData["EntityTypeId"] = new SelectList(_context.EntityType, "EntityTypeId", "Name", organization.EntityTypeId);
            ViewData["Naicscode"] = new SelectList(_context.Naics, "Description", "Description", organization.Naicscode);
            ViewData["PartyId"] = new SelectList(_context.Party, "PartyId", "PartyId", organization.PartyId);
            return View(organization);
        }

        // POST: Organizations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("PartyId,ActiveStatus,ChicoSignUpDate,EntityTypeId,EstablishmentDate,IncludeInListing,ModifiedDate,Naicscode,Name,NumberOfEmployees,Purpose,RegisteredAgent,Rowguid")] Organization organization)
        {
            if (id != organization.PartyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organization);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizationExists(organization.PartyId))
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
            ViewData["EntityTypeId"] = new SelectList(_context.EntityType, "EntityTypeId", "Name", organization.EntityTypeId);
            ViewData["Naicscode"] = new SelectList(_context.Naics, "Description", "Description", organization.Naicscode);
            ViewData["PartyId"] = new SelectList(_context.Party, "PartyId", "PartyId", organization.PartyId);
            return View(organization);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Organizations/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organization = await _context.Organization.SingleOrDefaultAsync(m => m.PartyId == id);
            if (organization == null)
            {
                return NotFound();
            }

            return View(organization);
        }

        // POST: Organizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var organization = await _context.Organization.SingleOrDefaultAsync(m => m.PartyId == id);
            _context.Organization.Remove(organization);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool OrganizationExists(long id)
        {
            return _context.Organization.Any(e => e.PartyId == id);
        }
    }
}
