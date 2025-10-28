using System.Globalization;

namespace itm.csharp.fromscratch
{
    public static class Challenge1
    {
        public static void Run()
        {
            Console.WriteLine("------- Challenge 1 -------");
            Console.WriteLine("-- Please enter a number to square: ");
            int number = int.Parse(Console.ReadLine().Trim());

            while (!int.TryParse(number.ToString(), out _))
            {
                Console.WriteLine("-- The input is not valid. Please enter a valid number: ");
                number = int.Parse(Console.ReadLine().Trim());
            }

            if (number > 0)
            {
                double result = Math.Pow(number, 2);
                Console.WriteLine($"The number {number} is positive. Its square is {result}.");
            }
            else if (number < 0)
            {
                Console.WriteLine($"The number {number} is negative, so we will not square it.");
            }
            else
            {
                Console.WriteLine($"The number {number} is zero, so we will not square it.");
            }
        }
    }

    public static class Challenge2
    {
        public static void Run()
        {
            Console.WriteLine("------- Challenge 2 -------");
            Console.WriteLine("-- Please enter the first number: ");
            double firstNumber = double.Parse(Console.ReadLine().Trim());

            while (!double.TryParse(firstNumber.ToString(), out _))
            {
                Console.WriteLine("-- The input is not valid. Please enter a valid number: ");
                firstNumber = double.Parse(Console.ReadLine().Trim());
            }

            Console.WriteLine("-- Please enter the second number: ");
            double secondNumber = double.Parse(Console.ReadLine());

            while (!double.TryParse(secondNumber.ToString(), out _))
            {
                Console.WriteLine("-- The input is not valid. Please enter a valid number: ");
                secondNumber = double.Parse(Console.ReadLine().Trim());
            }

            double result;

            if (firstNumber >= secondNumber)
            {
                result = firstNumber * 2;
                Console.WriteLine($"{firstNumber} is equal or greater than {secondNumber}, so the result is {result}.");
            }
            else
            {
                result = secondNumber * 3;
                Console.WriteLine($"{firstNumber} is lower than {secondNumber}, so the result is {result}.");
            }
        }
    }

    public static class Challenge3
    {
        public static void Run()
        {
            Console.WriteLine("------- Challenge 3 -------");
            Console.WriteLine("-- Please enter a number to square root or square: ");
            int number = int.Parse(Console.ReadLine().Trim());

            while (!int.TryParse(number.ToString(), out _))
            {
                Console.WriteLine("-- The input is not valid. Please enter a valid number: ");
                number = int.Parse(Console.ReadLine().Trim());
            }

            if (number > 0)
            {
                double result = Math.Sqrt(number);
                Console.WriteLine($"The number {number} is positive, so its square root is {result}.");
            }
            else if (number < 0)
            {
                double result = Math.Pow(number, 2);
                Console.WriteLine($"The number {number} is negative, so its square is {result}.");
            }
            else
            {
                Console.WriteLine($"The number {number} is zero, so the result is 0 too.");
            }
        }
    }

    public static class Challenge4
    {
        public static void Run()
        {
            Console.WriteLine("------- Challenge 4 -------");
            Console.WriteLine("-- Please enter the radius of the circle: ");
            double radius = double.Parse(Console.ReadLine().Trim());

            while (!double.TryParse(radius.ToString(), out _))
            {
                Console.WriteLine("-- The input is not valid. Please enter a valid radius: ");
                radius = double.Parse(Console.ReadLine().Trim());
            }

            double perimeter = 2 * Math.PI * radius;
            Console.WriteLine($"The perimeter of the circle with radius {radius} is {perimeter}.");
        }
    }
    public static class Challenge5
    {
        public static void Run()
        {
            Console.WriteLine("------- Challenge 5 -------");
            Console.WriteLine("-- Please enter a number between 1 and 7, and I will return the corresponding workday: ");
            int day = int.Parse(Console.ReadLine().Trim());

            while (!int.TryParse(day.ToString(), out _))
            {
                Console.WriteLine("-- The input is not valid. Please enter a valid number: ");
                day = int.Parse(Console.ReadLine().Trim());
            }

            switch (day)
            {
                case 1: Console.WriteLine("Monday"); break;
                case 2: Console.WriteLine("Tuesday"); break;
                case 3: Console.WriteLine("Wednesday"); break;
                case 4: Console.WriteLine("Thursday"); break;
                case 5: Console.WriteLine("Friday"); break;
                case 6: Console.WriteLine("Number out of the workday range."); break;
                case 7: Console.WriteLine("Number out of the workday range."); break;
                default: Console.WriteLine("The entered parameter is not valid."); break;
            }
        }
    }

