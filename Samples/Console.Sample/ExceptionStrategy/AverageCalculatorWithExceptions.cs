namespace DigitalCaesar.Anticipation.Samples;

public class AverageCalculatorWithExceptions
{

    public static decimal Calculate(int[] values)
    {
        decimal count = values.Length;
        decimal total = 0;
        foreach (int value in values)
        {
            if (value > 100)
                throw new ArgumentException("Value too large");
            if (value < 0)
                throw new ArgumentException("Value too small");
            total += value;
        }
        return total / count;
    }
}

