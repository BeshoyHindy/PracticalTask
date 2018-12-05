using PracticalTask.Domain.Commands;

namespace PracticalTask.Domain.Validations
{
    public class SoftRemoveCustomerCommandValidation : CustomerValidation<SoftRemoveCustomerCommand>
    {
        public SoftRemoveCustomerCommandValidation()
        {
            ValidateId();
        }
    }
}