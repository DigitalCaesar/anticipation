# Anticipation

Anticipation is a library to promote proactive error management over reactive exception handling.

## Usage

### Creating an Error
An Error takes at a minimum, an error code and an error message and assumes an ErrorType of Warning.  

The code can be any string that is meaningful to you.  It could be a short phrase or a number that helps you quickly recognize the category of error that occurred.  It could also be a GUID or other identifier from your application or database.  

The description should be a string that describes the error in more detail.  Keep in mind, this is the message that will be returned to the user and so should be a user friendly and meaningful message.

```
Error CustomError = new("0001", "This is a sample error.");
Error CustomErrorWarning = new("0002", "This is a sample warning error.", ErrorType.Warning);
Error CustomErrorException = new("0003", "This is a sample exception error.", ErrorType.Exception);
```

### Returning an Error

Methods typically have two possible paths - success and failure.  Success typically returns some value or, in the case of a void method, returns nothing.  A failure would return an Error which is likely not the same type as the value the method should return in the case of success.  

One way to handle the two possible outcomes is to create a Result type that can contain both the value and the error.  Then, the method that wants to use Error can return a result with an Error in case of failure.

```
public record SampleResult (string Value, Error Error);

public SampleResult SampleMethod()
{
    try
    {
        return new SampleResult("Some value.", null);
    }
    catch (Exception ex)
    {
        return new SampleResult(null, new("0001", "Some error.", ex));
    }
}
```

An alternative is to use a discriminated union.  Check out [Digital Results](https://github.com/DigitalCaesar/digitalresults) for an example of how this is done.  The package is available on [NuGet](https://www.nuget.org/packages/DigitalResults).

### Handling an Error

Handling the error is as simple as checking if an Error was returned and then taking the appropriate action.  In this case, a console application would simply return the Error Message to the client. 

```
if (result.Error is null)
    Console.WriteLine("The operation was successful.);
else
    Console.WriteLine($"The operation failed with error {result.Error.Code}.");
```

### Predefined Errors

Errors can be predefined in a variety of ways including setting constants.  Creating a static class with static errors allows you to bundle errors in one or a limited number of places.  

A top level static class is a good place to start.  That will give you one place to go to find your errors.  For example, you could have a static class for each layer of your application.  This would allow you to have a single place to look for errors in each layer and make it easy to tell where each Error originated from.  

You could also have a static class for each type that returns an error.  For example, you could have a static class for all errors related to a specific domain object.  This would allow you to have a single place to look for errors related to a specific domain object.  This practice also helps you organize and focus on related objects.

Errors can be used in combination with project resources to produce localized error messages.  This is a great way to provide a user friendly message to the client while still providing a meaningful error code to the developer.  The error code can be used to look up the error message in the resource file.  The error message can then be returned to the client.

```
public static class ApplicationErrors
{
    public static Error CustomError = new("0001", "This is a sample error.");
}
```

## Documentation

Check out the product page at [DigitalCaesar.com](https://digitalcaesar.com/products/anticipation) for more information.

## Contributing

Would you like to contribute?  The project is available on [GitHub](https://github.com/DigitalCaesar/anticipation) and we welcome your pull requests and issues.

## License

Copyright © Digital Caesar LLC