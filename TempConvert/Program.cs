using System.Globalization;

// See https://aka.ms/new-console-template for more information
// This is a simple temperature converter that converts Fahrenheit to Celsius and vice versa.
// It uses a switch statement to determine which conversion to perform.
// It uses a try-catch block to catch any exceptions that may occur and exits with code 1 on error.
// It uses a static method to perform the Fahrenheit to Celsius conversion.
// It uses a static method to perform the Celsius to Fahrenheit conversion.

static double DoFtoC(double degF)
{
    var tempTo = (degF - 32.0) * (5.0 / 9.0);
    return tempTo;
}

static double DoCtoF(double degC)
{
    var tempTo = (9.0 / 5.0) * degC + 32.0;
    return tempTo;
}

static void TryBeep()
{
    try
    {
        Console.Beep();
    }
    catch (PlatformNotSupportedException)
    {
        // Ignore on platforms that don't support Console.Beep()
        Console.WriteLine("Beep not supported on this platform.");
    }
    catch
    {
        // Swallow any other beep-related exceptions to avoid treating them as fatal
    }
}

try
{
    while (true)
    {
        Console.WriteLine("Welcome to the Temperature Converter by Wilhelm Payne v2026.2!");
        Console.Write("Enter C for Celsius or F for Fahrenheit> ");
        string? rawKey = Console.ReadLine();
        if (rawKey is null)
        {
            Console.Error.WriteLine("No input received. Exiting.");
            Environment.Exit(1);
        }

        string theKey = rawKey.Trim();
        if (string.IsNullOrEmpty(theKey))
        {
            Console.WriteLine("You must enter C or F!");
            continue;
        }

        string key = theKey.ToUpperInvariant();
        if (key != "C" && key != "F")
        {
            Console.WriteLine("You must enter C or F!");
            continue;
        }

        double tempFrom;
        while (true)
        {
            Console.Write("Enter temp to convert> ");
            string? input = Console.ReadLine();
            if (input is null)
            {
                Console.Error.WriteLine("No input received. Exiting.");
                Environment.Exit(1);
            }

            if (double.TryParse(input, NumberStyles.Float | NumberStyles.AllowParentheses, CultureInfo.CurrentCulture, out tempFrom))
            {
                break;
            }
            Console.WriteLine("Please enter a valid numeric temperature.");
        }

        if (key == "F")
        {
            Console.WriteLine($"{tempFrom:F2} degF = {DoFtoC(tempFrom):F2} degC");
        }
        else
        {
            Console.WriteLine($"{tempFrom:F2} degC = {DoCtoF(tempFrom):F2} degF");
        }

        break;
    }

    Console.WriteLine("Thank you for using my temperature converter!");
    TryBeep();
}
catch (Exception ex)
{
    Console.Error.WriteLine($"Error here: {ex.Message}");
    Environment.Exit(1);
}
