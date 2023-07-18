using DigitalCaesar.Anticipation;
using FluentAssertions;

namespace DigitalResults.UnitTests.Errors;
public class ErrorGeneric_Test
{
    #region Test Data
    private const string cDefaultErrorCode = "TestError";
    private const string cDefaultErrorMessage = "Test Error Message";
    private const string cDefaultErrorData = "Test Data";
    public static IEnumerable<object[]> GetStringValues()
    {
        yield return new object[] { "Test Code" };
        yield return new object[] { string.Empty };
    }
    public static IEnumerable<object[]> GetExceptionValues()
    {
        yield return new object[] { new Exception() };
        yield return new object[] { new ArgumentException() };
    }
    #endregion

    #region Constructor Tests
    [Fact]
    public void Constructor_Default_Test()
    {
        // Arrange
        Error<string> TestObject;

        // Act
        TestObject = new(cDefaultErrorCode, cDefaultErrorMessage, cDefaultErrorData);

        // Assert
        TestObject.Should().NotBeNull();
    }
    [Fact]
    public void Constructor_Full_Test()
    {
        // Arrange
        Error<string> TestObject;

        // Act
        TestObject = new(cDefaultErrorCode, cDefaultErrorMessage, cDefaultErrorData, ErrorType.Exception);

        // Assert
        TestObject.Should().NotBeNull();
    }
    #endregion

    #region Property Tests
    [Theory]
    [MemberData(nameof(GetStringValues))]
    public void Property_Data_String_Test(string testValue)
    {
        // Arrange
        Error<string> TestObject;

        // Act
        TestObject = new(cDefaultErrorCode, cDefaultErrorMessage, testValue);

        // Assert
        TestObject.Data.Should().Be(testValue);
    }
    [Theory]
    [MemberData(nameof(GetExceptionValues))]
    public void Property_Data_Test(Exception testValue)
    {
        // Arrange
        Error<Exception> TestObject;

        // Act
        TestObject = new(cDefaultErrorCode, cDefaultErrorMessage, testValue);

        // Assert
        TestObject.Data.Should().Be(testValue);
    }
    #endregion
}
