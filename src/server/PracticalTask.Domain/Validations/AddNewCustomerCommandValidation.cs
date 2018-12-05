using PracticalTask.Domain.Commands;

namespace PracticalTask.Domain.Validations
{
    public class AddNewCustomerCommandValidation : CustomerValidation<AddNewCustomerCommand>
    {
        public AddNewCustomerCommandValidation()
        {
            ValidateName();
            ValidateSoftDelete();
        }
    }
}