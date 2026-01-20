using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZenitsuGameing.DataAccess.Repositories.IRepository;
using ZenitsuGameing.Models;
using ZenitsuGameing.Models.ViewModels;

namespace ZenitsuGameing.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> products  = _unitOfWork.Product.GetAll();

            return View(products);
        }
        public IActionResult Upsert(int? id)
        {
            IEnumerable<SelectListItem> categoryList = _unitOfWork.Category.GetAll().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.CategoryId.ToString()
            });
            ProductVM productVM = new ProductVM()
            {
                Product = new Product(),
                CategoryList = categoryList
            };

            if(id == null || id == 0)
            {
                //create
                return View(productVM);
            }
            else
            {
                //update
                productVM.Product = _unitOfWork.Product.GetFirstOrDefault(d => d.Id == id);
                return View(productVM);
            }
        }

        [HttpPost]
        public IActionResult upsert(ProductVM obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productpath =Path.Combine(wwwRootPath, @"images\products");

                    using (var fileStream = new FileStream(Path.Combine(productpath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    obj.Product.ImageUrl = @"\images\products\" + fileName;
                }


                _unitOfWork.Product.Add(obj.Product);
                _unitOfWork.Save();
                TempData["success"] = "Product Created Successfull";
                return RedirectToAction("index");
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var product = _unitOfWork.Product.GetFirstOrDefault(d => d.Id == id);

            if (product == null)
                return NotFound();

            _unitOfWork.Product.Remove(product);
            _unitOfWork.Save();

            TempData["success"] = "Category deleted Successfully";

            return RedirectToAction(nameof(Index));
        }
    }
}
