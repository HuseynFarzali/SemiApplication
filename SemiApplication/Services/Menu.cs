using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemiApplication.Services
{
    public static class Menu
    {
        public static void StudentSubMenu()
        {
            Console.Clear();
            int option;

            do
            {
                Console.WriteLine();
                Console.WriteLine("1. Show students");
                Console.WriteLine("2. Add student");
                Console.WriteLine("3. Update student");
                Console.WriteLine("4. Remove student");
                Console.WriteLine("5. Find students by name");
                Console.WriteLine("6. Find students by bday ranges");
                Console.WriteLine("0. Go back");
                Console.WriteLine("------------------------");
                Console.WriteLine("Please, select an option: ");
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
                        StudentService.ShowStudent();
                        break;
                    case 2:
                        StudentService.AddStudent();
                        break;
                    case 3:
                        StudentService.UpdateStudent();
                        break;
                    case 4:
                        StudentService.RemoveStudent();
                        break;
                    case 5:
                        StudentService.FindStudentsByName();
                        break;
                    case 6:
                        StudentService.FindStudentsByBirthdayRange();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("No such option!");
                        break;
                }

            }
            while (option != 0);
        }

        public static void TeacherSubMenu()
        {
            Console.Clear();
            int option;

            do
            {
                Console.WriteLine();
                Console.WriteLine("1. Show teachers");
                Console.WriteLine("2. Add teacher");
                Console.WriteLine("3. Update teacher");
                Console.WriteLine("4. Remove teacher");
                Console.WriteLine("5. Find teacher by name");
                Console.WriteLine("6. Find teachers by bday ranges");
                Console.WriteLine("0. Go back");
                Console.WriteLine("------------------------");
                Console.WriteLine("Please, select an option: ");
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
                        TeacherService.ShowTeacher();
                        break;
                    case 2:
                        TeacherService.AddTeacher();
                        break;
                    case 3:
                        TeacherService.UpdateTeacher();
                        break;
                    case 4:
                        TeacherService.RemoveTeacher();
                        break;
                    case 5:
                        TeacherService.FindTeachersByName();
                        break;
                    case 6:
                        TeacherService.FindTeachersByBirthDayRange();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("No such option!");
                        break;
                }

            }
            while (option != 0);
        }

    }
}
