using PracticalTask.Domain.Validations;

namespace PracticalTask.Domain.Commands
{
    public class AddNewCustomerCommand : CustomerCommand
    {
        public AddNewCustomerCommand(string name, bool isActive)
        {
            Name = name;
            IsActive = isActive;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddNewCustomerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}