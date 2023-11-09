﻿using StudentRecordSystem.Application.RRModels;

namespace StudentRecordSystem.Application.Abstractions.IServices
{
    public interface IStudentServices
    {
        public Task<IEnumerable<StudentResponse>> GetStudents();
        public Task<int> AddStudent(StudentRequest studentRequest);
    }
}