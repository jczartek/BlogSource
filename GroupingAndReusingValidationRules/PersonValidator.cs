using FluentValidation;

namespace GroupingAndReusingValidationRules;

public class PersonAgeValidator : AbstractValidator<Person>
{
    public PersonAgeValidator()
    {
        RuleFor(person => person.Age)
            .GreaterThan(0).WithMessage("Age must be greater than 0");
    }
}

public class PersonNameValidator : AbstractValidator<Person>
{
    public PersonNameValidator()
    {
        RuleFor(person => person.Name)
            .NotEmpty().WithMessage("Name is required");
    }
}

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        Include(new PersonAgeValidator());
        Include(new PersonNameValidator());
    }
}