using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleShop.Application.Clubs;
using SimpleShop.Application.Coaches;
using SimpleShop.Mvc.ViewModels;

namespace SimpleShop.Mvc.Controllers
{
    public class ClubController : MvcBaseController
    {
        private readonly IMapper _mapper;
        private readonly ICoachAppService _coachAppService;
        private readonly IClubAppService _clubAppService;

        public ClubController(IMapper mapper, ICoachAppService coachAppService, IClubAppService clubAppService)
        {
            _mapper = mapper;
            _coachAppService = coachAppService;
            _clubAppService = clubAppService;
        }

        [Route("Club/Index")]
        [HttpGet]
        public async Task<IActionResult> Index(int clubId)
        {
            var club = await _clubAppService.GetAsync(clubId);
            return View(_mapper.Map<ClubViewModel>(club));
        }

        [Route("Club/Coaches")]
        [HttpGet("{name}")]
        public async Task<IActionResult> Coaches(string? clubName = null)
        {
            int cityId = 1;
            if (HttpContext.Request.Cookies["cityId"] != null && HttpContext.Request.Cookies["cityId"] != "0")
            {
                cityId = int.Parse(HttpContext.Request.Cookies["cityId"]!);
            }

            var clubs = await _clubAppService.GetAllAsync(cityId);
            if (clubName != null)
            {
                clubs = await _clubAppService.GetAllAsync(clubName);
            }
            return View(_mapper.Map<IEnumerable<StartViewModel>>(clubs));
        }

        [Route("Club/CategoryCoaches")]
        [HttpGet]
        public async Task<IActionResult> CategoryCoaches(int clubId)
        {
            var coaches = await _coachAppService.GetAllAsync(clubId);
            return PartialView("_CategoryCoaches", _mapper.Map<IEnumerable<CoachesViewModel>>(coaches));
        }

        [Route("Club/Schedule")]
        [HttpGet("{chapter}")]
        public async Task<IActionResult> Schedule(string? clubName = null)
        {
            int cityId = 1;
            if (HttpContext.Request.Cookies["cityId"] != null && HttpContext.Request.Cookies["cityId"] != "0")
            {
                cityId = int.Parse(HttpContext.Request.Cookies["cityId"]!);
            }

            var clubs = await _clubAppService.GetAllAsync(cityId);
            if (clubName != null)
            {
                clubs = await _clubAppService.GetAllAsync(clubName);
            }
            return View(_mapper.Map<IEnumerable<StartViewModel>>(clubs));
        }

        [Route("Club/ScheduleTable")]
        [HttpGet]
        public async Task<IActionResult> ScheduleTable(int clubId)
        {
            var club = await _clubAppService.GetAsync(clubId);
            return PartialView("_ScheduleTable", _mapper.Map<ClubViewModel>(club));
        }

        [Route("Club/CoachPage")]
        [HttpGet]
        public async Task<IActionResult> CoachPage(int coachId)
        {
            var coach = await _coachAppService.GetAsync(coachId);
            return PartialView("_CoachPage", _mapper.Map<CoachesViewModel>(coach));
        }
    }
}
