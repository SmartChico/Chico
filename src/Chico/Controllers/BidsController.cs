using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Chico.Models;
using System.Data.Common;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace Chico.Controllers
{
    public class BidsController : Controller
    {
        private readonly chicoContext _context;

        public BidsController(chicoContext context)
        {
            _context = context;    
        }

        // GET: Bids
        public async Task<IActionResult> Index()
        {
            var chicoContext = _context.Bid.Include(b => b.CurrencyNavigation).Include(b => b.Organization).Include(b => b.Project);
            return View(await chicoContext.ToListAsync());
        }

        // GET: Bids/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bid = await _context.Bid
                .Include(b => b.CurrencyNavigation)
                .Include(b => b.Organization)
                .Include(b => b.Project)
                .SingleOrDefaultAsync(m => m.BidId == id);
            if (bid == null)
            {
                return NotFound();
            }

            return View(bid);
        }

        // GET: Bids/Create
        public IActionResult Create()
        {
            ViewData["Currency"] = new SelectList(_context.Currency, "CurrencyId", "CurrencyName");
            ViewData["OrganizationId"] = new SelectList(_context.Organization, "PartyId", "Name");
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "Name");
            return View();
        }

        // POST: Bids/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BidId,OrganizationId,ProjectId,Summary,CostEstimate,Currency,DeliveryDate,Role")] Bid bid)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bid);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Currency"] = new SelectList(_context.Currency, "CurrencyId", "CurrencyName", bid.Currency);
            ViewData["OrganizationId"] = new SelectList(_context.Organization, "PartyId", "Name", bid.OrganizationId);
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "Name", bid.ProjectId);
            return View(bid);
        }

        // GET: Bids/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bid = await _context.Bid.SingleOrDefaultAsync(m => m.BidId == id);
            if (bid == null)
            {
                return NotFound();
            }
            ViewData["Currency"] = new SelectList(_context.Currency, "CurrencyId", "CurrencyName", bid.Currency);
            ViewData["OrganizationId"] = new SelectList(_context.Organization, "PartyId", "Name", bid.OrganizationId);
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "Name", bid.ProjectId);
            return View(bid);
        }

        // POST: Bids/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BidId,OrganizationId,ProjectId,Summary,CostEstimate,Currency,DeliveryDate,Role")] Bid bid)
        {
            if (id != bid.BidId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bid);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BidExists(bid.BidId))
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
            ViewData["Currency"] = new SelectList(_context.Currency, "CurrencyId", "CurrencyName", bid.Currency);
            ViewData["OrganizationId"] = new SelectList(_context.Organization, "PartyId", "Name", bid.OrganizationId);
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "Name", bid.ProjectId);
            return View(bid);
        }

        // GET: Bids/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bid = await _context.Bid
                .Include(b => b.CurrencyNavigation)
                .Include(b => b.Organization)
                .Include(b => b.Project)
                .SingleOrDefaultAsync(m => m.BidId == id);
            if (bid == null)
            {
                return NotFound();
            }

            return View(bid);
        }

        // POST: Bids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bid = await _context.Bid.SingleOrDefaultAsync(m => m.BidId == id);
            _context.Bid.Remove(bid);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult BidXml(int id)
        {
            var bid = _context.Bid.Where(b => b.BidId == id).SingleOrDefault();

            return new ContentResult
            {
                ContentType = "application/xml",
                Content =bid.bidxml,
                StatusCode = 200
            };
        }
        private bool BidExists(int id)
        {
            return _context.Bid.Any(e => e.BidId == id);
        }
    }
}
