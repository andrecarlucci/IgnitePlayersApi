using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PlayersApi {
    public class PlayerIsUniqueAttribute : ValidationAttribute {

        protected override ValidationResult IsValid(object value, 
                                                    ValidationContext validationContext) {
            var repository = validationContext.GetService(typeof(IPlayersRepository)) as IPlayersRepository;
            if (repository.List().Result
                          .Any(p => string.Equals(p.Name, value?.ToString(), StringComparison.InvariantCultureIgnoreCase))) {
                return new ValidationResult($"Username {value} is taken");
            }
            return ValidationResult.Success;

        }
    }
}