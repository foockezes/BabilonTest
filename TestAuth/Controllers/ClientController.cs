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

namespace TestAuth.Controllers
{
    public class ClientController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:21758/api");
        HttpClient client;
        public ClientController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        public ActionResult Index(int ClientCode)
        {
            Client model = new Client();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Client/" + ClientCode).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<Client>(data);
            }
            return View("Create", model);
        }
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
