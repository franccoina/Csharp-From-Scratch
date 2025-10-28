namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            const string Name = "John";
            string LastName = "John";

            LastName = "Doe";

            Console.WriteLine($"Hello, World. My name is {Name} {LastName}");
        }
    }
}