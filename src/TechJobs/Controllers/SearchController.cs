using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // Create a Results action method to process 
        // search request and display results
        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.columns = ListController.columnChoices;

            List<Dictionary<string, string>> jobs;
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return View("Index");
            }
            if (searchType.Equals("all"))
            {
                {
                    jobs = JobData.FindByValue(searchTerm);
                }
            }
            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }

            ViewBag.jobs = jobs;


            return View("Index");
        }

    }
}
