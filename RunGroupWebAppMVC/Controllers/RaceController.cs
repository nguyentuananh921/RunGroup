using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroupWebAppMVC.Data;
using RunGroupWebAppMVC.Interfaces;
using RunGroupWebAppMVC.Models;

namespace RunGroupWebAppMVC.Controllers
{
    public class RaceController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly IRaceRepository _raceRepository;

        public RaceController(IRaceRepository repository)
        {
            _raceRepository = repository;
        }

        public async Task<IActionResult> Index()
        {
            //List<Race> races=_context.Races.ToList();
            IEnumerable<Race> races= await _raceRepository.GetAll();
            return View(races);
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int Id)
        {
            //Race race = _context.Races.Include(ad => ad.Address).FirstOrDefault(u => u.Id == Id);
            Race race= await _raceRepository.GetByIdAsync(Id);
            if (race == null)
            {
                return NotFound();
            }
            else
            {
                return View(race);
            }
        }

        [HttpGet]
        public IActionResult AddOrEdit(int inputId = 0)
        {
            if (inputId == 0) //Add Operation here
            {
                return View(new Race());
            }
            else //Update Operation here
            {
                return View(_raceRepository.GetByIdAsync(inputId));
                //return View(_context.Transactions.FirstOrDefault(u => u.TransactionId == inputId));
            }
        }
        [HttpPost]
        public IActionResult AddOrEdit(Race race)
        {
            if (!ModelState.IsValid)
            {
                return View(race);
            }
            _raceRepository.Add(race);
            return RedirectToAction("Index");
        }
    }
}
