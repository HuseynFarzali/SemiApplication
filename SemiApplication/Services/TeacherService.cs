using SemiApplication.Database_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SemiApplication.Models;
using SemiApplication.Database_Models;

namespace SemiApplication.Services
{
    public class TeacherService
    {
        public static Database<Teacher> teacherDatabase = new();

        public static void AddTeacher()
        {
            Console.Write("Enter the name of the teacher: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Given teacher name is invalid. (Possibly a null reference or a white-space entered)");
                return;
            }

            Console.Write("Enter the surname of the teacher: ");
            string surname = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(surname))
            {
                Console.WriteLine("Given teacher surname is invalid. (Possibly a null reference or a white-space entered)");
                return;
            }

            try
            {
                Console.Write("Enter the birthday of the teacher [format: MM/dd/yyyy]: ");
                DateTime birthday = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", null);

                teacherDatabase.Add(new Teacher(name.Trim(), surname.Trim(), birthday));
            }

            catch (FormatException)
            {
                Console.WriteLine("Invalid string format entered. (Possibly while entering grade of birthday of the teacher)");
            }
        }

        public static void ShowTeacher()
        {
            if (teacherDatabase.GetContent().Count() == 0)
            {
                Console.WriteLine("No any teacher data added.");
            }

            foreach (var pair in teacherDatabase.GetContent())
            {
                Console.WriteLine($"{pair.Key} {pair.Value}");
            }
        }

        public static void RemoveTeacher()
        {
            try
            {
                Console.Write("Enter the ID of the teacher: ");
                int id = int.Parse(Console.ReadLine());

                bool success = teacherDatabase.Remove(id);
                if (success)
                {
                    Console.WriteLine("Teacher deleted from the database successfully.");
                    return;
                }
                else
                {
                    Console.WriteLine("Removal of the teacher by the given ID value failed. (Possibly there is no any matching teacher by the given ID value).");
                    return;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid string format entered. (Possibly while entering ID of the teacher).");
            }
        }

        public static void UpdateTeacher()
        {
            try
            {
                Console.Write("Enter the ID of the teacher: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter the new name: ");
                string name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Given teacher name is invalid. (Possibly a null reference or a white-space entered)");
                    return;
                }

                Console.Write("Enter the new surname: ");
                string surname = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(surname))
                {
                    Console.WriteLine("Given teacher surname is invalid. (Possibly a null reference or a white-space entered)");
                    return;
                }

                Console.Write("Enter the new birthday date (format[MM/dd/yyyy]): ");
                DateTime birth = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", null);

                var student = new Teacher(name.Trim(), surname.Trim(), birth);

                bool success = teacherDatabase.Update(id, student);
                if (success)
                {
                    Console.WriteLine("Teacher data updated successfully.");
                    return;
                }
                else
                {
                    Console.WriteLine("Update operation of the Teacher by the given ID value failed. (Possibly there is no any matching Teacher by the given ID value).");
                    return;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid string format entered. (Possibly while entering ID or the new birthday date of the teacher).");
            }
        }

        public static void FindTeachersByName()
        {
            Console.Write("Enter the name to be searched: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Given teacher name is invalid. (Possibly a null reference or a white-space entered)");
                return;
            }

            List<KeyValuePair<int, Teacher>> foundPairs = teacherDatabase.FindByCriteria(teacher => teacher.Name == name);

            if (foundPairs.Count <= 0)
            {
                Console.WriteLine("No such teacher found");
            }

            foreach (var pair in foundPairs)
            {
                Console.WriteLine($"{pair.Key} {pair.Value}");
            }
        }

        public static void FindTeachersByBirthDayRange()
        {
            try
            {
                Console.Write("Enter the start date of the interval (format[MM/dd/yyyy]): ");
                DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", null);

                Console.Write("Enter the end date of the interval (format[MM/dd/yyyy]): ");
                DateTime endDate = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", null);

                var pairs = teacherDatabase.FindByCriteria(
                    teacher => teacher.BirthDay >= startDate && teacher.BirthDay <= endDate);

                foreach (var pair in pairs)
                {
                    Console.WriteLine($"{pair.Key} {pair.Value}");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid string format entered. (Possibly while entering the dates).");
                return;
            }
        }
    }
}
