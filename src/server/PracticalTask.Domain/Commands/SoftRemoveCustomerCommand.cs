using System;
using PracticalTask.Domain.Validations;

namespace PracticalTask.Domain.Commands
{
    public class SoftRemoveCustomerCommand : CustomerCommand
    {
        public SoftRemoveCustomerCommand(Guid id)
        {
            Id = id;
            IsActive = false;
        }

        public override bool IsValid()
        {
            ValidationResult = new SoftRemoveCustomerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}