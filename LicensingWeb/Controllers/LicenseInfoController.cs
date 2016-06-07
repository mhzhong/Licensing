using LicensingWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LicensingWeb.Controllers
{
    public class LicenseInfoController : Controller
    {
         HttpClient client;
        //The URL of the WEB API Service
        string url = "http://localhost:57696/api/license";
         
        //The HttpClient Class, this will be used for performing 
        //HTTP Operations, GET, POST, PUT, DELETE
        //Set the base address and the Header Formatter
        public LicenseInfoController()
        {
            client = new HttpClient();  
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 
        }

        // GET: License
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var Licenses = JsonConvert.DeserializeObject<List<License>>(responseData);

                return View(Licenses);
            }
            return View("Error");


            //HttpResponseMessage responseMessage = new HttpResponseMessage();
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
            //    var Licenses = JsonConvert.DeserializeObject<List<License>>(responseData);
            //    return View(Licenses);
            //}
            //return View("Error");
        }

        //public ActionResult Create()
        //{
        //    return View(new EmployeeInfo());
        //}

    }
}
