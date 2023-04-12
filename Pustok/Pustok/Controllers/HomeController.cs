using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.DAL;
using Pustok.Models;
using Pustok.ViewModels;
using System.Diagnostics;

namespace Pustok.Controllers
{
    public class HomeController : Controller
    {
        private readonly PustokDbContext _context;

        public HomeController(PustokDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var slider = _context.Sliders.FirstOrDefault(x => x.BtnUrl == null);
            //var slider = _context.Sliders.First(x => x.BtnUrl == null);

            //var slider = _context.Sliders.Single(x => x.BtnUrl == null);
            //var slider = _context.Sliders.SingleOrDefault(x => x.BtnUrl == null);

            //var sliders = _context.Sliders.Where(x => x.BtnUrl == null);
            //sliders = sliders.Where(x => x.BtnText == null);

            //var data = sliders.ToList();

            //var sliders = _context.Sliders.OrderBy(x=>x.Title1).ToList();


            HomeViewModel vm = new HomeViewModel
            {
                Sliders = _context.Sliders.OrderByDescending(x => x.Id).Skip(2).Take(3).ToList()
            };
            return View(vm);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}