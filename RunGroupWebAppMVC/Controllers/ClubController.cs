using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroupWebAppMVC.Data;
using RunGroupWebAppMVC.Models;
using System.Linq;

namespace RunGroupWebAppMVC.Controllers
{
    public class ClubController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ClubController(ApplicationDbContext context)
        {
            _context = context;
            
        }
        public IActionResult Index()
        {
            List<Club> clubs=_context.Clubs.ToList();
            return View(clubs);
        }
        [HttpGet]
        public IActionResult Detail(int Id)
        {
            Club club = _context.Clubs.Include(ad => ad.Address).FirstOrDefault(u => u.Id== Id);
            if (club == null)
            {
                return NotFound();
            }
            else 
            { 
                return View(club);
            }
        }
    }
}
