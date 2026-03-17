using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using ZenitsuGameing.DataAccess.Repositories;
using ZenitsuGameing.DataAccess.Repositories.IRepository;
using ZenitsuGameing.DataAcess.Data;
using ZenitsuGameing.Models;
using ZenitsuGameing.Utility;

namespace ZenitsuGameing.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = UserRole.AdminRole)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            object categories = _unitOfWork.Category.GetAll().ToList();
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
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category Created Successfull";
                return RedirectToAction("index");
            }
            return View(obj);
        }

        public IActionResult Edit(int Id)
        {
            var category = _unitOfWork.Category.GetFirstOrDefault(d => d.CategoryId == Id);
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

            var categorytoupdate = _unitOfWork.Category.GetFirstOrDefault(d => d.CategoryId == obj.CategoryId);
            if (categorytoupdate == null)
            {
                return NotFound();
            }
            categorytoupdate.Name = obj.Name;
            categorytoupdate.DisplayOrder = obj.DisplayOrder;

            _unitOfWork.Save();
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
            var category = _unitOfWork.Category.GetFirstOrDefault(d => d.CategoryId == id);

            if (category == null)
                return NotFound();

            _unitOfWork.Category.Remove(category);
            _unitOfWork.Save();

            TempData["success"] = "Category deleted Successfully";

            return RedirectToAction(nameof(Index));
        }

    }
}
