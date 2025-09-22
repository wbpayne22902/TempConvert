using System.Globalization;

// See https://aka.ms/new-console-template for more information
// This is a simple temperature converter that converts Fahrenheit to Celsius and vice versa.
// It uses a switch statement to determine which conversion to perform.
// It uses a try-catch block to catch any exceptions that may occur and exits with code 1 on error.
// It uses a static method to perform the Fahrenheit to Celsius conversion.
// It uses a static method to perform the Celsius to Fahrenheit conversion.

/// <summary>
/// Converts a temperature from Fahrenheit to Celsius.
/// </summary>
/// <param name="degF">The temperature in Fahrenheit.</param>
/// <returns>The equivalent temperature in Celsius.</returns>
static double DoFtoC(double degF)
{
    var tempTo = (degF - 32.0) * (5.0 / 9.0);
    return tempTo;
}

/// <summary>
/// Converts a temperature from Celsius to Fahrenheit.
/// </summary>
/// <param name="degC">The temperature in Celsius.</param>
/// <returns>The equivalent temperature in Fahrenheit.</returns>
static double DoCtoF(double degC)
{
    var tempTo = (9.0 / 5.0) * degC + 32.0;
    return tempTo;
}

/// <summary>
/// Attempts to play a system beep sound, handling exceptions that may occur on unsupported platforms.
/// </summary>
/// <remarks>
/// This method safely attempts to play a beep sound through the Console.Beep() method.
/// It handles PlatformNotSupportedException explicitly and silently handles any other exceptions
/// that might occur during the beep operation to prevent them from being treated as fatal errors.
/// </remarks>
static void TryBeep()
{
    try
    {
        Console.Beep();
    }
    catch (PlatformNotSupportedException)
    {
        // Ignore on platforms that don't support Console.Beep()
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
        Console.WriteLine("Welcome to the Temperature Converter by Wilhelm Payne!");
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

            if (double.TryParse(input, NumberStyles.Float, CultureInfo.CurrentCulture, out tempFrom))
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

    Console.WriteLine("Thank you for using the temperature converter!");
    TryBeep();
}
catch (Exception ex)
{
    Console.Error.WriteLine($"Error: {ex.Message}");
    Environment.Exit(1);
}
