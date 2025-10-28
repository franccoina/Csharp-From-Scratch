// -------------- Conditionals --------------

Console.WriteLine("-- Please enter a number:");
int num = int.Parse(Console.ReadLine());

if (num > 0)
{
    Console.WriteLine($"The number {num} is positive.");
}
else if (num < 0)
{
    Console.WriteLine($"The number {num} is negative.");
}
else
{
    Console.WriteLine("The number is zero.");
}

// -------------- Operators --------------

const string Indeterminado = "Indeterminado";
Console.WriteLine("-- Please enter the first number:");
double a = double.Parse(Console.ReadLine());
Console.WriteLine("-- Please enter the second number:");
double b = double.Parse(Console.ReadLine());
Console.WriteLine($"-- Sum: {a} + {b} = {a + b}");
Console.WriteLine($"-- Subtraction: {a} - {b} = {a - b}");
Console.WriteLine($"-- Multiplication: {a} * {b} = {a * b}");
Console.WriteLine($"-- Division: {a} / {b} = {(b != 0 ? a / b : Indeterminado)}");
Console.WriteLine($"-- Modulus: {a} % {b} = {(b != 0 ? a % b : Indeterminado)}");
Console.WriteLine($"-- Exponentiation: {a} ^ {b} = {Math.Pow(a, b)}");
Console.WriteLine();
