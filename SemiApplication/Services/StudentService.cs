using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using SemiApplication.Database_Models;
using SemiApplication.Models;

namespace SemiApplication.Services
{
    public class StudentService
    {
        public static Database<Student> studentDatabase = new Database<Student>();

        public static void AddStudent()
        {
            Console.Write("Enter the name of the student: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Given student name is invalid. (Possibly a null reference or a white-space entered)");
                return;
            }

            Console.Write("Enter the surname of the student: ");
            string surname = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(surname))
            {
                Console.WriteLine("Given student surname is invalid. (Possibly a null reference or a white-space entered)");
                return;
            }

            try
            {
                Console.Write("Enter the grade of the student: ");
                decimal grade = decimal.Parse(Console.ReadLine());

                Console.Write("Enter the birthday of the student [format: MM/dd/yyyy]: ");
                DateTime birthday = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", null);

                studentDatabase.Add(new Student(name.Trim(), surname.Trim(), grade, birthday));
            }

            catch (FormatException)
            {
                Console.WriteLine("Invalid string format entered. (Possibly while entering grade of birthday of the student)");
            }
        }

        public static void ShowStudent()
        {
            if (studentDatabase.GetContent().Count() == 0)
            {
                Console.WriteLine("No any student data added.");
            }

            foreach (var pair in studentDatabase.GetContent())
            {
                Console.WriteLine($"{pair.Key} {pair.Value}");
            }
        }

        public static void RemoveStudent()
        {
            try
            {
                Console.Write("Enter the ID of the student: ");
                int id = int.Parse(Console.ReadLine());

                bool success = studentDatabase.Remove(id);
                if (success)
                {
                    Console.WriteLine("Student deleted from the database successfully.");
                    return;
                }
                else
                {
                    Console.WriteLine("Removal of the student by the given ID value failed. (Possibly there is no any matching student by the given ID value).");
                    return;
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("Invalid string format entered. (Possibly while entering ID of the student).");
            }
        }

        public static void UpdateStudent()
        {
            try
            {
                Console.Write("Enter the ID of the student: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter the new name: ");
                string name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Given student name is invalid. (Possibly a null reference or a white-space entered)");
                    return;
                }

                Console.Write("Enter the new surname: ");
                string surname = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(surname))
                {
                    Console.WriteLine("Given student surname is invalid. (Possibly a null reference or a white-space entered)");
                    return;
                }

                Console.Write("Enter the new grade: ");
                decimal grade = decimal.Parse(Console.ReadLine());

                Console.Write("Enter the new birthday date format[MM/dd/yyyy]: ");
                DateTime birth = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", null);

                var student = new Student(name.Trim(), surname.Trim(), grade, birth);

                bool success = studentDatabase.Update(id, student);
                if (success)
                {
                    Console.WriteLine("Student deleted from the database successfully.");
                    return;
                }
                else
                {
                    Console.WriteLine("Removal of the student by the given ID value failed. (Possibly there is no any matching student by the given ID value).");
                    return;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid string format entered. (Possibly while entering ID, new grade or the new birthday date of the student).");
            }
        }

        public static void FindStudentsByName()
        {
            Console.Write("Enter the name to be searched: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Given student name is invalid. (Possibly a null reference or a white-space entered)");
                return;
            }

            List<KeyValuePair<int, Student>> foundPairs = studentDatabase.FindByCriteria(student => student.Name == name);

            if (foundPairs.Count <= 0)
            {
                Console.WriteLine("No such student found");
            }

            foreach (var pair in foundPairs)
            {
                Console.WriteLine($"{pair.Key} {pair.Value}");
            }
        }

        public static void FindStudentsByBirthdayRange()
        {
            try
            {
                Console.Write("Enter the start date of the interval (format[MM/dd/yyyy]): ");
                DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", null);

                Console.Write("Enter the end date of the interval (format[MM/dd/yyyy]): ");
                DateTime endDate = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", null);

                var pairs = studentDatabase.FindByCriteria(
                    student => student.BirthDay >= startDate && student.BirthDay <= endDate);

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
