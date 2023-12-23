//See https://aka.ms/new-console-template for more information
double tempFrom;
string? theKey;
reader: Console.Write("C for Celsius or F for Fahrenheit> ");
//ConsoleKeyInfo consoleKey = Console.ReadKey();
theKey = Console.ReadLine();
Console.Write("Enter temp to convert> ");
try
{
    tempFrom = Convert.ToDouble(Console.ReadLine());
    if (theKey is not null)
    {
        switch (theKey.ToUpper())
        {
            case "F":
                Console.WriteLine($"{tempFrom} degF = {doFtoC(tempFrom)} degC");
                break;
            case "C":
                Console.WriteLine($"{tempFrom} degC = {doCtoF(tempFrom)} degF");
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
    Console.WriteLine("Exiting now...");
    Environment.Exit(1);
}

static double doFtoC(double degF)
{
    double tempTo;
    tempTo = (degF - 32.0) * (5.0 / 9.0);
    return tempTo;

}

static double doCtoF(double degC)
{
    double tempTo;
                tempTo = (9.0 / 5.0) * degC + 32.0;
    return tempTo;
}
