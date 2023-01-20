using Animals.Data;
using Animals.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Animals.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbMaster dbMaster;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {

            dbMaster = new DbMaster(db);

            _logger = logger;
        }

        public IActionResult Index()
        {           
            return View();
        }

        public IActionResult Privacy()
        {
            var cars = dbMaster.GetAllFuelCars();

            return View(cars);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}