namespace DigitalCaesar.Anticipation;

/// <summary>
/// A problem in returning results
/// </summary>
public class Error
{
    /// <summary>
    /// A error occurred but was not declared and is therefore unknown
    /// </summary>
    public static readonly Error Unknown = new("Unknown", "An unknown error occurred");
    /// <summary>
    /// A default empty error
    /// </summary>
    public static readonly Error None = new(string.Empty, string.Empty);

    /// <summary>
    /// A unique identifier for the error
    /// </summary>
    public string Code { get; }
    /// <summary>
    /// A message explaining the error
    /// </summary>
    public string Message { get; }
    /// <summary>
    /// The type of underlying issue that trigger the error
    /// </summary>
    public ErrorType ErrorType { get; }


    /// <summary>
    /// Default constructor requires an error code and message
    /// </summary>
    /// <param name="code">the unique identifier of the error</param>
    /// <param name="message">the message explaining the error</param>
    /// <param name="errorType">the type of underlying issue that triggered the error</param>
    public Error(string code, string message, ErrorType errorType = ErrorType.Warning)
    {
        Code = code;
        Message = message;
        ErrorType = errorType;
    }
}
