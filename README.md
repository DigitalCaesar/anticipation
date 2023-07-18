[![Build Status](https://dev.azure.com/DigitalCaesarLLC/Anticipation/_apis/build/status%2FDigitalCaesar.anticipation?repoName=DigitalCaesar%2Fanticipation&branchName=main)](https://dev.azure.com/DigitalCaesarLLC/Anticipation/_build/latest?definitionId=34&repoName=DigitalCaesar%2Fanticipation&branchName=main)
[![NuGet Version (DigitalResults)](https://img.shields.io/nuget/dt/Anticipation)](https://www.nuget.com/packages/Anticipation/)

# Introduction
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

Errors can be predefined in static classes for easy reference.

```
public static class ApplicationErrors
{
    public static Error CustomError = new("0001", "This is a sample error.");
}

return ApplicationErrors.CustomError

```




## Contribute
Do you like what you see and do you want to help contribute to the community?  Send feedback, submit issues, and submit pull requests!  Want to go further?  Consider sponsoring this project or check out the website to see how you can donate or buy me a coffee.  Caffiene is always welcome.  

### Projects
This is a single project solution. 

Project | Description
--------|------------
Anticipation   | Main project for the package
Samples | Sample project to illustrate usage of the package

### Build
Builds are run on Azure DevOps.  The build pipeline is cake-build-pipelines.yml run on Azure DevOps.  Builds are triggered by any develop, release, or main branch updates.  

Cake is used builds with the single script, build.cake.  Builds can be run locally with cake as normal 'dotnet cake' from the root project folder.  The build script will run the build, test, and pack tasks.  If you are not familiar with cake, then check the documentation on their website, https://cakebuild.net/. 

### Test
Testing is provided by Unit Test and Integration Test projects which are required to pass before build and packaging. 

### Release 
Release Pipelines are defined on Azure Devops.  Only main and release branch updates trigger releases.  Pre-Release distribution is triggered by release branch updates.  Production distribution is triggered by main branch updates.  Releases are first pushed to an internal store pending approval for public release.

Versions from a release branch will have a '-preview' suffix added.  Versions from main will have no suffix.  Versioning is handled by Nerdbank.GitVersioning.  See their documentation for more information.

## Credits
There are currently no third party package dependencies.

This implementation was inspired by tutorials from Milan Jovanovic and existing libraries ErrorOr and OneOf.  Each has an elements that I prefer and do not prefer.  The purpose of this library is to bring together the preferable elements and adapt for specific needs.  
Inspiration derived from: 
* Milan Jovanovic - [YouTube series](https://www.youtube.com/playlist?list=PLYpjLpq5ZDGstQ5afRz-34o_0dexr1RGa)
* [ErrorOr](https://github.com/amantinband/error-or/blob/main/README.md): Amichai Mantinband
* [OneOf](https://github.com/mcintyre321/OneOf/blob/master/README.md): Harry McIntyre

