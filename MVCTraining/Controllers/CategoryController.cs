using Microsoft.AspNetCore.Mvc;
using MVCTraining.Data;
using MVCTraining.Models;
using static MVCTraining.Data.ApplicationDbcontext;

namespace MVCTraining.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<FieldSurvey> objCategoryList = _db.FieldSurveys.ToList();
            return View(objCategoryList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
            }
            if (ModelState.IsValid)
            {
                //_db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(obj);
        }

        //Edit
        public IActionResult Edit(int? id)
        {
            //if (id == null || id == 0)
            //{
            //    return NotFound();
            //}
            //var categoryFromDb = _db.Categories.Find(id);

            //if (categoryFromDb == null)
            //{
            //    return NotFound(categoryFromDb);
            //}

            return View();
        }

        //Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
            }
            if (ModelState.IsValid)
            {
                //_db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }
    }
}
