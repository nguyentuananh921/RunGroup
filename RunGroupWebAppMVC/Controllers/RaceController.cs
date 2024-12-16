using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroupWebAppMVC.Data;
using RunGroupWebAppMVC.Models;

namespace RunGroupWebAppMVC.Controllers
{
    public class RaceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RaceController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Race> races=_context.Races.ToList();
            return View(races);
        }
        [HttpGet]
        public IActionResult Detail(int Id)
        {
            Race race = _context.Races.Include(ad => ad.Address).FirstOrDefault(u => u.Id == Id);
            if (race == null)
            {
                return NotFound();
            }
            else
            {
                return View(race);
            }
        }
    }
}
