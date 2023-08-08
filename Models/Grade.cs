using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Grade
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(StudentId))]
        public int StudentId { get; set; }
        public Student Student { get; set; }
        [ForeignKey(nameof(SubjectId))]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int Score { get; set; }
    }
}
