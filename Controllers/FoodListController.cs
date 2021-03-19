using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFood.Models;

namespace MyFood.Controllers
{
    public class FoodListController : Controller
    {

        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Food Food { get; set; }

        public FoodListController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(string? Id)
        {

            Food = new Food();
            if (Id == null)
            {
                //Create
                return View(Food);
            }

            //Update
            Food = _db.Foods.FirstOrDefault(u => u.Id == Id);
            if (Food == null)
            {
                return NotFound();
            }

            return View(Food);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                if (Food.Id == null)
                {
                    //create
                    Food.Id = Guid.NewGuid().ToString();
                    _db.Foods.Add(Food);
                }
                else
                {
                    _db.Foods.Update(Food);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Food);
        }

        #region API Calls

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Foods.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string Id)
        {
            var foodFromDb = await _db.Foods.FirstOrDefaultAsync(u => u.Id == Id);
            if (foodFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Foods.Remove(foodFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
        #endregion

    }
}