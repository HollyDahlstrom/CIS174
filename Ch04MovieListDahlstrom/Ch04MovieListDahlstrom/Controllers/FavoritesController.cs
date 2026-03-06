using Ch04MovieListDahlstrom.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;

namespace Ch04MovieListDahlstrom.Controllers
{
    public class FavoritesController : Controller
    {
        private const string SessionKeyFavorites = "_Favorites";

        // Add a country to favorites
        public IActionResult Add(string country, string game, string type, string flagUrl)
        {
            var favorites = HttpContext.Session.GetString(SessionKeyFavorites);
            List<CountrySport> favList;

            if (string.IsNullOrEmpty(favorites))
            {
                favList = new List<CountrySport>();
            }
            else
            {
                favList = JsonSerializer.Deserialize<List<CountrySport>>(favorites);
            }

            // Avoid duplicates
            if (!favList.Exists(c => c.Country == country && c.Game == game))
            {
                favList.Add(new CountrySport
                {
                    Country = country,
                    Game = game,
                    Type = type,
                    FlagUrl = flagUrl
                });
            }

            HttpContext.Session.SetString(SessionKeyFavorites, JsonSerializer.Serialize(favList));

            TempData["Message"] = $"{country} added to favorites!";
            return RedirectToAction("Index", "Assignment71");
        }

        // Show all favorites
        public IActionResult Index()
        {
            var favorites = HttpContext.Session.GetString(SessionKeyFavorites);
            List<CountrySport> favList = string.IsNullOrEmpty(favorites)
                ? new List<CountrySport>()
                : JsonSerializer.Deserialize<List<CountrySport>>(favorites);

            return View(favList);
        }

        // Clear all favorites
        public IActionResult Clear()
        {
            HttpContext.Session.Remove(SessionKeyFavorites);
            TempData["Message"] = "Favorites cleared!";
            return RedirectToAction("Index");
        }
    }
}