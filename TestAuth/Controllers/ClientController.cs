using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAuth.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;
using TestAuth.Controllers;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace TestAuth.Controllers
{
    [Authorize]
    public class ClientController : Microsoft.AspNetCore.Mvc.Controller
    {
        Uri baseAddress = new Uri("http://localhost:21758/api");
        HttpClient client;
        public ClientController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        [Authorize (Roles = "admin")]
        public ActionResult Index()
        {
            List<Client> modelList = new List<Client>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Client").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<Client>>(data);
            }
            return View(modelList);
        }
        public ActionResult GetById()
        {
            var id = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            Client modelList = new Client();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Client/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<Client>(data);
            }
            return View(modelList);
        }

            // POST: User
        public ActionResult Create()
        {
        return View();
        }
        [HttpPost]
        public ActionResult Create(Client model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/Client", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit()
        {
            Client model = new Client();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Client/" + User.FindFirstValue(ClaimTypes.NameIdentifier)).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<Client>(data);
            }
            return View("Edit", model);
        }
        [HttpPost]
        public ActionResult Edit(Client model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/Client/" + User.FindFirstValue(ClaimTypes.NameIdentifier), content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetById");
            }
            return View("Edit", model);
        }
        public ActionResult Delete(Guid id)
        {
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/Client/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
