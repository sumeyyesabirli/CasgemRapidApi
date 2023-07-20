using CasgemRapidApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace CasgemRapidApi.Controllers
{
    public class ImdbController : Controller
    {
        public async Task<IActionResult> Index()
        {
            //List<ImdMovieListViewModel> model = new List<ImdMovieListViewModel>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
    {
        { "X-RapidAPI-Key", "f2aca2c6b5msh6e1ed4b2f16a931p170f45jsndf22767a5549" },
        { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                 var model= JsonConvert.DeserializeObject<List<ImdMovieListViewModel>>(body);
                return View(model.ToList());
            }
           
        }
    }
}
