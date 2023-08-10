using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace WebAPI.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [ForeignKey(nameof(GroupId))]
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public List<Grade> Grades { get; set; }
    }
}
