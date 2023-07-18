using DigitalCaesar.Anticipation;
using FluentAssertions;

namespace DigitalResults.UnitTests.Errors;

public class Error_Test
{
    #region Test Values
    private const string cDefaultErrorCode = "TestError";
    private const string cDefaultErrorMessage = "Test Error Message";
    public static IEnumerable<object[]> GetPartialConstructorValues()
    {
        yield return new object[] { "Test", "Test Error" };
        yield return new object[] { string.Empty, string.Empty };
    }
    public static IEnumerable<object[]> GetFullConstructorValues()
    {
        yield return new object[] { "TestCode", "Test Error Message", ErrorType.Exception };
        yield return new object[] { string.Empty, string.Empty, ErrorType.Validation };
    }
    #endregion

    #region Static Types
    [Fact]
    public void Error_None_Test()
    {
        // Arrange
        Error TestObject;

        // Act
        TestObject = Error.None;

        // Assert
        TestObject.Code.Should().BeEmpty();
        TestObject.Message.Should().BeEmpty();
        TestObject.ErrorType.Should().Be(ErrorType.Warning);
    }

    [Fact]
    public void Error_Null_Test()
    {
        // Arrange
        Error TestObject;

        // Act
        TestObject = Error.NullValue;

        // Assert
        TestObject.Code.Should().Be("Error.NullValue");
        TestObject.Message.Should().Be("The specified result value is null.");
        TestObject.ErrorType.Should().Be(ErrorType.Warning);
    }

    [Fact]
    public void Error_Validation_Test()
    {
        // Arrange
        Error TestObject;

        // Act
        TestObject = Error.Validation;

        // Assert
        TestObject.Code.Should().Be("ValidationError");
        TestObject.Message.Should().Be("A validation error occurred.");
        TestObject.ErrorType.Should().Be(ErrorType.Warning);
    }
    #endregion

    #region Constructor Tests
    [Fact]
    public void Constructor_Default_Test()
    {
        // Arrange
        Error TestObject;

        // Act
        TestObject = new(cDefaultErrorCode, cDefaultErrorMessage);

        // Assert
        TestObject.Should().NotBeNull();
    }
    [Theory]
    [MemberData(nameof(GetPartialConstructorValues))]
    public void Constructor_Partial_Test(string code, string message)
    {
        // Arrange
        Error TestObject;

        // Act
        TestObject = new(code, message);

        // Assert
        TestObject.Should().NotBeNull();
    }
    [Theory]
    [MemberData(nameof(GetFullConstructorValues))]
    public void Constructor_Full_Test(string code, string message, ErrorType type)
    {
        // Arrange
        Error TestObject;

        // Act
        TestObject = new(code, message, type);

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
        Error TestObject;

        // Act
        TestObject = new(testValue, cDefaultErrorMessage);

        // Assert
        TestObject.Code.Should().Be(expectedValue);
    }

    [Theory]
    [InlineData("TestMessage", "TestMessage")]
    public void Property_Message_Test(string testValue, string expectedValue)
    {
        // Arrange
        Error TestObject;

        // Act
        TestObject = new(cDefaultErrorCode, testValue);

        // Assert
        TestObject.Message.Should().Be(expectedValue);
    }
    [Theory]
    [InlineData(ErrorType.Warning)]
    [InlineData(ErrorType.Validation)]
    [InlineData(ErrorType.Exception)]
    public void Property_ErrorType_Test(ErrorType errorType)
    {
        // Arrance
        Error TestObject;

        // Act
        TestObject = new(cDefaultErrorCode, cDefaultErrorMessage, errorType);
        
        // Assert
        TestObject.ErrorType.Should().Be(errorType);
    }
    [Fact]
    public void Property_ErrorType_Default_Test()
    {
        // Arrance
        Error TestObject;

        // Act
        TestObject = new(cDefaultErrorCode, cDefaultErrorMessage);

        // Assert
        TestObject.ErrorType.Should().Be(ErrorType.Warning);
    }
    #endregion
}
