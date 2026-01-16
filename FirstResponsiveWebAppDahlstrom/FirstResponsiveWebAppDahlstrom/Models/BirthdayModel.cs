// Name: Holly Dahlstrom
// Class: DMACC CIS 174
// Date: 1/15/2026
// Assignment: First Responsive Web App
// Description: Model class for user input and age calculations.

using System.ComponentModel.DataAnnotations;

namespace FirstResponsiveWebAppDahlstrom.Models
{
    public class BirthdayModel
    {
        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your birth year.")]
        [Range(1900, 2100, ErrorMessage = "Birth year must be between 1900 and 2100.")]
        public int? BirthYear { get; set; }

        [Required(ErrorMessage = "Please enter your birth month.")]
        [Range(1, 12, ErrorMessage = "Month must be between 1 and 12.")]
        public int? BirthMonth { get; set; }

        [Required(ErrorMessage = "Please enter your birth day.")]
        [Range(1, 31, ErrorMessage = "Day must be between 1 and 31.")]
        public int? BirthDay { get; set; }

        // Age on December 31 of this year
        public int? AgeThisYear()
        {
            if (BirthYear.HasValue)
                return DateTime.Now.Year - BirthYear.Value;
            return null;
        }

        // Exact age today
        public int? AgeToday()
        {
            if (BirthYear.HasValue && BirthMonth.HasValue && BirthDay.HasValue)
            {
                var today = DateTime.Today;
                var birthDate = new DateTime(BirthYear.Value, BirthMonth.Value, BirthDay.Value);
                int age = today.Year - birthDate.Year;

                // If birthday hasn't happened yet this year, subtract 1
                if (birthDate > today.AddYears(-age))
                    age--;

                return age;
            }
            return null;
        }
    }
}