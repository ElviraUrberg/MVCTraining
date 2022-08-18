using Microsoft.AspNetCore.Mvc;
using MVCTraining.Models;
using System.Diagnostics;

namespace MVCTraining.Controllers
{
    public class XplorerController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}