    public static class Challenge6
    {
        public static void Run()
        {
            Console.WriteLine("------- Challenge 6 -------");
            Console.WriteLine("-- Please enter your annual salary: ");
            double salary = double.Parse(Console.ReadLine());

            while (!double.TryParse(salary.ToString(), out _))
            {
                Console.WriteLine("-- The input is not valid. Please enter a valid amount: ");
                salary = double.Parse(Console.ReadLine().Trim());
            }

            if (salary > 12000)
            {
                double tax = (salary - 12000) * 0.15;
                Console.WriteLine($"You must pay {tax} in taxes.");
            }
            else
            {
                Console.WriteLine("No taxes due.");
            }
        }
    }

    public static class Challenge7
    {
        public static void Run()
        {
            Console.WriteLine("------- Challenge 7 -------");
            Console.WriteLine("-- Please enter the first number: ");
            int num1 = int.Parse(Console.ReadLine().Trim());

            while (!int.TryParse(num1.ToString(), out _))
            {
                Console.WriteLine("-- The input is not valid. Please enter a valid number: ");
                num1 = int.Parse(Console.ReadLine().Trim());
            }

            Console.WriteLine("-- Please enter the second number: ");
            int num2 = int.Parse(Console.ReadLine().Trim());

            while (!int.TryParse(num2.ToString(), out _))
            {
                Console.WriteLine("-- The input is not valid. Please enter a valid number: ");
                num2 = int.Parse(Console.ReadLine().Trim());
            }

            int remainder = num1 % num2;
            Console.WriteLine($"The remainder of {num1} divided by {num2} is {remainder}.");
        }
    }

    public static class Challenge8
    {
        public static void Run()
        {
            Console.WriteLine("------- Challenge 8 -------");
            int sum = 0;
            for (int i = 2; i <= 50; i += 2)
            {
                sum += i;
            }
            Console.WriteLine($"Fun fact! The sum of even numbers between 1 and 50 is {sum}.");
        }
    }

    public static class Challenge9
    {
        public static void Run()
        {
            Console.WriteLine("------- Challenge 9 -------");
            Console.WriteLine("-- Please enter a numerator for first fraction: ");
            int num1 = int.Parse(Console.ReadLine().Trim());

            while (!int.TryParse(num1.ToString(), out _))
            {
                Console.WriteLine("-- The input is not valid. Please enter a valid number: ");
                num1 = int.Parse(Console.ReadLine().Trim());
            }

            Console.WriteLine("-- Please enter a denominator for first fraction: ");
            int den1 = int.Parse(Console.ReadLine());

            while (!int.TryParse(den1.ToString(), out _) || den1 == 0)
            {
                Console.WriteLine("-- The input is not valid. Please enter a valid non-zero number: ");
                den1 = int.Parse(Console.ReadLine().Trim());
            }

            Console.WriteLine("-- Please enter a numerator for second fraction: ");
            int num2 = int.Parse(Console.ReadLine());

            while (!int.TryParse(num2.ToString(), out _))
            {
                Console.WriteLine("-- The input is not valid. Please enter a valid number: ");
                num2 = int.Parse(Console.ReadLine().Trim());
            }

            Console.WriteLine("-- Please enter a denominator for second fraction: ");
            int den2 = int.Parse(Console.ReadLine());

            while (!int.TryParse(den2.ToString(), out _) || den2 == 0)
            {
                Console.WriteLine("-- The input is not valid. Please enter a valid non-zero number: ");
                den2 = int.Parse(Console.ReadLine().Trim());
            }

            int commonDen = den1 * den2;
            int diffNum = num1 * den2 - num2 * den1;

            if (diffNum == 0)
            {
                Console.WriteLine("The difference is 0.");
            }
            else
            {
                Console.WriteLine($"The difference is {diffNum}/{commonDen}.");
            }
        }
    }

