

using System.ComponentModel.DataAnnotations;

namespace dummy.Models
{
    public class Students
    {
        [Key]
        public int StudentId { get; set; }
        public string? Name { get; set; }
        public string? Specialty { get; set; }
        public List<Subjects> Subjects { get; set; } = new();

    }
}
