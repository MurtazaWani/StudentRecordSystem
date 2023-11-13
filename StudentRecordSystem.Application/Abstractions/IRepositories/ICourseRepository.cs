using StudentRecordSystem.Application.RRModels;
using StudentRecordSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentRecordSystem.Application.Abstractions.IRepositories;

public interface ICourseRepository
{
    Task<IEnumerable<Course>> GetCourses();
    Task<int> AddCourse(Course course);
    Task<Course> GetCourseById(Guid id);
    Task<Course> UpdateCourse(Course course);
    Task<int> DeleteCourse(Guid id);
    Task<IEnumerable<Course>> FindBy(Expression<Func<Course, bool>> expression);
    Task<bool> IsExists(Expression<Func<Course, bool>> expression);
    Task<List<Course>> FetchAllAsync(int pageNo, int pageSize);
}