    public static class Challenge10
    {
        public static void Run()
        {
            Console.WriteLine("------- Challenge 10 -------");
            Console.WriteLine("-- Please enter a single word (no spaces): ");
            string word = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(word) || word.Contains(" "))
            {
                Console.WriteLine("-- The input is not valid. Please enter a single word (no spaces): ");
                word = Console.ReadLine();
            }

            Console.WriteLine($"The length of the word \"{word}\" is {word.Length}.");
        }
    }

    public static class Challenge11
    {
        public static void Run()
        {
            Console.WriteLine("------- Challenge 11 -------");
            double sum = 0;
            for (int i = 1; i <= 4; i++)
            {
                Console.WriteLine($"-- Please enter the {i}° number: ");
                var number = double.Parse(Console.ReadLine().Trim());

                while (!double.TryParse(number.ToString(), out _))
                {
                    Console.WriteLine("-- The input is not valid. Please enter a valid number: ");
                    number = double.Parse(Console.ReadLine().Trim());
                }

                sum += number;
            }
            double average = sum / 4;
            Console.WriteLine($"The average of the entered numbers is {average}.");
        }
    }

    public static class Challenge12
    {
        public static void Run()
        {
            Console.WriteLine("------- Challenge 12 -------");
            int smallest = int.MaxValue;
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"-- Please enter the {i}° number: ");
                int number = int.Parse(Console.ReadLine().Trim());

                while (!int.TryParse(number.ToString(), out _))
                {
                    Console.WriteLine("-- The input is not valid. Please enter a valid number: ");
                    number = int.Parse(Console.ReadLine().Trim());
                }

                if (number < smallest) smallest = number;
            }
            Console.WriteLine($"The smallest number is {smallest}.");
        }
    }

    public static class Challenge13
    {
        public static void Run()
        {
            Console.WriteLine("------- Challenge 13 -------");
            Console.WriteLine("-- Please enter a single word (no spaces) : ");
            string word = Console.ReadLine().ToLower();

            while (string.IsNullOrWhiteSpace(word) || word.Contains(" "))
            {
                Console.WriteLine("-- The input is not valid. Please enter a single word (no spaces): ");
                word = Console.ReadLine().ToLower();
            }

            int count = 0;

            foreach (char c in word)
            {
                if ("aeiou".Contains(c))
                {
                    count++;
                }
            }

            Console.WriteLine($"The word \"{word}\" contains {count} vowels.");
        }
    }

    public static class Challenge14
    {
        public static void Run()
        {
            Console.WriteLine("------- Challenge 14 -------");
            Console.WriteLine("-- Please enter a number: ");
            int number = int.Parse(Console.ReadLine().Trim());

            while (!int.TryParse(number.ToString(), out _))
            {
                Console.WriteLine("-- The input is not valid. Please enter a valid number: ");
                number = int.Parse(Console.ReadLine().Trim());
            }

            long factorial = 1;

            for (int i = 1; i <= number; i++)
            {
                factorial *= i;
            }

            Console.WriteLine($"The factorial of the number {number} is {factorial}.");
        }
    }

    public static class Challenge15
    {
        public static void Run()
        {
            Console.WriteLine("------- Challenge 15 -------");
            Console.WriteLine("-- Please enter a number: ");
            int number = int.Parse(Console.ReadLine().Trim());

            while (!int.TryParse(number.ToString(), out _))
            {
                Console.WriteLine("-- The input is not valid. Please enter a valid number: ");
                number = int.Parse(Console.ReadLine().Trim());
            }

            if (number >= 10 && number <= 20)
            {
                Console.WriteLine("The number is in the range of 10 to 20.");
            }
            else
            {
                Console.WriteLine("The number is out of range of 10 to 20.");
            }
        }
    }
}