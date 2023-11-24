using StudentRecordSystem.Application.RRModels;
using StudentRecordSystem.Domain.Entities;

namespace StudentRecordSystem.Application.Abstractions.IServices
{
    public interface IStudentServices
    {
        public Task<IEnumerable<StudentResponse>> GetStudents();
        public Task<StudentResponse> AddStudent(StudentRequest studentRequest);
        public Task<StudentResponse> GetStudentById(Guid id);
        public Task<StudentResponse> UpdateStudent(UpdateStudentRequest updateStudentRequest);
        public Task<int> DeleteStudent(Guid id);
        Task<IEnumerable<StudentResponse>> GetStudentByName(string name);
        Task<IEnumerable<StudentResponse>> FetchAllAsync(int pageNo, int pageSize);
    }
}
