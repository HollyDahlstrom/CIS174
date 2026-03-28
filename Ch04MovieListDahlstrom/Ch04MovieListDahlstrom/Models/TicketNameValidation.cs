using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Ch04MovieListDahlstrom.Models
{
    public class TicketNameValidation : ValidationAttribute, IClientModelValidator
    {
        private readonly string _clientForbidden = "HollyD";   // client-only
        private readonly string _serverForbidden = "ServerFail"; // server-only
        private readonly string _customForbidden = "TestTicket"; // custom

        // Server-side + Custom
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var str = value.ToString();
                if (str == _serverForbidden)
                    return new ValidationResult($"Server-side Validation: '{_serverForbidden}' is forbidden.");
                if (str == _customForbidden)
                    return new ValidationResult($"Custom Validation: '{_customForbidden}' is not allowed.");
            }
            return ValidationResult.Success;
        }

        // Client-side
        public void AddValidation(ClientModelValidationContext context)
        {
            if (!context.Attributes.ContainsKey("data-val"))
                context.Attributes.Add("data-val", "true");

            context.Attributes.Add("data-val-ticketname", GetErrorMessage());
            context.Attributes.Add("data-val-ticketname-client", _clientForbidden);
        }

        public string GetErrorMessage() => $"Client-side Validation: '{_clientForbidden}' is forbidden.";
    }
}