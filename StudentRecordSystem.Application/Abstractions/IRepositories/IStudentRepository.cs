using StudentRecordSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentRecordSystem.Application.Abstractions.IRepositories
{
    public interface IStudentRepository
    {
        public Task<IEnumerable<Student>> GetStudents();
        public Task<int> AddStudent(Student student);
        public Task<Student> UpdateStudent(Student student);
        public Task<int> DeleteStudent(Guid id);
        public Task<Student> GetStudentById(Guid id);
        Task<IEnumerable<Student>> FindBy(Expression<Func<Student, bool>> expression);
        Task<bool> IsExists(Expression<Func<Student, bool>> expression);
        Task<List<Student>> FetchAllAsync(int pageNo, int pageSize);
    }
}
