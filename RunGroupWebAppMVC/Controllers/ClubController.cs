using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroupWebAppMVC.Data;
using RunGroupWebAppMVC.Interfaces;
using RunGroupWebAppMVC.Models;
using System.Linq;

namespace RunGroupWebAppMVC.Controllers
{
    public class ClubController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly IClubRepository _clubRepository;
        public ClubController(IClubRepository clubRepository)
        {
            _clubRepository = clubRepository;
            
        }
        public async Task<IActionResult> Index()
        {
            //List<Club> clubs=_context.Clubs.ToList();
            IEnumerable<Club> clubs= await _clubRepository.GetAll();
            return View(clubs);
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int Id)
        {
            //Club club = _context.Clubs.Include(ad => ad.Address).FirstOrDefault(u => u.Id== Id);
            Club club=await _clubRepository.GetByIdAsync(Id);
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
