
using CreatingYourFirstValidator;

var user = new User { Name = "John", Email = "john@example.com", Age = 25 };
var validator = new UserValidator();
var results = validator.Validate(user);

if (!results.IsValid)
{
    foreach (var failure in results.Errors)
    {
        Console.WriteLine($"Property {failure.PropertyName} failed validation. Error was: {failure.ErrorMessage}");
    }
}


Console.ReadKey();
