using DependencyInjectionDemo.Core;
using DependencyInjectionDemo.Core.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DependencyInjectionNinject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookServices _bookServices;

        public HomeController(IBookServices bookServices)
        {
            _bookServices = bookServices;
        }
        public async Task<ActionResult> Index()
        {
            Func<IQueryable<Book>, IOrderedQueryable<Book>> orderBy = b => b.OrderBy(c => c.Title);
            var books = await _bookServices.GetAsync(orderBy: orderBy);
            return View(books);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}