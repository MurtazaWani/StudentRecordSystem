using Microsoft.EntityFrameworkCore;
using StudentRecordSystem.Domain.Entities;

namespace StudentRecordSystem.Persistence.Data;

public class StudentRecordSystemDbContext : DbContext
{
    public StudentRecordSystemDbContext(DbContextOptions<StudentRecordSystemDbContext> options):base(options)
    {
        // we can write fluent-api here
    }

    public DbSet<Course> Courses { get; set; }
    public DbSet<Student> Students { get; set; }
}
