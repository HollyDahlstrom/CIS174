using System.ComponentModel.DataAnnotations;


namespace Ch04MovieListDahlstrom.Models
{
    public class Movie
    {
        // EF Core will configure the database to generate this value
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        [MaxLength(200)] // SQLite-friendly
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a year.")]
        [Range(1889, 2999, ErrorMessage = "Year must be after 1889.")]
        public int Year { get; set; }  // Changed from int? to int for simplicity

        [Required(ErrorMessage = "Please enter a rating.")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }  // Changed from int? to int

        [Required(ErrorMessage = "Please enter a genre.")]
        [MaxLength(10)] // SQLite-friendly for foreign key
        public string GenreId { get; set; } = string.Empty;

        // Navigation property
        public Genre? Genre { get; set; }

        // Slug helper
        public string Slug =>
            Name.Replace(' ', '-').ToLower() + '-' + Year.ToString();
    }
}