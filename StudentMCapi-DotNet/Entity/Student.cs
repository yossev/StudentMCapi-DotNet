using System.ComponentModel.DataAnnotations;

namespace StudentMCapi_DotNet.Entity
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Major { get; set; } = String.Empty;
        public double gpa { get; set; }
    }
}
