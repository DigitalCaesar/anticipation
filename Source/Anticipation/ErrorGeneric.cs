namespace DigitalCaesar.Anticipation;

/// <summary>
/// An error with an underlying type for additional data
/// </summary>
/// <typeparam name="EType">the type that caused the error</typeparam>
public class Error<EType> : Error
{
    /// <summary>
    /// The cause of the error
    /// </summary>
    public EType Data { get; }

    /// <summary>
    /// Default constructor requires an error code and message
    /// </summary>
    /// <param name="code">the unique identifier of the error</param>
    /// <param name="message">the message explaining the error</param>
    /// <param name="data">the cause of the error</param>
    /// <param name="errorType">the type of underlying issue that triggered the error</param>
    public Error(string code, string message, EType data, ErrorType errorType = ErrorType.Warning)
        : base(code, message, errorType)
    {
        Data = data;
    }
}
