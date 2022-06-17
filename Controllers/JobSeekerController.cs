using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobSeekerMiniProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobSeekerMiniProject.Controllers
{
    public class JobSeekerController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitJobSeekerDetail(JobSeekerViewmodel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["SuccessMessage"] = "Your request successfully submitted.";

                    // Save data to DB

                    return RedirectToAction("Index", "JobSeeker");
                }
                else
                {
                    TempData["ErrorMessage"] = "There are errors on a form. Please fix them and try again.";
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "There was an error submitting a request. Try again later.";
                return View(model);
            }

        }
    }
}