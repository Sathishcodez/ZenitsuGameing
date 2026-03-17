using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZenitsuGameing.DataAccess.Repositories.IRepository;
using ZenitsuGameing.Migrations;
using ZenitsuGameing.Models;
using ZenitsuGameing.Models.ViewModels;
using ZenitsuGameing.Utility;

namespace ZenitsuGameing.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(UserRole.AdminRole)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Company> Companys = _unitOfWork.Company.GetAll().ToList();

            return View(Companys);
        }
        public IActionResult Upsert(int? companyId)
        {
            if (companyId == null || companyId == 0)
            {
                //create
                return View(new Company());
            }
            else
            {
                //update
                Company company = _unitOfWork.Company.GetFirstOrDefault(d => d.CompanyId == companyId);
                return View(company);
            }
        }

        [HttpPost]
        public IActionResult upsert(Company companyObj)
        {
            if (ModelState.IsValid)
            {                

                if (companyObj.CompanyId == 0)
                {
                    _unitOfWork.Company.Add(companyObj);
                }
                else
                {
                    _unitOfWork.Company.Update(companyObj);
                }

                _unitOfWork.Save();
                TempData["success"] = "Company Created Successfull";
                return RedirectToAction("index");
            }
            return View(companyObj);
        }

        #region API Calls

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> CompanyList = _unitOfWork.Company.GetAll().ToList();
            return Json(new { data = CompanyList });
        }

        public IActionResult Delete(int? id)
        {
            var CompanyToBeDeleted = _unitOfWork.Company.GetFirstOrDefault(u => u.CompanyId == id);
            if (CompanyToBeDeleted == null)
            {
                return Json(new { success = false, Message = "Error while deleting" });
            }

            _unitOfWork.Company.Remove(CompanyToBeDeleted);
            _unitOfWork.Save();


            List<Company> CompanyList = _unitOfWork.Company.GetAll().ToList();
            return Json(new { success = true, Message = "Deleted Successfully" });
        }

        #endregion
    }
}
