using StudentRecordSystem.Application.Abstractions.IRepositories;
using StudentRecordSystem.Application.Abstractions.IServices;
using StudentRecordSystem.Application.RRModels;
using StudentRecordSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRecordSystem.Application.Services;

public class CourseServices : ICourseServices
{
    private readonly ICourseRepository repository;
    public CourseServices(ICourseRepository repository)
    {
        this.repository = repository;
    }
    public async Task<IEnumerable<CourseResponse>> GetCourses()
    {
        var courses = await repository.GetCourses();
        return courses.Select(course => new CourseResponse
               {
                    Id = course.Id,
                    CourseName = course.CourseName,
                    Duration = course.Duration,
               });
    }

    public async Task<CourseResponse> AddCourse(CourseRequest courseRequest)
    {
        Course course = new Course
        {
            Id = Guid.NewGuid(),
            CourseName = courseRequest.CourseName,
            Duration = courseRequest.Duration,
        };
        var res = await repository.AddCourse(course);
        if (res is not null)
        {
            return new CourseResponse
            {
                Id = res.Id,
                CourseName = res.CourseName,
                Duration = res.Duration,
            };
        }
        else return null;
    }

    public async Task<CourseResponse> GetCourseById(Guid id)
    {
        var res = await repository.GetCourseById(id);
        if (res is not null)
        {
            return new CourseResponse
            {
                Id = res.Id,
                CourseName = res.CourseName,
                Duration = res.Duration,
            };
        }
        else return null;
    }

    public async Task<CourseResponse> UpdateCourse(UpdateCourseRequest updateCourseRequest)
    {
        var updateCourse = await repository.GetCourseById(updateCourseRequest.Id);
        updateCourse.Id = updateCourseRequest.Id;
        updateCourse.Duration = updateCourseRequest.Duration;
        updateCourse.CourseName = updateCourseRequest.CourseName;         
        var res = await repository.UpdateCourse(updateCourse);
        return new CourseResponse { Id = res.Id, CourseName = res.CourseName, Duration = res.Duration };
    }

    public async Task<int> DeleteCourse(Guid id)
    {
        var res = await repository.DeleteCourse(id);
        return res > 0 ? res : 0;        
    }
}
