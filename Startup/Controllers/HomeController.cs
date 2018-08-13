using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Startup.Models;
using Startup.Services;

namespace Startup.Controllers
{
    public class HomeController : Controller
    {
        private DatabaseService databaseService = new DatabaseService();

        public IActionResult Index()
        {
            List<TestDataModel> testData = databaseService.GetTestData(2);
            
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    /*
     Connection String
     Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StartupDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
     */
}
