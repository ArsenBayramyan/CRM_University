using CRM_University.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CRM_University.Data.Context
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Tuition> Tuitions { get; set; }
        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<Examination> Examinations { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<SentEmails> UnpaidStudents { get; set; }
    }
}
