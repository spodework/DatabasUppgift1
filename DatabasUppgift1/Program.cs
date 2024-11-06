namespace DatabasUppgift1
{
    internal class Program
    {
        static StudentDbContext dbCtx = new StudentDbContext();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the database program, printing students:");
            Helper.PrintStudents(dbCtx.Students);

            char input;
            while (true)
            {
                Helper.ShowOptions();
                input = Console.ReadKey().KeyChar;
                input = char.ToLower(input);
                Console.WriteLine();
                CheckInputCharOption(input);
            }
        }

        private static void AlterStudent()
        {
            int inputValue = -1;
            bool isValidInput = false;

            while (!isValidInput)
            {
                Console.Write("Enter id of student to alter: ");
                var input2 = Console.ReadLine();

                if (int.TryParse(input2, out inputValue))
                {
                    isValidInput = true;
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Error! Invalid input. Please enter a valid number.");
                }
            }

            var selected = dbCtx.Students.FirstOrDefault(student => student.StudentId == inputValue);

            if (selected != null)
            {
                var newStudentInfo = Helper.GetStudentPropsFromInput();

                Console.WriteLine(
                    "Altering " +
                    $"{selected.StudentId}: {selected.FirstName} " +
                    $"{selected.LastName} from {selected.City} " +
                    "to " +
                    $"{newStudentInfo.FirstName} {newStudentInfo.LastName} from " +
                    $"{newStudentInfo.City}"
                );

                selected.FirstName = newStudentInfo.FirstName;
                selected.LastName = newStudentInfo.LastName;
                selected.City = newStudentInfo.City;

                dbCtx.SaveChanges();
            }
            else
            {
                Console.WriteLine("Error! Did not find a student with that id");
            }
        }

        private static void RegisterStudent()
        {
            Console.WriteLine("You are REGISTERING a new student");
            var newStudentProps = Helper.GetStudentPropsFromInput();
            Student newStudent = new Student() { FirstName = newStudentProps.FirstName, LastName = newStudentProps.LastName, City = newStudentProps.City };            
            dbCtx.Students.Add(newStudent);

            dbCtx.SaveChanges();
        }

        private static void CheckInputCharOption(char inputChar)
        {
            if (inputChar == 'a') // ALTER existing student
            {
                AlterStudent();
            }
            else if (inputChar == 'r') // REGISTER new student
            {
                RegisterStudent();
            }
            else if (inputChar == 'l') // LIST Students
            {
                Helper.PrintStudents(dbCtx.Students);
            }
            else
            {
                Console.WriteLine("Error! Invalid option!");
            }
        }
    }
}
