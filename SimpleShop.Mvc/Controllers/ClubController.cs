using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleShop.Application.Coaches;
using SimpleShop.Domain;
using SimpleShop.Domain.Entities.Clubs;
using SimpleShop.Mvc.ViewModels;

namespace SimpleShop.Mvc.Controllers
{
    public class ClubController : MvcBaseController
    {
        private readonly SimpleShopContext _context;
        private readonly IMapper _mapper;
        private readonly ICoachAppService _coachAppService;

        public ClubController(SimpleShopContext context, IMapper mapper, ICoachAppService coachAppService)
        {
            _context = context;
            _mapper = mapper;
            _coachAppService = coachAppService;
        }

        [Route("Club/Index")]
        [HttpGet]
        public async Task<IActionResult> Index(int clubId)
        {
            var club = await _context.Clubs.Include(c=>c.City).FirstAsync(c => c.Id == clubId);
            return View(_mapper.Map<ClubViewModel>(club));
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

            return View(_mapper.Map<IEnumerable<StartViewModel>>(clubs));
        }

        [Route("Club/CategoryCoaches")]
        [HttpGet]
        public async Task<IActionResult> CategoryCoaches(int clubId)
        {
            //var coaches = await _context.Coaches.Include(c=>c.Club).Where(c => c.ClubId == clubId).ToListAsync();
            //return PartialView("_CategoryCoaches", _mapper.Map<IEnumerable<CoachesViewModel>>(coaches));

            //var clubs = await _clubAppService.GetAllAsync(cityId);
            //return View(_mapper.Map<IEnumerable<StartViewModel>>(clubs));

            var coaches = await _coachAppService.GetAllAsync(clubId);
            return View(_mapper.Map<IEnumerable<CoachesViewModel>>(coaches));
        }

        [Route("Club/Schedule")]
        [HttpGet("{chapter}")]
        public async Task<IActionResult> Schedule(string? clubName = null)
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
            return View(_mapper.Map<IEnumerable<StartViewModel>>(clubs));
        }

        [Route("Club/ScheduleTable")]
        [HttpGet]
        public async Task <IActionResult> ScheduleTable(int clubId)
        {
            var club = await _context.Clubs.FirstAsync(c => c.Id == clubId);
            return PartialView("_ScheduleTable", _mapper.Map<ClubViewModel>(club));
        }

        [Route("Club/CoachPage")]
        [HttpGet]
        public async Task<IActionResult> CoachPage(int coachId)
        {
            var coach = await _context.Coaches.Include(c => c.Club).FirstAsync(c => c.Id == coachId);
            return PartialView("_CoachPage", _mapper.Map<CoachesViewModel>(coach));
        }
    }
}
