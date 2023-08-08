using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Grade> Grades { get; set; }
    }
}
