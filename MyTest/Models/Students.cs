namespace MyTest.Models
{
    public class Students
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GradeLevel { get; set; }
        public int SchoolId  { get; set; }

        // Navigation property to School
        public School School { get; set; }

    }
}
