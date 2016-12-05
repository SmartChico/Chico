using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Chico.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.Security.Claims;
using Chico.Models.PartyViewModels;

namespace Chico.Controllers
{
    public class OrganizationAuthorizationHandler :
       AuthorizationHandler<OperationAuthorizationRequirement, Organization>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                    OperationAuthorizationRequirement requirement,
                                                    Organization resource)
        {
            var claimsIdentity = (ClaimsIdentity)context.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.UserData);
            var partyId = claim?.Value;
            if (context.User.IsInRole("admin") || resource.PartyId.ToString() == partyId)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
    public class OrganizationsController : Controller
    {
        private readonly chicoContext _context;
        IAuthorizationService _authorizationService;
        public OrganizationsController(chicoContext context, IAuthorizationService authorizationService)
        {
            _context = context;
            _authorizationService = authorizationService;
        }

        // GET: Organizations
        public async Task<IActionResult> Index(String searchNaics)
        {
            var orgs = from m in _context.Organization
                       where m.IncludeInListing == true
                         select m;
            if (!String.IsNullOrEmpty(searchNaics))
            {
                orgs = orgs.Where(s => s.Naicscode.Contains(searchNaics));
            }
            
            return View(await orgs.ToListAsync());
        }

        // GET: Organizations/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var orgViewModel = new OrganizationViewModel();
            var organization = await _context.Organization.SingleOrDefaultAsync(m => m.PartyId == id);
            if (organization == null)
            {
                return NotFound();
            }
            var party = await _context.Party.SingleOrDefaultAsync(m => m.PartyId == id);
            var plist = _context.Party.Include(x => x.PartyEmail).ToList();

            foreach(Party pa in plist)
            {
                var pelist = _context.PartyEmail.Where(pe => pe.PartyId == pa.PartyId).Include(x => x.Email).ToList();
                foreach(PartyEmail pe in pelist)
                {
                    if(pe.PartyId==id)
                        orgViewModel.Emails.Add(pe.Email);
                }
            }

            foreach (PartyAddress pe in party.PartyAddress)
            {
                orgViewModel.Addresses.Append(pe.Address);
            }
            foreach (PartyPhone pe in party.PartyPhone)
            {
                orgViewModel.Phones.Append(pe.Phone);
            }
            foreach (PartyCertificate pe in party.PartyCertificate)
            {
                orgViewModel.Certificates.Append(pe.Certificate);
            }
            foreach (PartyLicense pe in party.PartyLicense)
            {
                orgViewModel.Licenses.Append(pe.License);
            }
            orgViewModel.PartyId = party.PartyId;
            orgViewModel.Naicscode = organization.Naicscode;
            orgViewModel.Name = organization.Name;
            orgViewModel.EntityTypeId = organization.EntityTypeId;
            orgViewModel.RegisteredAgent = organization.RegisteredAgent;
            orgViewModel.NumberOfEmployees = organization.NumberOfEmployees;
            orgViewModel.Purpose = organization.Purpose;
            orgViewModel.IncludeInListing = organization.IncludeInListing;
            orgViewModel.EstablishmentDate = organization.EstablishmentDate;
            orgViewModel.ChicoSignUpDate = organization.ChicoSignUpDate;
            orgViewModel.ActiveStatus = organization.ActiveStatus;

            return View(orgViewModel);
        }

        [Authorize(Roles = "admin")]
        // GET: Organizations/Create
        public IActionResult Create()
        {
            ViewData["EntityTypeId"] = new SelectList(_context.EntityType, "EntityTypeId", "Name");
            ViewData["Naicscode"] = new SelectList(_context.Naics, "Description", "Description");
            ViewData["RegisteredAgent"] = new SelectList(_context.Person, "PartyID", "RegisteredAgent");
            return View();
        }

        // POST: Organizations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("ActiveStatus,ChicoSignUpDate,EntityTypeId,EstablishmentDate,IncludeInListing,Naicscode,Name,NumberOfEmployees,Purpose,RegisteredAgent")] Organization organization)
        {
            if (ModelState.IsValid)
            {
                Party party = new Party();
                organization.Party = party;
                _context.Add(organization);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["EntityTypeId"] = new SelectList(_context.EntityType, "EntityTypeId", "Name", organization.EntityTypeId);
            ViewData["Naicscode"] = new SelectList(_context.Naics, "Description", "Description", organization.Naicscode);
            ViewData["PartyId"] = new SelectList(_context.Party, "PartyId", "PartyId", organization.PartyId);
            return View(organization);
        }

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
            if (await _authorizationService.AuthorizeAsync(User, organization, Operations.Update))
            {
                return View(organization);
            }
            else
            {
                return new ChallengeResult();
            }
            //return View(organization);
        }

        // POST: Organizations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, 
            [Bind("PartyId,ActiveStatus,ChicoSignUpDate,EntityTypeId,EstablishmentDate,IncludeInListing,ModifiedDate,Naicscode,Name,NumberOfEmployees,Purpose,RegisteredAgent,Rowguid")] Organization organization)
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

        private bool OrganizationExists(long id)
        {
            return _context.Organization.Any(e => e.PartyId == id);
        }
    }
}
