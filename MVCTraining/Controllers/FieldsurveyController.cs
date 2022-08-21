using Microsoft.AspNetCore.Mvc;
using MVCTraining.Data;
using MVCTraining.Interfaces;
using MVCTraining.Models;
using static MVCTraining.Data.ApplicationDbContext;

namespace MVCTraining.Controllers
{
    public class FieldsurveyController : Controller
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Jag ville lägga till en knapp som öppnar utforskaren 
        /// där man kan välja en bild från datorn, har inte fått det
        /// att fungera än.
        /// </summary>
        private IFileExplorerService _fileExplorer;

        public FieldsurveyController(ApplicationDbContext db, IFileExplorerService fileExplorerService)
        {
            _db = db;
            _fileExplorer = fileExplorerService;
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

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FieldSurvey obj)
        {
            if (ModelState.IsValid)
            {
                _db.FieldSurveys.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //POST
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

        //POST
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

        public IActionResult Delete(int? id)
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

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var fieldsurveyFromDb = _db.FieldSurveys.Find(id);
            if(fieldsurveyFromDb == null)
            {
                return NotFound();
            }

            _db.FieldSurveys.Remove(fieldsurveyFromDb);
                _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
