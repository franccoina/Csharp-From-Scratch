// Classes and Inheritance

var rect = new Rectangle();
rect.Width = 5.0;
rect.Height = 10.0;

Console.WriteLine("------- Welcome to the GeometryGuesser! -------");
Console.WriteLine();
Console.WriteLine("------- Rectangle Examples -------");
Console.WriteLine($"-- Width: {rect.Width}");
Console.WriteLine($"-- Height: {rect.Height}");
Console.WriteLine($"-- Area: {rect.Area()}");
Console.WriteLine($"-- Perimeter: {rect.Perimeter()}");
Console.WriteLine($"-- Is Square: {rect.IsSquare()}");

var square = new Square();
square.Side = 7.0;

Console.WriteLine();
Console.WriteLine("------- Square Examples -------");
Console.WriteLine($"-- Side: {square.Side}");
Console.WriteLine($"-- Area: {square.Area()}");
Console.WriteLine($"-- Perimeter: {square.Perimeter()}");
Console.WriteLine($"-- Is Square: {square.IsSquare()}");

// ----------------------------------- MY EXERCISE -----------------------------------

Console.WriteLine("------- Now You! -------");
Console.WriteLine();
Console.WriteLine("-- Please try and make a Rectangle, which is also a Square: ");

var userTryToSquare = new Rectangle();

double widthInput;
Console.WriteLine();
Console.WriteLine("-- Please enter a width: ");
while (!double.TryParse(Console.ReadLine(), out widthInput) || widthInput <= 0)
{
    Console.WriteLine("-- Invalid width. Please enter a positive number.");
}
userTryToSquare.Width = widthInput;

double heightInput;
Console.WriteLine("-- Please enter a height: ");
while (!double.TryParse(Console.ReadLine(), out heightInput) || heightInput <= 0)
{
    Console.WriteLine("-- Invalid height. Please enter a positive number.");
}
userTryToSquare.Height = heightInput;

while (!userTryToSquare.IsSquare())
{
    Console.WriteLine();
    Console.WriteLine("-- The rectangle is not a square. Let's fix it by changing only the height.");

    Console.WriteLine();
    Console.WriteLine($"-- Please enter a new height. Remember your width is {userTryToSquare.Width}: ");

    while (!double.TryParse(Console.ReadLine(), out heightInput) || heightInput <= 0)
    {
        Console.WriteLine();
        Console.WriteLine("-- Invalid height. Please enter a positive number.");
    }
    userTryToSquare.Height = heightInput;
}

Console.WriteLine();
Console.WriteLine("------- Well Done! Here are your values -------");
Console.WriteLine($"-- Width: {userTryToSquare.Width}");
Console.WriteLine($"-- Height: {userTryToSquare.Height}");
Console.WriteLine($"-- Area: {userTryToSquare.Area()}");
Console.WriteLine($"-- Perimeter: {userTryToSquare.Perimeter()}");
Console.WriteLine($"-- Is Square: {userTryToSquare.IsSquare()}");

// ----------------------------------- MY EXERCISE -----------------------------------

class Rectangle
{
    public double Width { get; set; }
    public double Height { get; set; }

    public double Area()
    {
        return Width * Height;
    }

    public double Perimeter()
    {
        return 2.0 * (Width + Height);
    }

    public bool IsSquare()
    {
        return Width == Height;
    }
}

class Square : Rectangle
{
    public double Side
    {
        get { return Width; }
        set { Width = Height = value; }
    }
}