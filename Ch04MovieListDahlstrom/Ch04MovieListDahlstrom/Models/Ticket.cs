using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Ch04MovieListDahlstrom.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }

        [Required(ErrorMessage = "Please enter a ticket name.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a description.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter sprint number.")]
        public int SprintNumber { get; set; }

        [Required(ErrorMessage = "Please enter point value.")]
        public int PointValue { get; set; }

        [Required(ErrorMessage = "Please select a status.")]
        public string StatusId { get; set; } = "To Do";

        [ValidateNever]
        public Status Status { get; set; } = null!;

        public bool IsComplete => StatusId == "Done";
    }
}