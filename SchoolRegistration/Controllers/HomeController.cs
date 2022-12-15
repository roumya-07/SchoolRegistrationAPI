using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SchoolRegistration.Models;
using SchoolRegistrationAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegistration.Controllers
{
    public class HomeController : Controller
    {
        Uri baseAdd = new Uri("http://localhost:11354/api");

        HttpClient client;
        public HomeController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAdd;
        }
        public async Task<IActionResult> Index()
        {
            List<State> lstcat = new List<State>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/State").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                lstcat = JsonConvert.DeserializeObject<List<State>>(data);
                lstcat.Insert(0, new State { StateID = 0, StateName = "Select One" });
                ViewBag.State = lstcat;
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate(SchoolRegistrationEntity SR)
        {
            string data = JsonConvert.SerializeObject(SR);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/School/" + SR.SchoolID, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<JsonResult> GetSchool()
        {
            string data = null;
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/School").Result;
            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadAsStringAsync().Result;
            }
            return Json(data);
        }
        public async Task<JsonResult> District_Bind(int StateID)
        {
            string data = null;
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/District/" + StateID).Result;
            List<SelectListItem> scalist = new List<SelectListItem>();
            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadAsStringAsync().Result;
                var lstscat = JsonConvert.DeserializeObject<List<District>>(data);
                foreach (District dr in lstscat)
                {
                    scalist.Add(new SelectListItem { Text = dr.DistrictName, Value = dr.DistrictID.ToString() });
                }
            }
            var jsonres = JsonConvert.SerializeObject(scalist);
            return Json(jsonres);
        }
    }
}
