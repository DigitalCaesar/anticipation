using DigitalCaesar.Anticipation;
using FluentAssertions;

namespace DigitalResults.UnitTests.Errors;
public class ErrorException_Test
{
    #region Test Data
    private const string cDefaultErrorCode = "TestError";
    private const string cDefaultErrorMessage = "Test Error Message";
    private static Exception GetException()
    {
        return new("Test Exception for Unit Testing");
    }
    #endregion

    #region Constructor Tests

    [Fact]
    public void Constructor_ErrorOnly_Test()
    {
        // Arrange
        ExceptionError TestObject;

        // Act
        TestObject = new(GetException());

        // Assert
        TestObject.Should().NotBeNull();
    }
    [Fact]
    public void Constructor_Default_Test()
    {
        // Arrange
        ExceptionError TestObject;

        // Act
        TestObject = new(cDefaultErrorCode, cDefaultErrorMessage, GetException());

        // Assert
        TestObject.Should().NotBeNull();
    }
    #endregion

    #region Property Tests
    [Theory]
    [InlineData("TestCode", "TestCode")]
    public void Property_Code_Test(string testValue, string expectedValue)
    {
        // Arrange
        ExceptionError TestObject;

        // Act
        TestObject = new(testValue, cDefaultErrorMessage, GetException());

        // Assert
        TestObject.Code.Should().Be(expectedValue);
    }

    [Theory]
    [InlineData("TestMessage", "TestMessage")]
    public void Property_Message_Test(string testValue, string expectedValue)
    {
        // Arrange
        ExceptionError TestObject;

        // Act
        TestObject = new(cDefaultErrorCode, testValue, GetException());

        // Assert
        TestObject.Message.Should().Be(expectedValue);
    }
    [Fact]
    public void Property_ErrorType_Test()
    {
        // Arrance
        ExceptionError TestObject;

        // Act
        TestObject = new(cDefaultErrorCode, cDefaultErrorMessage, GetException());

        // Assert
        TestObject.ErrorType.Should().Be(ErrorType.Exception);
    }
    [Fact]
    public void Property_Data_Test()
    {
        // Arrance
        ExceptionError TestObject;
        Exception TestFailure = GetException();

        // Act
        TestObject = new(cDefaultErrorCode, cDefaultErrorMessage, TestFailure);

        // Assert
        TestObject.Data.Should().Be(TestFailure);
    }
    #endregion
}
