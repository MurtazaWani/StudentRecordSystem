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

        public async Task<StudentResponse> AddStudent(StudentRequest studentRequest)
        {
            Student student = new Student
            {
                Id = Guid.NewGuid(),
                StudentName = studentRequest.Name,
                RollNo = studentRequest.RollNo,
                Email = studentRequest.Email,
                CourseId = studentRequest.CourseId,
            };
            var res = await repository.AddStudent(student);
            if (res > 0)
            {
                return new StudentResponse
                {
                    Id = student.Id,
                    Name = student.StudentName,
                    RollNo = student.RollNo,
                    Email = studentRequest.Email,
                    CourseId = studentRequest.CourseId,
                };
            }
            else return null;
        }

        public async Task<StudentResponse> GetStudentById(Guid id)
        {
            var res = await repository.GetStudentById(id);
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

        public async Task<int> DeleteStudent(Guid id)
        {
            return await repository.DeleteStudent(id);
        }

        public Task<IEnumerable<Student>> GetStudentByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StudentResponse>> FetchAllAsync(int pageNo, int pageSize)
        {
            var students = await repository.FetchAllAsync(pageNo, pageSize);
            return students.Select(x => new StudentResponse
            {
                Id=x.Id,
                Name = x.StudentName,
                RollNo = x.RollNo,
                Email = x.Email,
                CourseId = x.CourseId,
            });
        }
    }
}
