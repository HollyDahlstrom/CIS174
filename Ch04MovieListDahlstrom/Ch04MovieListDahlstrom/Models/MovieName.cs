using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Ch04MovieListDahlstrom.Models
{
    public class MovieName : ValidationAttribute, IClientModelValidator
    {
        public MovieName()
        {
        }

        // Server-side validation
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            return value != null && value.ToString() != "HollyDahlstrom" ? ValidationResult.Success : new ValidationResult(GetErrorMessage());
        }

        // Custom error message
        public string GetErrorMessage()
        {
            return "Custom Validation: Do not use your first name.";
        }

        // Client-side validation setup
        public void AddValidation(ClientModelValidationContext context)
        {
            if (!context.Attributes.ContainsKey("data-val"))
                context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-moviename-name", "HollyD");
            context.Attributes.Add("data-val-moviename", GetErrorMessage());
        }
    }
}