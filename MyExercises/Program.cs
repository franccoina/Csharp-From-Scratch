using itm.csharp.fromscratch;

namespace itm.csharp.fromscratch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine($"Hello, {name}! Please choose one of the exercises from the menu: ");
            Console.WriteLine();
            Menu.Show();
            while (true)
            {
                Console.WriteLine($"{name}, Please enter the number of the exercise you want to run (or 'exit (e)' to quit): ");
                string input = Console.ReadLine().Trim().ToLower();
                if (input == "exit" || input == "e")
                {
                    break;
                }

                if (int.TryParse(input, out int selectedExercise) && selectedExercise >= 1 && selectedExercise <= 15)
                {
                    // Lógica para ejecutar el ejercicio seleccionado con switch
                    switch (selectedExercise)
                    {
                        case 1:
                            Challenge1.Run();
                            break;
                        case 2:
                            Challenge2.Run();
                            break;
                        case 3:
                            Challenge3.Run();
                            break;
                        case 4:
                            Challenge4.Run();
                            break;
                        case 5:
                            Challenge5.Run();
                            break;
                        case 6:
                            Challenge6.Run();
                            break;
                        case 7:
                            Challenge7.Run();
                            break;
                        case 8:
                            Challenge8.Run();
                            break;
                        case 9:
                            Challenge9.Run();
                            break;
                        case 10:
                            Challenge10.Run();
                            break;
                        case 11:
                            Challenge11.Run();
                            break;
                        case 12:
                            Challenge12.Run();
                            break;
                        case 13:
                            Challenge13.Run();
                            break;
                        case 14:
                            Challenge14.Run();
                            break;
                        case 15:
                            Challenge15.Run();
                            break;
                        default:
                            Console.WriteLine("Invalid exercise number. Please try again.");
                            break;
                    }

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    Menu.Show(); // Mostramos el menú nuevamente después de ejecutar el ejercicio
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid exercise number between 1 to 15 or 'exit (e)' to quit.");
                }
            }
            Console.WriteLine("Thank you for using the program. Goodbye!");
        }
    }
}