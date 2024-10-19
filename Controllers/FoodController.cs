using FoodDelivery4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FoodDelivery4.Controllers
{
    public class FoodController : Controller
    {
        // GET: FoodController
        public async Task<ActionResult> Index()
        {
            string apiUrl = "https://localhost:7296/api/food";

            List<food> users = new List<food>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                var result = await response.Content.ReadAsStringAsync();
                users = JsonConvert.DeserializeObject<List<food>>(result);
            }

            return View(users);
        }
        // GET: FoodController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FoodController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FoodController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(food user)
        {
            string apiUrl = "https://localhost:7296/api/food";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(user);
        }
        // GET: FoodController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FoodController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FoodController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FoodController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
