namespace DigitalCaesar.Anticipation.Samples;

public class AverageCalculatorWithErrors
{

    public static AverageResult Calculate(int[] values)
    {
        decimal count = values.Length;
        if(count <= 0)
            return new AverageResult(0, AverageError.NoValues);

        decimal total = 0;
        foreach (int value in values)
        {
            if (value > 100)
                return new AverageResult(0, AverageError.ValueTooHigh(value));
            if (value < 0)
                return new AverageResult(0, AverageError.ValueTooLow(value));
            total += value;
        }
        decimal result = total / count;
        return new AverageResult(result, null);
    }
}
