namespace GroupingAndReusingValidationRules;

using FluentValidation;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        // RuleSet for creating a new customer
        RuleSet("Creation", () =>
        {
            RuleFor(customer => customer.Name)
                .NotEmpty()
                .WithMessage("First name is required.");

            RuleFor(customer => customer.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("A valid email address is required.");
        });

        // RuleSet for updating an existing customer
        RuleSet("Update", () =>
        {
            RuleFor(customer => customer.Id)
                .NotEmpty()
                .WithMessage("Customer ID is required.");

            RuleFor(customer => customer.Name)
                .NotEmpty()
                .WithMessage("First name is required.");

            RuleFor(customer => customer.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("A valid email address is required.");
        });
    }
}