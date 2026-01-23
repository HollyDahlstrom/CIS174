using System.ComponentModel.DataAnnotations;

namespace ContactsAppDahlstrom.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\d{3}-?\d{3}-?\d{4}$",
            ErrorMessage = "Phone number must be in the format XXX-XXX-XXXX")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [StringLength(100, ErrorMessage = "Address cannot be longer than 100 characters")]
        public string Address { get; set; }

        [StringLength(200, ErrorMessage = "Note cannot be longer than 200 characters")]
        public string Note { get; set; }
    }
}