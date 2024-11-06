namespace DatabasUppgift1
{
    public struct StudentProps(string FirstName, string LastName, string City)
    {
        public string FirstName = FirstName;
        public string LastName = LastName;
        public string City = City;
    }

    internal class Student
    {
        public int StudentId { get; set; } // Primary key

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? City { get; set; }
    }
}
