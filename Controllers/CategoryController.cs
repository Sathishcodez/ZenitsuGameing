using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using ZenitsuGameing.Data;
using ZenitsuGameing.Models;

namespace ZenitsuGameing.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
                _context = context;
        }

        public IActionResult Index()
        {
            object categories = _context.Categories.ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(obj);
                _context.SaveChanges();
                TempData["success"] = "Category Created Successfull";
                return RedirectToAction("index");
            }
            return View(obj);
        }

        public IActionResult Edit(int Id)
        {
            var category = _context.Categories.FirstOrDefault(d => d.CategoryId == Id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (!ModelState.IsValid) 
            {
                return View(obj);
            }

            var categorytoupdate = _context.Categories.FirstOrDefault(d => d.CategoryId == obj.CategoryId);
            if (categorytoupdate == null)
            {
                return NotFound();
            }
            categorytoupdate.Name = obj.Name;
            categorytoupdate.DisplayOrder = obj.DisplayOrder;

            _context.SaveChanges();
            return RedirectToAction("index");
        }

        //public IActionResult Delete(int? id)
        //{
        //   var obj =  _context.Categories.FirstOrDefault(d => d.CategoryId == id);

        //    if (obj == null)
        //        return NotFound();

        //    return View(obj);
        //}

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);

            if (category == null)
                return NotFound();

            _context.Categories.Remove(category);
            _context.SaveChanges();

            TempData["success"]="Category deleted Successfully";

            return RedirectToAction(nameof(Index));
        }

    }
}
