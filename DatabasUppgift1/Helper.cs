using Microsoft.EntityFrameworkCore;

namespace DatabasUppgift1
{
    internal class Helper
    {
        public static StudentProps GetStudentPropsFromInput()
        {
            Console.Write("Enter FirstName: ");
            string firstName = Console.ReadLine() ?? "";
            Console.Write("Enter LastName: ");
            string lastName = Console.ReadLine() ?? "";
            Console.Write("Enter City: ");
            string city = Console.ReadLine() ?? "";

            return new StudentProps(firstName, lastName, city);
        }

        public static void PrintStudents(DbSet<Student> students)
        {
            Console.WriteLine("--- Printing students: ---");
            foreach (Student student in students)
            {
                Console.WriteLine($"{student.StudentId} {student.FirstName} {student.LastName} {student.City}");
            }
        }

        public static void ShowOptions()
        {
            Console.WriteLine("\nOptions are:");
            Console.WriteLine("R = Register new Student!");
            Console.WriteLine("A = Alter a student!");
            Console.WriteLine("L = List students (+ clear screen)!");
            Console.Write("\nChoose an option: ");
        }
    }
}
