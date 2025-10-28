// Loops, Polymorphism, and Exceptions
var circle = new Circle();
circle.Radius = 7.0;

// var resultArea = circle.Area(circle.Radius);
// var resultPerimeter = circle.Perimeter(circle.Radius);

var resultArea = circle.Area();
var resultPerimeter = circle.Perimeter();

Console.WriteLine();
Console.WriteLine("------- Circle Examples -------");
Console.WriteLine($"-- Radius: {circle.Radius}");
Console.WriteLine($"-- Area: {resultArea}");
Console.WriteLine($"-- Perimeter: {resultPerimeter}");
Console.WriteLine($"-- Wanna add 10 to your Radius? Now this is the value: {circle.Add10()}");

// --------------------------------------------------------------------------------------

// class Shape
// {
//     public double Area(double Radius) => Math.PI * Radius * Radius;
//     public double Perimeter(double Radius) => 2.0 * Math.PI * Radius;
// }

// class Circle : Shape
// {
//     public double Radius { get; set; }
// }

// --------------------------------------------------------------------------------------

// class Shape
// {
//     public abstract double Area();
//     public abstract double Perimeter();
// }

int prev = 0, next = 1, sum;
for (int i = 0; i < 10; i++)
{
    Console.WriteLine(prev);
    sum = prev + next;
    prev = next;
    next = sum;
}

try
{
    Console.WriteLine("Number to divide: ");
    int number = int.Parse(Console.ReadLine());
    Console.WriteLine("Divisor: ");
    int divisor = int.Parse(Console.ReadLine());
    if (divisor == 0)
    {
        throw new DivideByZeroException();
    }

    Console.WriteLine($"Result: {number / divisor}");
}
catch (DivideByZeroException)
{
    Console.WriteLine($"Error: Divisor cannot be zero.");
} 
catch (Exception ex)
{
    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
}

interface IShape
{
    public abstract double Area();
    public abstract double Perimeter();
}

interface IExtraCalculations
{
    double Add10();
}

class Circle : IShape, IExtraCalculations
{
    public double Radius { get; set; }

    public double Area()
    {
        return Math.PI * Radius * Radius;
    }

    public double Perimeter()
    {
        return 2.0 * Math.PI * Radius;
    }

    public double Add10()
    {
        return Radius + 10;
    }
}