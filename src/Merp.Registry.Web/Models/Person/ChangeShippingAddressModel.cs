using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Merp.Registry.Web.Models.Person
{
    public class ChangeShippingAddressModel : IValidatableObject
    {
        [DisplayName("Address")]
        public PostalAddress Address { get; set; }

        public DateTime EffectiveDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(Address.Address))
            {
                validationResults.Add(new ValidationResult($"{nameof(Address.Address)} is required", new[] { $"{nameof(Address)}.{nameof(Address.Address)}" }));
            }

            if (string.IsNullOrWhiteSpace(Address.City))
            {
                validationResults.Add(new ValidationResult($"{nameof(Address.City)} is required", new[] { $"{nameof(Address)}.{nameof(Address.City)}" }));
            }

            if (EffectiveDate > DateTime.Now)
            {
                validationResults.Add(new ValidationResult($"The {nameof(Address)} change cannot be scheduled in the future", new[] { $"{nameof(EffectiveDate)}" }));
            }

            return validationResults;
        }
    }
}
