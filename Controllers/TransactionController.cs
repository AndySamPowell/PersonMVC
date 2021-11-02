using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using PersonApp.Models;

namespace PersonMVC.Controllers
{
    public class TransactionController : Controller
    {

        private readonly IHttpClientFactory _clientFactory;

        public TransactionController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "");
            var client = _clientFactory.CreateClient("transaction");
            var response = await client.SendAsync(request);
            IEnumerable<TransactionModel> transaction = null;
            JsonResult json = new JsonResult("");

            if (response.IsSuccessStatusCode)
            {
                transaction = await response.Content.ReadFromJsonAsync<IEnumerable<TransactionModel>>();

            }



            return View(transaction);
        }
    }
}
