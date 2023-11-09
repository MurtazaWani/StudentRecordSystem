
using StudentRecordSystem.Application.Abstractions.IRepositories;
using StudentRecordSystem.Domain.Entities;
using StudentRecordSystem.Persistence.Data;

namespace StudentRecordSystem.Persistence.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentRecordSystemDbContext context;

        public StudentRepository(StudentRecordSystemDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await Task.Run(() => context.Set<Student>());
        }

        public async Task<int> AddStudent(Student student)
        {
            var res = context.Set<Student>().AddAsync(student);
            return await context.SaveChangesAsync();
        }
    }
}
