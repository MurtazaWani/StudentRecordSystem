using StudentRecordSystem.Application.RRModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
}
