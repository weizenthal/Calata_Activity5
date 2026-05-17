using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Calata_Activity4.Data;

namespace Calata_Activity4.Controllers
{
    public class HomeController : Controller
    {
        private readonly CalataDbContext _context;

        public HomeController(CalataDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var videoList = await _context.YouTubeVideos.ToListAsync();
            return View(videoList);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}