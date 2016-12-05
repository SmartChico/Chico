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
    public class PeopleController : Controller
    {
        private readonly chicoContext _context;

        public PeopleController(chicoContext context)
        {
            _context = context;    
        }

        // GET: People
        public async Task<IActionResult> Index()
        {
            var chicoContext = _context.Person.Include(p => p.Party);
            return View(await chicoContext.ToListAsync());
        }

        // GET: People/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person
                .Include(p => p.Party)
                .SingleOrDefaultAsync(m => m.PartyId == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: People/Create
        public IActionResult Create()
        {
            ViewData["PartyId"] = new SelectList(_context.Party, "PartyId", "PartyId");
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,FirstName,MiddleName,LastName,DateOfBirth,SpouseName,SpouseDateOfBirth,Rowguid,ModifiedDate")] Person person)
        {
            if (ModelState.IsValid)
            {
                Party party = new Party();
                person.Party = party;
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["PartyId"] = new SelectList(_context.Party, "PartyId", "PartyId", person.PartyId);
            return View(person);
        }

        // GET: People/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person.SingleOrDefaultAsync(m => m.PartyId == id);
            if (person == null)
            {
                return NotFound();
            }
            ViewData["PartyId"] = new SelectList(_context.Party, "PartyId", "PartyId", person.PartyId);
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("PartyId,Title,FirstName,MiddleName,LastName,DateOfBirth,SpouseName,SpouseDateOfBirth,Rowguid,ModifiedDate")] Person person)
        {
            if (id != person.PartyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.PartyId))
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
            ViewData["PartyId"] = new SelectList(_context.Party, "PartyId", "PartyId", person.PartyId);
            return View(person);
        }

        // GET: People/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person
                .Include(p => p.Party)
                .SingleOrDefaultAsync(m => m.PartyId == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var person = await _context.Person.SingleOrDefaultAsync(m => m.PartyId == id);
            _context.Person.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PersonExists(long id)
        {
            return _context.Person.Any(e => e.PartyId == id);
        }
    }
}
