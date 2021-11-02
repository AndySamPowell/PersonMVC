using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using PersonApp.Models;
using System.Net.Http.Json;

namespace PersonMVC.Controllers
{
    public class AccountController : Controller
    {

        private readonly IHttpClientFactory _clientFactory;

        public AccountController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<IActionResult> Index(int code)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "");
            var client = _clientFactory.CreateClient("account");
            var response = await client.SendAsync(request);
                        IEnumerable<AccountModel> account = null;
            JsonResult json = new JsonResult("");

            if (response.IsSuccessStatusCode)
            {
                account = await response.Content.ReadFromJsonAsync<IEnumerable<AccountModel>>();

            }



            return View(account);
        }
    }
}
