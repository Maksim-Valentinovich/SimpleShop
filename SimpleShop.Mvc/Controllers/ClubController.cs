using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleShop.Domain;
using SimpleShop.Domain.Entities.Clubs;
using SimpleShop.Mvc.ViewModels;

namespace SimpleShop.Mvc.Controllers
{
    public class ClubController : MvcBaseController
    {
        private readonly SimpleShopContext _context;

        public ClubController(SimpleShopContext context)
        {
            _context = context;
        }

        [Route("Club/Index")]
        [HttpGet]
        public async Task<IActionResult> Index(int clubId)
        {
            var cl = await _context.Clubs.Include(c=>c.City).FirstAsync(c => c.Id == clubId);

            ClubViewModel club = new()
            {
                Name = cl.Name,
                DisplayName = cl.DisplayName,
                Address = cl.Address,
                WeekendsStart = cl.WeekendsStart,
                WeekendsFinish = cl.WeekendsFinish,
                InterpreterFinish = cl.InterpreterFinish,
                InterpreterStart = cl.InterpreterStart,
                Phone = cl.Phone,
                GumLink = cl.GumLink,
                SwimLink = cl.SwimLink,
                GroupLink = cl.GroupLink,
                CityName = cl.City.Name,
            };
            return View(club);
        }

        [Route("Club/Coaches")]
        [HttpGet("{name}")]
        public async Task<IActionResult> Coaches(string? clubName = null)
        {
            int id = 1;
            if (HttpContext.Request.Cookies["cityId"] != null && HttpContext.Request.Cookies["cityId"] != "0")
            {
                id = int.Parse(HttpContext.Request.Cookies["cityId"]!);
            }

            List<Club> clubs;
            clubs = await _context.Clubs.Include(c=>c.City).Where(c => c.CityId == id).ToListAsync();
            if (clubName != null)
            {
                clubs = await _context.Clubs.Include(c => c.City).Where(c => c.Name == clubName).ToListAsync();
            }

            return View(clubs.Select(c => new StartViewModel
            {
                CityName = c.City.Name,
                ClubName = c.Name,
                ClubDisplayName = c.DisplayName,
                ClubId = c.Id,
            }));
        }

        [Route("Club/CategoryCoaches")]
        [HttpGet]
        public async Task<IActionResult> CategoryCoaches(int clubId)
        {
            var coaches = await _context.Coaches.Include(c=>c.Club).Where(c => c.ClubId == clubId).ToListAsync();

            return PartialView("_CategoryCoaches", coaches.Select(c => new CoachesViewModel 
            {
                Id = c.Id,
                Name = c.Name,
                ClubId = c.ClubId,
                Description = c.Description,
                TelephoneNumber = c.TelephoneNubmer,
                CategoryId = c.CategoryCoachId,
                ClubName = c.Club.DisplayName,
                PhotoLink = c.PhotoLink,
            }));
        }

        [Route("Club/Schedule")]
        [HttpGet("{chapter}")]
        public async Task<IActionResult> Schedule(string chapter, string? clubName = null)
        {
            int id = 1;
            if (HttpContext.Request.Cookies["cityId"] != null && HttpContext.Request.Cookies["cityId"] != "0")
            {
                id = int.Parse(HttpContext.Request.Cookies["cityId"]!);
            }

            List<Club> clubs;
            clubs = await _context.Clubs.Include(c=>c.City).Where(c => c.CityId == id).ToListAsync();
            if (clubName != null)
            {
                clubs = await _context.Clubs.Where(c => c.Name == clubName).ToListAsync();
            }

            return View(clubs.Select(c => new StartViewModel
            {
                CityName = c.City.Name,
                ClubName = c.Name,
                ClubDisplayName = c.DisplayName,
                ClubId = c.Id,
                Chapter = chapter,
            }));
        }

        [Route("Club/ScheduleTable")]
        [HttpGet]
        public async Task <IActionResult> ScheduleTable(int clubId)
        {
            var cl = await _context.Clubs.FirstAsync(c => c.Id == clubId);

            ClubViewModel club = new()
            {
                DisplayName = cl.DisplayName,
            };

            return PartialView("_ScheduleTable", club);
        }

        [Route("Club/CoachPage")]
        [HttpGet]
        public async Task<IActionResult> CoachPage(int coachId)
        {
            var coach = await _context.Coaches.Include(c => c.Club).FirstAsync(c => c.Id == coachId);

            CoachesViewModel ch = new()
            {
                Name = coach.Name,
                ClubName = coach.Club.Name,
                PhotoLink = coach.PhotoLink,
                TelephoneNumber = coach.TelephoneNubmer,
                Description = coach.Description,
            };

            return PartialView("_CoachPage", ch);
        }
    }
}
