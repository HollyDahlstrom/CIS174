using System.Collections.Generic;

namespace Ch04MovieListDahlstrom.Models
{
    public class Assignment71ViewModel
    {
        public List<CountrySport> Countries { get; set; } = new List<CountrySport>();

        public string SelectedGame { get; set; } = "ALL";
        public string SelectedType { get; set; } = "ALL";

        public List<string> Games { get; set; } = new List<string>();
        public List<string> Types { get; set; } = new List<string>();
    }
}