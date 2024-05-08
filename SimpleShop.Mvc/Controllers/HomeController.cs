using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleShop.Application.Cities;
using SimpleShop.Application.Clubs;
using SimpleShop.Domain;
using SimpleShop.Mvc.ViewModels;

namespace SimpleShop.Mvc.Controllers
{
    public class HomeController : MvcBaseController
    {
        private readonly IClubAppService _clubAppService;
        private readonly ICityAppService _cityAppService;
        private readonly IMapper _mapper;

        public HomeController(IMapper mapper, IClubAppService clubAppService, SimpleShopContext context, ICityAppService cityAppService)
        {
            _mapper = mapper;
            _clubAppService = clubAppService;
            _cityAppService = cityAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            int cityId = 1;
            if (HttpContext.Request.Cookies["cityId"] != null && HttpContext.Request.Cookies["cityId"] != "0")
            {
                cityId = int.Parse(HttpContext.Request.Cookies["cityId"]!);
            }

            var clubs = await _clubAppService.GetAllAsync(cityId);
            return View(_mapper.Map<IEnumerable<StartViewModel>>(clubs));
        }

        [Route("Home/Privacy")]
        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("Home/ChooseCityModal")]
        [HttpGet]
        public async Task<IActionResult> ChooseCityModal()
        {
            HttpContext.Response.Cookies.Delete("NoSPB");

            var cities = await _cityAppService.GetAllAsync();
            return PartialView("_ChooseCityModal", _mapper.Map<IEnumerable<CityViewModel>>(cities));
        }

        [Route("Home/CookieUpdate")]
        [HttpGet]
        public void CookieUpdate(int cityId)
        {
            string id = cityId.ToString();

            HttpContext.Response.Cookies.Delete("cityId");
            HttpContext.Response.Cookies.Append("cityId", id);
        }

        [Route("Home/CookieCheck2")]
        [HttpGet]
        public IActionResult CookieCheck2()
        {
            if (HttpContext.Request.Cookies["NoSPB"] != null)
            {
                return NotFound();
            }

            if (HttpContext.Request.Cookies["cityId"] == null)
            {
                return BadRequest();
            }
            return Ok();
        }

        [Route("Home/AgreeCityModal")]
        [HttpGet]
        public async Task<IActionResult> AgreeCityModal(double latitude, double longitude)
        {
            double[,] cities = { { 55.75330785790186, 37.61966161690279 }, { 59.93265635770101, 30.317497465332426 }, { 55.79247459978864, 49.11478483216316 } };
            double[] latitudelLongitude = { 0, 0 };
            double square = 100;

            for (int i = 0; i < 3; i++)
            {
                double sqtr = Math.Sqrt(Math.Pow(cities[i, 0] - latitude, 2) + Math.Pow(cities[i, 1] - longitude, 2));

                if (sqtr < square)
                {
                    square = sqtr;
                    latitudelLongitude[0] = cities[i, 0];
                    latitudelLongitude[1] = cities[i, 1];
                }
            }

            //var city = await _context.Cities
            //    .Where(c => c.Latitude == latitudelLongitude[0] && c.Longitude == latitudelLongitude[1])
            //    .FirstAsync();

            var city = await _cityAppService.GetAsync(latitudelLongitude[0], latitudelLongitude[1]);
            return PartialView("_AgreeCityModal", _mapper.Map<CityViewModel>(city));
        }

        [Route("Home/CookieNoSPB")]
        [HttpGet]
        public void CookieNoSPB()
        {
            string id = "1";
            HttpContext.Response.Cookies.Append("NoSPB", id);
        }
    }
}