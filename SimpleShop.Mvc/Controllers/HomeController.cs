using Microsoft.AspNetCore.Mvc;
using SimpleShop.Domain;
using SimpleShop.Mvc.Models;
using SimpleShop.Mvc.ViewModels;
using System.Diagnostics;

namespace SimpleShop.Mvc.Controllers
{
    public class HomeController : MvcBaseController
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly SimpleShopContext _context;

        public HomeController(SimpleShopContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            int id;

            /*HttpContext.Response.Cookies.Delete("cityId");*/ // test

            if (HttpContext.Request.Cookies["cityId"] == null || HttpContext.Request.Cookies["cityId"] == "0")
                id = 1;

            else
                id = int.Parse(HttpContext.Request.Cookies["cityId"].ToString());

            var city = _context.Cities.FirstOrDefault(c => c.Id == id);

            var clubs = _context.Clubs.Where(c => c.CityId == id).ToList();

            return View(clubs.Select(c => new StartViewModel
            {
                CityName = city.Name,
                ClubName = c.Name,
                ClubDisplayName = c.DisplayName,
                ClubId = c.Id,
            }));
        }

        [Route("Home/Privacy")]
        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("Home/ChooseCityModal")]
        [HttpGet]
        public IActionResult ChooseCityModal()
        {
            HttpContext.Response.Cookies.Delete("NoSPB");

            var cities = _context.Cities.ToList();

            return PartialView("_ChooseCityModal", cities.Select(c => new CityViewModel
            {
                Id = c.Id,
                Name = c.Name,
            }));
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
        public IActionResult AgreeCityModal(double latitude, double longitude)
        {
            double[,] cities = { { 55.75330785790186, 37.61966161690279 }, { 59.93265635770101, 30.317497465332426 }, { 55.79247459978864, 49.11478483216316 } };

            double[] latitudelLongitude = {0,0};

            double square = 100;

            for (int i = 0; i < 3; i++)
            {
                double sqtr = Math.Sqrt(Math.Pow(cities[i,0] - latitude,2) + Math.Pow(cities[i, 1] - longitude, 2));

                if (sqtr < square) 
                {
                    square = sqtr;
                    latitudelLongitude[0] = cities[i, 0];
                    latitudelLongitude[1] = cities[i, 1];
                }   
            }

            var city = _context.Cities.Where(c => c.Latitude == latitudelLongitude[0] && c.Longitude == latitudelLongitude[1]).First().Name;

            return PartialView("_AgreeCityModal", new CityViewModel() { Name = city});
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