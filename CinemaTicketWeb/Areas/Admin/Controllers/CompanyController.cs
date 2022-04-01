using CinemaTicket.Core.Contracts;
using CinemaTicket.Models;
using CinemaTicket.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketWeb.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = SD.Role_Admin)]
public class CompanyController : Controller
{
    private readonly ICompanyService companyService;

    public CompanyController(ICompanyService _companyService)
    {
       companyService = _companyService;
    }

    public IActionResult Index()
    {
        return View();
    }

    //GET
    public IActionResult Upsert(int? id)
    {
        Company company = new();

        if (id is null or 0)
        {
            return View(company);
        }
        else
        {
            company = companyService.GetCompany(id);
            return View(company);
        }
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(Company obj, IFormFile? file)
    {

        if (ModelState.IsValid)
        {
            
            if (obj.Id == 0)
            {
                companyService.AddCompany(obj,file);
                TempData["success"] = "Company created successfully";
            }
            else
            {
                companyService.UpdateCompany(obj,file);
                TempData["success"] = "Company updated successfully";
            }
            
            
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    #region API CALLS
    [HttpGet]
    public IActionResult GetAll()
    {
        var companyList = companyService.GetAllCompanies();
        return Json(new { data = companyList });
    }

    //POST
    [HttpDelete]
    public IActionResult Delete(int? id)
    {
        var obj = companyService.GetCompany(id);
        if (obj == null)
        {
            return Json(new { success = false, message = "Error while deleting" });
        }

        companyService.DeleteCompany(obj);
        return Json(new { success = true, message = "Delete Successful" });

    }
    #endregion
}