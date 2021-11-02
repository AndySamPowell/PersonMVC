using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using PersonApp.Models;

namespace PersonApp.Controllers
{
    public class PersonController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public PersonController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "");
            var client = _clientFactory.CreateClient("person");
            var response = await client.SendAsync(request);

            IEnumerable<PersonModel> person = null;
            JsonResult json = new JsonResult("");

            if (response.IsSuccessStatusCode)
            {
                person = await response.Content.ReadFromJsonAsync<IEnumerable<PersonModel>>();

            }



            return View(person);
        }


        public async Task<IActionResult> Edit(int? code)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, code.ToString());
            //var client = _clientFactory.CreateClient("person");
            //var response =  await client.SendAsync(request);
            //if (code == null || code == 0)
            //{
            //    return NotFound();
            //}

            //var obj = await response.Content.ReadFromJsonAsync<IEnumerable<PersonModel>>.Find(code);
            //if (obj == null)
            //{
            //    return NotFound();
            //}

            return View();
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PersonModel obj)
        {
            if (ModelState.IsValid)
            {
                //_db.ApplicationType.Update(obj);
                //_db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);


        }
    }
}
