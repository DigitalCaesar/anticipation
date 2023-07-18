namespace DigitalCaesar.Anticipation.Samples;

public static class AverageError
{
    public static Error ValueTooLow(int value) => new("0", $"The Value provided '{value}' was too low.  Values must be zero or higher.");
    public static Error ValueTooHigh(int value) => new("1",$"The Value provided '{value}' was too high.  Values must be below 100.");
    public static Error NoValues => new("2","No values were provided.  At least one valid value must be provided.");
}