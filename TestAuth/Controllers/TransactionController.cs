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
    public class TransactionController : Microsoft.AspNetCore.Mvc.Controller
    {
        Uri baseAddress = new Uri("http://localhost:21758/api");
        HttpClient wallet;
        public TransactionController()
        {
            wallet = new HttpClient();
            wallet.BaseAddress = baseAddress;
        }
        public ActionResult Index()
        {
            List<Transaction> modelList = new List<Transaction>();
            HttpResponseMessage response = wallet.GetAsync(wallet.BaseAddress + "/Transaction").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<Transaction>>(data);
            }
            return View(modelList);
        }
        public ActionResult GetById()
        {
            Transaction modelList = new Transaction();
            HttpResponseMessage response = wallet.GetAsync(wallet.BaseAddress + "/Transaction/" + User.FindFirstValue(ClaimTypes.NameIdentifier)).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<Transaction>(data);
            }
            return View(modelList);
        }

            // POST: User
            public ActionResult Create()
            {
                return View();
            }
        [HttpPost]
        public ActionResult Create(Transaction transaction)
        {
            string data = JsonConvert.SerializeObject(transaction);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = wallet.PostAsync(wallet.BaseAddress + "/Transaction", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete(Guid id)
        {
            HttpResponseMessage response = wallet.DeleteAsync(wallet.BaseAddress + "/Transaction/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
