
using Microsoft.EntityFrameworkCore;
using StudentRecordSystem.Application.Abstractions.IRepositories;
using StudentRecordSystem.Domain.Entities;
using StudentRecordSystem.Persistence.Data;
using System.Linq.Expressions;

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

        public async Task<Student> UpdateStudent(Student student)
        {
            await Task.Run(() => context.Set<Student>().Update(student));
            var res = await context.SaveChangesAsync();
            if (res > 0) return student;
            else return null;
        }

        public async Task<int> DeleteStudent(Guid id)
        {
            Student student = new Student { Id = id };
            if(student != null)
            {
                await Task.Run(() => context.Set<Student>().Remove(student));
                return await context.SaveChangesAsync();
            }
            else return 0;
        }

        public async Task<Student> GetStudentById(Guid id)
        {
            return await context.Set<Student>().FindAsync(id);
        }

        public Task<IEnumerable<Student>> FindBy(Expression<Func<Student, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExists(Expression<Func<Student, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Student>> FetchAllAsync(int pageNo, int pageSize)
        {
            return await context.Set<Student>()
                .Skip((pageNo - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
