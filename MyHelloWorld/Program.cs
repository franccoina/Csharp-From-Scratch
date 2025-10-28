namespace MyHelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variable declaration and initialization:
            string message = "Hello, World!";
            double number = 1.234;
            bool isTrue = true;
            int count = 5;
            char letter = 'A';
            DateTime now = DateTime.Now;
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);

            // Implicitly typed variables:
            var variable = "I am a string";
            const string constant = "I am a string... but you can't change me";

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