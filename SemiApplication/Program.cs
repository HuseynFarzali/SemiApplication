using SemiApplication.Models;
using SemiApplication.Database_Models;
using SemiApplication.Services;

namespace SemiApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            int option;

            do
            {
                Console.WriteLine("1. Student menu");
                Console.WriteLine("2. Teacher menu");
                Console.WriteLine("0. Exit");
                Console.WriteLine("------------------------");
                Console.WriteLine("Please, select an option:");
                Console.WriteLine("------------------------");


                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("------------------------");
                    Console.WriteLine("Please, enter a valid option:");
                    Console.WriteLine("------------------------");
                }

                switch (option)
                {
                    case 1:
                        Menu.StudentSubMenu();
                        break;
                    case 2:
                        Menu.TeacherSubMenu();
                        break;
                    case 0:
                        Console.WriteLine("Bye");
                        break;
                    default:
                        Console.WriteLine("No such option!");
                        break;
                }

            } while (option != 0);
        }
    }
}