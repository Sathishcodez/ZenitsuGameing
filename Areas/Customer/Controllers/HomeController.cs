using System.Collections;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ZenitsuGameing.DataAccess.Repositories.IRepository;
using ZenitsuGameing.Models;

namespace ZenitsuGameing.Areas.Customer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _unitOfWork.Product.GetAll(includeprop:"Category");
            return View(products);
        }
        public IActionResult Details(int id)
        {
            Product products = _unitOfWork.Product.GetFirstOrDefault(u=>u.Id==id,includeprop: "Category");
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
