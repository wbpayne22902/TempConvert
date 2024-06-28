﻿//See https://aka.ms/new-console-template for more information
//This is a simple temperature converter that converts Fahrenheit to Celsius and vice versa.
//It uses a switch statement to determine which conversion to perform.
//It uses a goto statement to loop back to the beginning if the user enters an invalid key.
//It uses a try-catch block to catch any exceptions that may occur.
//It uses a static method to perform the Fahrenheit to Celsius conversion.
//It uses a static method to perform the Celsius to Fahrenheit conversion.
//It uses a nullable string to store the user's input for the key.
//It uses a nullable double to store the user's input for the temperature to convert.

double tempFrom;
string? theKey;
reader: Console.Write("C for Celsius or F for Fahrenheit> ");
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
Console.WriteLine("Thank you for using the temperature converter!");

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
