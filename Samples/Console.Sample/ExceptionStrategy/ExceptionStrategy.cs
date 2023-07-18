namespace DigitalCaesar.Anticipation.Samples;

public class ExceptionStrategy : IStrategy
{
    public void Execute(int[] values)
    {
        try
        {
            decimal average = AverageCalculatorWithExceptions.Calculate(values);
            Console.WriteLine($"The average is {average}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

