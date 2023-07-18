using DigitalCaesar.Anticipation.Samples;

// Exception Strategy
Console.WriteLine("Illustrate the Exception Strategy");
Console.WriteLine("---------------------------------");
SampleGenerator ExceptionExample = new(StrategyType.Exception);
ExceptionExample.Execute();

Console.WriteLine("=================================");

// Error Strategy
Console.WriteLine("Illustrate the Error Strategy");
Console.WriteLine("---------------------------------");
SampleGenerator ErrorExample = new(StrategyType.Error);
ErrorExample.Execute();