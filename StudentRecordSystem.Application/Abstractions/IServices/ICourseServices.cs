using StudentRecordSystem.Application.RRModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentRecordSystem.Application.Abstractions.IServices;

public interface ICourseServices
{
    Task<IEnumerable<CourseResponse>> GetCourses();
    Task<CourseResponse> AddCourse(CourseRequest courseRequest);
    Task<CourseResponse> GetCourseById(Guid id);
    Task<CourseResponse> UpdateCourse(UpdateCourseRequest updateCourseRequest);
    Task<int> DeleteCourse(Guid id);
    Task<IEnumerable<CourseResponse>> GetCourseByName(string name);
    Task<IEnumerable<CourseResponse>> FetchAllAsync(int pageNo, int pageSize);
}
