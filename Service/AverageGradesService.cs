using Microsoft.EntityFrameworkCore;
using WebAPI.ApplicationContext;
using WebAPI.Contract;
using WebAPI.DTO;

namespace WebAPI.Service
{
    public class AverageGradesService : IAverageGradesService
    {
        private readonly ApplicationDbContext _context;
        public AverageGradesService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<AverageGradeDTO> GetAverageGradesByStudentId(int studentId)
        {
            var sql = @"
            SELECT
                s.FullName AS StudentFullName,
                g.Name AS Group,
                sub.Name AS Subject,
                AVG(grade.Value) AS AverageGrade
            FROM
                Students AS s
                INNER JOIN Groups AS g ON s.GroupId = g.Id
                INNER JOIN Grades AS grade ON s.Id = grade.StudentId
                INNER JOIN Subjects AS sub ON grade.SubjectId = sub.Id
            WHERE
                s.Id = {0}
            GROUP BY
                s.FullName, g.Name, sub.Name
        ";

            var averageGrades = _context.Set<AverageGradeDTO>().FromSqlRaw(sql, studentId).ToList();
            return averageGrades;
        }
        public List<AverageGradeByGroupDTO> GetAverageGradesByGroup(string groupName)
        {
            var sql = @"
            SELECT
                g.Name AS Group,
                sub.Name AS Subject,
                AVG(grade.Value) AS AverageGrade
            FROM
                Groups AS g
                INNER JOIN Students AS s ON g.Id = s.GroupId
                INNER JOIN Grades AS grade ON s.Id = grade.StudentId
                INNER JOIN Subjects AS sub ON grade.SubjectId = sub.Id
            WHERE
                g.Name = {0}
            GROUP BY
                g.Name, sub.Name
        ";

            var averageGrades = _context.Set<AverageGradeByGroupDTO>().FromSqlRaw(sql, groupName).ToList();
            return averageGrades;
        }
    }
}
