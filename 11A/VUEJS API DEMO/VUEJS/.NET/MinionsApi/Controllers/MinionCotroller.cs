using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinionsApi.Services;

namespace MinionsApi.Controllers
{
    [ApiController]
    [Route("/Minions/")]
    public class MinionsCotroller : Controller
    {
        private readonly IMinionService ms;
    
        public MinionsCotroller(IMinionService ms)
        {
            this.ms = ms;
        }
        [HttpGet("All")]
        // GET: MinionCotroller
        public IEnumerable<Minion> Index()
        {
            Thread.Sleep(3000);
            var minions = ms.GetAllMinions();
            return minions;
        }
        [HttpGet]
        // GET: MinionCotroller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [HttpGet]
        // GET: MinionCotroller/Create
        public ActionResult Create()
        {
            return View();
        }
       
        // POST: MinionCotroller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        // GET: MinionCotroller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MinionCotroller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        // GET: MinionCotroller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MinionCotroller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
