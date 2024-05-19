using GroupingAndReusingValidationRules;
using FluentValidation;

ValidateCustomer();
ValidatePerson();

void ValidateCustomer()
{
    var customerValidator = new CustomerValidator();

    var newCustomer = new Customer
    {
        Name = "John Doe",
        Email = "john.doe@example.com"
    };
    var creationResults = customerValidator.Validate(newCustomer, 
        strategy => strategy.IncludeRuleSets("Creation"));

    var existingCustomer = new Customer
    {
        Id = 1,
        Name = "Jane Doe",
        Email = "jane.doe@example.com"
    };
    var updateResults = customerValidator.Validate(existingCustomer, strategy => strategy.IncludeRuleSets("Update"));

    if (!creationResults.IsValid || !updateResults.IsValid)
    {
        foreach (var failure in creationResults.Errors)
        {
            Console.WriteLine($"Property {failure.PropertyName} failed validation. Error: {failure.ErrorMessage}");
        }
        foreach (var failure in updateResults.Errors)
        {
            Console.WriteLine($"Property {failure.PropertyName} failed validation. Error: {failure.ErrorMessage}");
        }
    }
    else
    {
        Console.WriteLine("Both customers are valid!");
    }
}

void ValidatePerson()
{
    var personValidator = new PersonValidator();

    var person = new Person()
    {
        Age = 1,
        Name = "John Doe",
    };
    var creationResults = personValidator.Validate(person);
    
    if (!creationResults.IsValid)
    {
        foreach (var failure in creationResults.Errors)
        {
            Console.WriteLine($"Property {failure.PropertyName} failed validation. Error: {failure.ErrorMessage}");
        }
    }
    else
    {
        Console.WriteLine("Person is valid!");
    }
}