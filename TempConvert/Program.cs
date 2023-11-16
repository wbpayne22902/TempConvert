//See https://aka.ms/new-console-template for more information
double tempFrom, tempTo;
string? theKey;
reader: Console.Write("C for celsius or F for Fahrenheit> ");
//ConsoleKeyInfo consoleKey = Console.ReadKey();
theKey = Console.ReadLine();
Console.WriteLine();
Console.Write("Enter temp to convert> ");
try
{
    tempFrom = Convert.ToDouble(Console.ReadLine());
    if (theKey is not null)
    {
        switch (theKey.ToUpper())
        {
            case "F":
                tempTo = (tempFrom - 32.0) * (5.0 / 9.0);
                Console.WriteLine($"{tempFrom} degF = {tempTo} degC");
                break;
            case "C":
                tempTo = (9.0 / 5.0) * tempFrom + 32.0;
                Console.WriteLine($"{tempFrom} degC = {tempTo} degF");
                break;
            default:
                Console.WriteLine("You must enter C or F!");
                goto reader;
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
    Environment.Exit(1);
}
