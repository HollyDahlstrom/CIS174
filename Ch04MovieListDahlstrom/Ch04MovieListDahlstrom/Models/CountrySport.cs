using System.ComponentModel.DataAnnotations;

namespace Ch04MovieListDahlstrom.Models
{
    public class CountrySport
    {
        public int Id { get; set; }

        [Required]
        public string Country { get; set; } = string.Empty;

        [Required]
        public string Game { get; set; } = string.Empty;

        [Required]
        public string Sport { get; set; } = string.Empty;

        [Required]
        public string Type { get; set; } = string.Empty; 

        public string FlagUrl { get; set; } = string.Empty; 
    }
}