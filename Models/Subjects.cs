using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace dummy.Models
{
    public class Subjects
    {
        [Key]
        public int SubjectId { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Grade { get; set; }

        // Foreign key
        [ForeignKey("StudentId")]
        public int StudentId { get; set; }
        public Students? Student { get; set; }

    }
}
