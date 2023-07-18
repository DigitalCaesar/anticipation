namespace DigitalCaesar.Anticipation.Samples;

public enum StrategyType
{
    Exception,
    Error
}

public class SampleGenerator
{
    readonly IStrategy mStrategy = new ExceptionStrategy();

    public SampleGenerator(StrategyType strategy)
    {
        if(strategy == StrategyType.Exception)
            mStrategy = new ExceptionStrategy();
        if(strategy == StrategyType.Error)
            mStrategy = new ErrorStrategy();
    }

    public void Execute()
    {
        mStrategy.Execute(new int[] { 0, 10, 20, 30 });
        mStrategy.Execute(new int[] { 0, 100, 200, 300 });
        mStrategy.Execute(new int[] { 0, -10, -20, -30 });
        mStrategy.Execute(Array.Empty<int>());
        mStrategy.Execute(new int[] { 0, 0, 0 });
    }

}
