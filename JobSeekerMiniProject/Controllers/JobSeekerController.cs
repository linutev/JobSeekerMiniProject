using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobSeekerMiniProject.Database;
using JobSeekerMiniProject.Interfaces;
using JobSeekerMiniProject.Models;
using JobSeekerMiniProject.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobSeekerMiniProject.Controllers
{
    public class JobSeekerController : Controller
    {
        private readonly IJobSeekerRepository _jobSeekerRepository;

        public JobSeekerController(IJobSeekerRepository jobSeekerRepository)
        {
            _jobSeekerRepository = jobSeekerRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details()
        {
            try
            {
                return View(await _jobSeekerRepository.GetJobSeekers());
            }
            catch (KeyNotFoundException)
            {
                TempData["ErrorMessage"] = "No job seekers found.";
                return View();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error searching for job seekers.";
                return View();
            }
            
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

                    // Call repository 
                    await _jobSeekerRepository.AddJobSeeker(jobSeekerViewModel);

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