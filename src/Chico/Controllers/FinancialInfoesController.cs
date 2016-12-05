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
    public class FinancialInfoesController : Controller
    {
        private readonly chicoContext _context;

        public FinancialInfoesController(chicoContext context)
        {
            _context = context;    
        }

        // GET: FinancialInfoes
        public async Task<IActionResult> Index()
        {
            var chicoContext = _context.FinancialInfo.Include(f => f.Bank);
            return View(await chicoContext.ToListAsync());
        }

        // GET: FinancialInfoes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financialInfo = await _context.FinancialInfo
                .Include(f => f.Bank)
                .SingleOrDefaultAsync(m => m.PartyId == id);
            if (financialInfo == null)
            {
                return NotFound();
            }

            return View(financialInfo);
        }

        // GET: FinancialInfoes/Create
        public IActionResult Create(long id)
        {
            var party =  _context.Party.SingleOrDefault(m => m.PartyId == id);
            if (party == null)
            {
                return NotFound();
            }
            ViewData["PartyId"] = id;
            ViewData["BankId"] = new SelectList(_context.Organization, "PartyId", "Name");
            return View();
        }

        // POST: FinancialInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountingFirm,ChiefAccountant,AccountingSoftware,EstimateSoftware,JobCostSoftware,FinancialStatementBasis,FinancialStatementIssuePeriod,BankId,TaxId,Ssn,LargestBondValue,PercentageSubcontracted,LeasedEquipment,BankruptcyDescription,LargestBacklog")] FinancialInfo financialInfo, [Bind("PartyId")] long partyId)
        {
            if (ModelState.IsValid)
            {
                financialInfo.PartyId = partyId;
                _context.Add(financialInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Organizations");
            }
            ViewData["BankId"] = new SelectList(_context.Organization, "PartyId", "Name", financialInfo.BankId);
            return View(financialInfo);
        }

        // GET: FinancialInfoes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financialInfo = await _context.FinancialInfo.SingleOrDefaultAsync(m => m.PartyId == id);
            if (financialInfo == null)
            {
                return NotFound();
            }
            ViewData["BankId"] = new SelectList(_context.Organization, "PartyId", "Name", financialInfo.BankId);
            return View(financialInfo);
        }

        // POST: FinancialInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("PartyId,AccountingFirm,ChiefAccountant,AccountingSoftware,EstimateSoftware,JobCostSoftware,FinancialStatementBasis,FinancialStatementIssuePeriod,BankId,TaxId,Ssn,LargestBondValue,PercentageSubcontracted,LeasedEquipment,BankruptcyDescription,LargestBacklog")] FinancialInfo financialInfo)
        {
            if (id != financialInfo.PartyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(financialInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FinancialInfoExists(financialInfo.PartyId))
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
            ViewData["BankId"] = new SelectList(_context.Organization, "PartyId", "Name", financialInfo.BankId);
            return View(financialInfo);
        }

        // GET: FinancialInfoes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financialInfo = await _context.FinancialInfo
                .Include(f => f.Bank)
                .SingleOrDefaultAsync(m => m.PartyId == id);
            if (financialInfo == null)
            {
                return NotFound();
            }

            return View(financialInfo);
        }

        // POST: FinancialInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var financialInfo = await _context.FinancialInfo.SingleOrDefaultAsync(m => m.PartyId == id);
            _context.FinancialInfo.Remove(financialInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool FinancialInfoExists(long id)
        {
            return _context.FinancialInfo.Any(e => e.PartyId == id);
        }
    }
}
