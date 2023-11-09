using StudentRecordSystem.Application.RRModels;
using StudentRecordSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRecordSystem.Application.Abstractions.IRepositories;

public interface ICourseRepository
{
    Task<IEnumerable<Course>> GetCourses();
    Task<Course> AddCourse(Course course);
    Task<Course> GetCourseById(Guid id);
    Task<Course> UpdateCourse(Course course);
    Task<int> DeleteCourse(Guid id);
}
