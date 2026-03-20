using Ch04MovieListDahlstrom.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Ch04MovieListDahlstrom.Controllers
{
    public class Assignment71Controller : Controller
    {
        [Route("Assignment71/{SelectedGame?}/{SelectedType?}")]
        public IActionResult Index(Assignment71ViewModel model)
        {
            // Default values if nothing selected
            if (string.IsNullOrEmpty(model.SelectedGame))
                model.SelectedGame = "ALL";

            if (string.IsNullOrEmpty(model.SelectedType))
                model.SelectedType = "ALL";

            // List of countries/sports
            var countries = new List<CountrySport>
            {
                new CountrySport { Country="Canada", Game="Winter Olympics", Sport="Curling", Type="Indoor", FlagUrl="/flags/canada.png" },
                new CountrySport { Country="Sweden", Game="Winter Olympics", Sport="Curling", Type="Indoor", FlagUrl="/flags/sweden.png" },
                new CountrySport { Country="Great Britain", Game="Winter Olympics", Sport="Curling", Type="Indoor", FlagUrl="/flags/uk.png" },
                new CountrySport { Country="Jamaica", Game="Winter Olympics", Sport="Bobsleigh", Type="Outdoor", FlagUrl="/flags/jamaica.png" },
                new CountrySport { Country="Italy", Game="Winter Olympics", Sport="Bobsleigh", Type="Outdoor", FlagUrl="/flags/italy.png" },
                new CountrySport { Country="Japan", Game="Winter Olympics", Sport="Bobsleigh", Type="Outdoor", FlagUrl="/flags/japan.png" },
                new CountrySport { Country="Germany", Game="Summer Olympics", Sport="Diving", Type="Indoor", FlagUrl="/flags/germany.png" },
                new CountrySport { Country="China", Game="Summer Olympics", Sport="Diving", Type="Indoor", FlagUrl="/flags/china.png" },
                new CountrySport { Country="Mexico", Game="Summer Olympics", Sport="Diving", Type="Indoor", FlagUrl="/flags/mexico.png" },
                new CountrySport { Country="Brazil", Game="Summer Olympics", Sport="Road Cycling", Type="Outdoor", FlagUrl="/flags/brazil.png" },
                new CountrySport { Country="Netherlands", Game="Summer Olympics", Sport="Cycling", Type="Outdoor", FlagUrl="/flags/netherlands.png" },
                new CountrySport { Country="USA", Game="Summer Olympics", Sport="Road Cycling", Type="Outdoor", FlagUrl="/flags/usa.png" },
                new CountrySport { Country="Thailand", Game="Paralympics", Sport="Archery", Type="Indoor", FlagUrl="/flags/thailand.png" },
                new CountrySport { Country="Uruguay", Game="Paralympics", Sport="Archery", Type="Indoor", FlagUrl="/flags/ur.png" },
                new CountrySport { Country="Ukraine", Game="Paralympics", Sport="Archery", Type="Indoor", FlagUrl="/flags/ukraine.png" },
                new CountrySport { Country="Austria", Game="Paralympics", Sport="Canoe Sprint", Type="Outdoor", FlagUrl="/flags/austria.png" },
                new CountrySport { Country="Pakistan", Game="Paralympics", Sport="Canoe Sprint", Type="Outdoor", FlagUrl="/flags/pakistan.png" },
                new CountrySport { Country="Zimbabwe", Game="Paralympics", Sport="Canoe Sprint", Type="Outdoor", FlagUrl="/flags/zimbabwe.png" },
                new CountrySport { Country="France", Game="Youth Olympic Games", Sport="Breakdancing", Type="Indoor", FlagUrl="/flags/france.png" },
                new CountrySport { Country="Cyprus", Game="Youth Olympic Games", Sport="Breakdancing", Type="Indoor", FlagUrl="/flags/cyprus.png" },
                new CountrySport { Country="Russia", Game="Youth Olympic Games", Sport="Breakdancing", Type="Indoor", FlagUrl="/flags/russia.png" },
                new CountrySport { Country="Finland", Game="Youth Olympic Games", Sport="Skateboarding", Type="Outdoor", FlagUrl="/flags/finland.png" },
                new CountrySport { Country="Slovakia", Game="Youth Olympic Games", Sport="Skateboarding", Type="Outdoor", FlagUrl="/flags/slovakia.png" },
                new CountrySport { Country="Portugal", Game="Youth Olympic Games", Sport="Skateboarding", Type="Outdoor", FlagUrl="/flags/port.png" }
            };

            var filtered = countries
                .Where(c => model.SelectedGame == "ALL" || c.Game == model.SelectedGame)
                .Where(c => model.SelectedType == "ALL" || c.Type == model.SelectedType)
                .OrderBy(c => c.Country)
                .ToList();

            model.Countries = filtered;
            model.Games = countries.Select(c => c.Game).Distinct().OrderBy(g => g).ToList();
            model.Types = countries.Select(c => c.Type).Distinct().OrderBy(t => t).ToList();

            return View(model);
        }
    }
}