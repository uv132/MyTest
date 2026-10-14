using System.Collections.Generic;

namespace MyTest.Models
{
    public class School
    {
        public  int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public string  city { get; set; }
        // Navigation property - collection of students
        public List<Students> Students { get; set; } = new();

    }
}
