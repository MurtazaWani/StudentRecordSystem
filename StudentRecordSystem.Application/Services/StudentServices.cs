using StudentRecordSystem.Application.Abstractions.IRepositories;
using StudentRecordSystem.Application.Abstractions.IServices;
using StudentRecordSystem.Application.RRModels;
using StudentRecordSystem.Domain.Entities;

namespace StudentRecordSystem.Application.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly IStudentRepository repository;

        public StudentServices(IStudentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<StudentResponse>> GetStudents()
        {
            var students = await repository.GetStudents();
            return students.Select(student => new StudentResponse
            {
                Id = student.Id,
                Name = student.StudentName,
                RollNo = student.RollNo,
                Email = student.Email,
                CourseId = student.CourseId,
            });
        }

        public async Task<int> AddStudent(StudentRequest studentRequest)
        {
            Student student = new Student
            {
                Id = Guid.NewGuid(),
                StudentName = studentRequest.Name,
                RollNo = studentRequest.RollNo,
                Email = studentRequest.Email,
                CourseId = studentRequest.CourseId,
            };
            return await repository.AddStudent(student);
        }

        public Task<StudentResponse> GetStudentById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<StudentResponse> UpdateStudent(UpdateStudentRequest updateStudentRequest)
        {
            Student student = new Student
            {
                Id = updateStudentRequest.Id,
                StudentName = updateStudentRequest.Name,
                RollNo = updateStudentRequest.RollNo,
                Email = updateStudentRequest.Email,
                CourseId = updateStudentRequest.CourseId,
            };
            var res = await repository.UpdateStudent(student);
            if (res != null)
            {
                return new StudentResponse
                {
                    Id = res.Id,
                    Name = res.StudentName,
                    RollNo = res.RollNo,
                    Email = res.Email,
                    CourseId = res.CourseId,
                };
            }
            else return null;
        }

        public Task<StudentResponse> DeleteStudent(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
