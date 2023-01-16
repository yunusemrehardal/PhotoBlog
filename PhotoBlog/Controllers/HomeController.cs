using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhotoBlog.Data;
using PhotoBlog.Models;

namespace PhotoBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index(string? q)
        {
            IQueryable<Post> query = _db.Posts.Include(x => x.Tags);

            if (!string.IsNullOrWhiteSpace(q))
            {
                q = q.Trim();

                if (q.StartsWith("#"))
                {
                    var tag = q.Substring(1);
                    query = query.Where(x => x.Tags.Any(t => t.Name == tag));
                }
                else
                {
                    query = query.Where(x => x.Title.Contains(q) || x.Description!.Contains(q));
                }
            }

            var posts = query.OrderByDescending(x => x.CreatedTime).ToList();

            var vm = new HomeViewModel()
            {
                Posts = posts,
                Search = q
            };

            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}