using System.Collections.Generic;

namespace MyTest.Models
{
    public class HomeTeacher
    {
        public int Id { get; set; }
        public string TeacherName { get; set; }
        public string Subject { get; set; }
        public string teachergender { get; set; }

        public List<Students> Students { get; set; } = new();
    }
    }
