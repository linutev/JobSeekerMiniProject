using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobSeekerMiniProject.Domain.Data;
using JobSeekerMiniProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobSeekerMiniProject.Controllers
{
    public class JobSeekerController : Controller
    {
        JobSeekerContext _dbContext = new JobSeekerContext(new DbContextOptions<JobSeekerContext>());

        //private readonly JobSeekerContext _dbContext;

        //public JobSeekerController(JobSeekerContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details()
        {
            return View(await _dbContext.JobSeekers.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> SubmitJobSeekerDetail(JobSeekerViewmodel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    JobSeekerViewModel jobSeekerViewModel = new JobSeekerViewModel()
                    {
                        Name = model.Name,
                        Email = model.Email,
                        Phone = model.Phone,
                        Address = model.Address,
                        Skills = model.Skills,
                        DateInserted = DateTime.Now
                    };

                    _dbContext.JobSeekers.Add(jobSeekerViewModel);
                    _dbContext.SaveChanges();

                    TempData["SuccessMessage"] = "Your request successfully submitted.";

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