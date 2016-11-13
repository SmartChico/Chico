using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Chico.Models;
using Sakura.AspNetCore;


namespace Chico.Controllers
{
    public class NaicsController : Controller
    {
        private readonly chicoContext _context;

        public NaicsController(chicoContext context)
        {
            _context = context;    
        }

        // GET: Naics
        public async Task<IActionResult> Index()
        {
            var pagedData = _context.Naics.ToPagedList(20, 1);
            return View(pagedData);
        }
    }
}
