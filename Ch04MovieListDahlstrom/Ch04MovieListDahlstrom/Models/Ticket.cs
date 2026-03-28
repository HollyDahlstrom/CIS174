using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Ch04MovieListDahlstrom.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }

        [Required(ErrorMessage = "Please enter a ticket name.")]
        [TicketNameValidation]
        [StringLength(50, ErrorMessage = "Ticket name must be 50 characters or less.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a description.")]
        [StringLength(200, ErrorMessage = "Description must be 200 characters or less.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter sprint number.")]
        [Range(1, 10, ErrorMessage = "Sprint number must be between 1 and 10.")]
        public int SprintNumber { get; set; }

        [Required(ErrorMessage = "Please enter point value.")]
        [Range(1, 20, ErrorMessage = "Point value must be between 1 and 20.")]
        public int PointValue { get; set; }

        [Required(ErrorMessage = "Please select a status.")]
        public string StatusId { get; set; } = "To Do";

        [ValidateNever]
        public Status Status { get; set; } = null!;

        public bool IsComplete => StatusId == "Done";
    }
}