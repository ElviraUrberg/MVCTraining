using Microsoft.AspNetCore.Mvc;
using MVCTraining.Data;
using MVCTraining.Models;
using static MVCTraining.Data.ApplicationDbContext;

namespace MVCTraining.Controllers
{
    public class FieldsurveyController : Controller
    {
        private readonly ApplicationDbContext _db;
        public FieldsurveyController(ApplicationDbContext db)
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
        public IActionResult Create(FieldSurvey obj)
        {
            _db.FieldSurveys.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var fieldsurveyFromDb = _db.FieldSurveys.Find(id);

            if (fieldsurveyFromDb == null)
            {
                return NotFound();
            }

            return View(fieldsurveyFromDb);
        }

        //Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FieldSurvey obj)
        {
            if (ModelState.IsValid)
            {
                var fieldsurvey = _db.FieldSurveys.Find(obj.Id);
                fieldsurvey.Service = obj.Service;
                fieldsurvey.Category = obj.Category;
                fieldsurvey.Area = obj.Area;
                fieldsurvey.Photopath = obj.Photopath;
                fieldsurvey.Comment = obj.Comment;                
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }
    }
}
