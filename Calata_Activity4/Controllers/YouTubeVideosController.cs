using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Calata_Activity4.Data;
using Calata_Activity4.Models;

namespace Calata_Activity4.Controllers
{
    public class YouTubeVideosController : Controller
    {
        private readonly CalataDbContext _context;

        public YouTubeVideosController(CalataDbContext context)
        {
            _context = context;
        }

        // GET: YouTubeVideos
        public async Task<IActionResult> Index()
        {
            // Fallback redirect to Home if someone manually visits /YouTubeVideos
            return RedirectToAction("Index", "Home");
        }

        // POST: YouTubeVideos/CreateSinglePage
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSinglePage(string Title, string VideoUrl, string Category)
        {
            if (!string.IsNullOrEmpty(Title) && !string.IsNullOrEmpty(VideoUrl) && !string.IsNullOrEmpty(Category))
            {
                var newVideo = new YouTubeVideo
                {
                    Title = Title,
                    VideoUrl = VideoUrl,
                    Category = Category
                };

                _context.Add(newVideo);
                await _context.SaveChangesAsync();
            }

            // ✨ Redirect back to your vibrant home dashboard page layout
            return RedirectToAction("Index", "Home");
        }

        // GET: YouTubeVideos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var video = await _context.YouTubeVideos.FindAsync(id);
            if (video == null) return NotFound();
            return View(video);
        }

        // POST: YouTubeVideos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,VideoUrl,Category")] YouTubeVideo video)
        {
            if (id != video.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(video);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.YouTubeVideos.Any(e => e.Id == video.Id)) return NotFound();
                    else throw;
                }

                // ✨ Redirect back to your vibrant home dashboard page layout after editing
                return RedirectToAction("Index", "Home");
            }
            return View(video);
        }

        // POST: YouTubeVideos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var video = await _context.YouTubeVideos.FindAsync(id);
            if (video != null)
            {
                _context.YouTubeVideos.Remove(video);
                await _context.SaveChangesAsync();
            }

            // ✨ Redirect back to your vibrant home dashboard page layout after deleting
            return RedirectToAction("Index", "Home");
        }
    }
}