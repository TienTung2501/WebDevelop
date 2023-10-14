using Microsoft.EntityFrameworkCore;
using webtemplate.Models;

namespace webtemplate.Data
{
    public class SchoolContext:DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Learner> Learners { get; set;}
        public DbSet<Enrollment> Enrollments { get; set; }  
        public DbSet<Major> Majors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Major>().ToTable(nameof(Major));// chuyển đối tượng này thành bảng
            modelBuilder.Entity<Course>().ToTable(nameof(Course));
            modelBuilder.Entity<Learner>().ToTable(nameof(Learner));
            modelBuilder.Entity<Enrollment>().ToTable(nameof(Enrollment));

        }
    }
}
