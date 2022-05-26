using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UserFind5._0.Models;
using Google.Apis.Services;
using System.Text.Json;

namespace UserFind5._0.Controllers
{
    // AIzaSyB5dtJdnOt3d2Izgt2rjk_99fx0WrRapjA 
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(  string firstName, string secondName,  string topic) 
        {
            string apiKey = "AIzaSyB5dtJdnOt3d2Izgt2rjk_99fx0WrRapjA";
            string cx = "81abd3a4213a10651";
            string query = $"{firstName} {secondName}";
            var svc = new Google.Apis.Customsearch.v1.CustomsearchService(new BaseClientService.Initializer { ApiKey = apiKey });
            var listRequest = svc.Cse.List();
            listRequest.Q = query;
            listRequest.Cx = cx;
            var result = listRequest.Execute();
            List<Google.Apis.Customsearch.v1.Data.Result> items = result.Items.ToList();
            return View("Result",items);
        }

        [HttpPost]
        public string SearchJson(string firstName, string secondName, string topic) 
        {
            string apiKey = "AIzaSyB5dtJdnOt3d2Izgt2rjk_99fx0WrRapjA";
            string cx = "81abd3a4213a10651";
            string query = $"{firstName} {secondName}";
            var svc = new Google.Apis.Customsearch.v1.CustomsearchService(new BaseClientService.Initializer { ApiKey = apiKey });
            var listRequest = svc.Cse.List();
            listRequest.Q = query;
            listRequest.Cx = cx;
            var result = listRequest.Execute();
            List<Google.Apis.Customsearch.v1.Data.Result> items = result.Items.ToList();
            return JsonSerializer.Serialize(items);
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