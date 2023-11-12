using StudentRecordSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
