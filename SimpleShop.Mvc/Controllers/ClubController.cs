using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index(int clubId)
        {
            var cl = _context.Clubs.FirstOrDefault(c => c.Id == clubId);
            var city = _context.Cities.FirstOrDefault(c => c.Id == cl.CityId);

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
                CityName = city.Name,
            };
            return View(club);
        }

        [Route("Club/Coaches")]
        [HttpGet("{name}")]
        public IActionResult Coaches(string name, string? clubName = null)
        {
            var city = _context.Cities.FirstOrDefault(c => c.Name == name);

            List<Club> clubs;

            if (clubName == null)
            {
                clubs = _context.Clubs.Where(c => c.CityId == city.Id).ToList();
            }
            else
            {
                clubs = _context.Clubs.Where(c => c.Name == clubName).ToList();
            }

            return View(clubs.Select(c => new StartViewModel
            {
                CityName = city.Name,
                ClubName = c.Name,
                ClubDisplayName = c.DisplayName,
                ClubId = c.Id,
            }));
        }

        [Route("Club/CategoryCoaches")]
        [HttpGet]
        public IActionResult CategoryCoaches(int clubId)
        {
            var club = _context.Clubs.FirstOrDefault(c => c.Id == clubId);

            var coaches = _context.Coaches.Where(c => c.ClubId == clubId).ToList();

            return PartialView("_CategoryCoaches", coaches.Select(c => new CoachesViewModel 
            {
                Id = c.Id,
                Name = c.Name,
                ClubId = c.ClubId,
                Description = c.Description,
                TelephoneNumber = c.TelephoneNubmer,
                CategoryId = c.CategoryCoachId,
                ClubName = club.DisplayName,
                PhotoLink = c.PhotoLink,
            }));
        }

        [Route("Club/Schedule")]
        [HttpGet("{name}")]
        public IActionResult Schedule(string name, string? clubName = null)
        {
            var city = _context.Cities.FirstOrDefault(c => c.Name == name);

            //int id;

            //if (HttpContext.Request.Cookies["cityId"] == null || HttpContext.Request.Cookies["cityId"] == "0")
            //    id = 1;

            //else
            //    id = int.Parse(HttpContext.Request.Cookies["cityId"].ToString());

            List<Club> clubs;

            if (clubName == null)
            {
                clubs = _context.Clubs.Where(c => c.CityId == city.Id).ToList();
            }
            else
            {
                clubs = _context.Clubs.Where(c => c.Name == clubName).ToList();
            }

            return View(clubs.Select(c => new StartViewModel
            {
                CityName = city.Name,
                ClubName = c.Name,
                ClubDisplayName = c.DisplayName,
                ClubId = c.Id,
            }));
        }

    }
}
