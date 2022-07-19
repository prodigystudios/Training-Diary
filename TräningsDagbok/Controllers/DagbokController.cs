using Microsoft.AspNetCore.Mvc;
using TräningsDagbok.Models;

namespace TräningsDagbok.Controllers
{
    public class DagbokController : Controller
    {
        public IActionResult Index()
        {
            Database db = new Database();
            return View(db.GetExersices());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Exersice _exersice)
        {
            Database db = new Database();
            db.AddExercise(_exersice);
            return Redirect("/Dagbok");
        }
        
        public IActionResult Delete(int id)
        {
            Database db = new Database();
            var exersice = db.GetExerciseById(id);

            return View(exersice);   
        }
        public IActionResult DeleteTraining(int id)
        {
            Database db = new Database();
            db.DeleteExercise(id);

            return Redirect("/Dagbok");
        }
    }
}
