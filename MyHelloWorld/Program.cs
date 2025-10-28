namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variable declaration and initialization:
            // var string message = "Hello, World!";
            // var double number = 1.234;
            // var bool isTrue = true;
            // var int count = 5;
            // var char letter = 'A';
            // var null letter = null;
            // var DateTime now = DateTime.Now;
            // var DateOnly today = DateOnly.FromDateTime(DateTime.Now);

            // Implicitly typed variables:
            // var variable = "I am a string";
            // const constant = "I am a string";

            DateOnly birthdateCoverted = new DateOnly();
            string fullNameInput;
            string birthdateInput;

            Console.WriteLine("------- Welcome to the age calculator! -------");
            Console.WriteLine();
            Console.WriteLine("-- Please enter your full name: ");
            fullNameInput = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine($"-- My pleausure to meet you, {fullNameInput}!");

            Console.WriteLine();
            Console.WriteLine("-- Please enter your birthdate (dd/MM/yy): ");
            birthdateInput = Console.ReadLine();

            bool isValid = DateOnly.TryParse(birthdateInput, out birthdateCoverted);

            if (isValid)
            {
                int age = DateTime.Now.Year - birthdateCoverted.Year;
                if (DateTime.Now.DayOfYear < birthdateCoverted.DayOfYear) age--;

                var person = new Person()
                {
                    FullName = fullNameInput,
                    Age = age,
                    Birthdate = birthdateCoverted
                };

                Console.WriteLine();
                Console.WriteLine($"-- Thank you, {person.FullName}. You are {person.Age} years old, and your birthdate is {person.Birthdate.ToString("dd/MM/yy")}.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("-- The birthdate format is invalid. Please use dd/MM/yy format.");
                Console.WriteLine();
            }
        }
    }

    public class Person
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public DateOnly Birthdate { get; set; }
    }
}