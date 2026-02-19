using System.Collections.Generic;

namespace Ch04MovieListDahlstrom.Models
{
    public class StudentViewModel
    {
        public List<Student> Students { get; set; } = new List<Student>();
        public int AccessLevel { get; set; }
    }
}