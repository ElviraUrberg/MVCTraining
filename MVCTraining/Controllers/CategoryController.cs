using Microsoft.AspNetCore.Mvc;

namespace MVCTraining.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
