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
    public class EmailsController : Controller
    {
        private readonly chicoContext _context;

        public EmailsController(chicoContext context)
        {
            _context = context;    
        }

        // GET: Emails/Create
        public async Task<IActionResult> Create(long id)
        {
            var party = await _context.Party.SingleOrDefaultAsync(m => m.PartyId == id);
            if (party == null)
            {
                return NotFound();
            }
            ViewData["PartyId"] = id;
            return View();
        }

        // POST: Emails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Email1")] Email email, [Bind("PartyId")] long partyId)
        {
            if (ModelState.IsValid)
            {
                PartyEmail pe = new PartyEmail();
                pe.PartyId = partyId;
                pe.Email = email;

                _context.Add(email);
                _context.Add(pe);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Organizations");
            }
            return View(email);
        }

        // GET: Emails/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var email = await _context.Email.SingleOrDefaultAsync(m => m.EmailId == id);
            if (email == null)
            {
                return NotFound();
            }
            return View(email);
        }

        // POST: Emails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("EmailId,Email1,Rowguid,ModifiedDate")] Email email)
        {
            if (id != email.EmailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(email);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmailExists(email.EmailId))
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
            return View(email);
        }

        private bool EmailExists(long id)
        {
            return _context.Email.Any(e => e.EmailId == id);
        }
    }
}
