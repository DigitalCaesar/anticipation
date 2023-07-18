namespace DigitalCaesar.Anticipation.Samples;

public class ErrorStrategy : IStrategy
{
    public void Execute(int[] values)
    {
        try
        {
            var average = AverageCalculatorWithErrors.Calculate(values);
            if (average.Error != null)
                Console.WriteLine(average.Error.Description);
            else
            Console.WriteLine($"The average is {average.Value}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
