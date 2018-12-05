using System;
using FluentValidation;
using PracticalTask.Domain.Commands;

namespace PracticalTask.Domain.Validations
{
    public abstract class CustomerValidation<T> : AbstractValidator<T> where T : CustomerCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }

        protected void ValidateSoftDelete()
        {
            RuleFor(c => c.IsActive)
                .Must(NotDeleted)
                .WithMessage("The customer is deleted");
        }


        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected static bool NotDeleted(bool isActive)
        {
            return isActive == true;
        }
    }
}