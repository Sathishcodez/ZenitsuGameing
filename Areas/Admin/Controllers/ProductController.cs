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
            IEnumerable<Product> products  = _unitOfWork.Product.GetAll(includeprop:"Category");

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
                productVM.Product = _unitOfWork.Product.GetFirstOrDefault(d => d.Id == id, includeprop: "Category");
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

                    if (obj.Product.ImageUrl != null)
                    {
                        var oldImg = Path.Combine(wwwRootPath, obj.Product.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImg))
                        {
                            System.IO.File.Delete(oldImg);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productpath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    obj.Product.ImageUrl = @"\images\products\" + fileName;
                }

                if (obj.Product.Id == 0)
                {
                    _unitOfWork.Product.Add(obj.Product);
                }
                else
                {
                    _unitOfWork.Product.update(obj.Product);
                }
                    
                _unitOfWork.Save();
                TempData["success"] = "Product Created Successfull";
                return RedirectToAction("index");
            }
            return View(obj);
        }

        #region API Calls

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> productList = _unitOfWork.Product.GetAll(includeprop: "Category").ToList();
            return Json(new { data = productList });
        }

        public IActionResult Delete(int? id)
        {
            var productToBeDeleted = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);
            if (productToBeDeleted == null)
            {
                return Json(new { success = false, Message = "Error while deleting" });
            }
            var oldImg = Path.Combine(_hostEnvironment.WebRootPath, productToBeDeleted.ImageUrl.TrimStart('\\'));

            if (System.IO.File.Exists(oldImg))
            {
                System.IO.File.Delete(oldImg);
            }

            _unitOfWork.Product.Remove(productToBeDeleted);
            _unitOfWork.Save();


            List<Product> productList = _unitOfWork.Product.GetAll(includeprop: "Category").ToList();
            return Json(new { success = true, Message = "Deleted Successfully" });
        }

            #endregion
    }
}
