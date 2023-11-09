using StudentRecordSystem.Application.Abstractions.IRepositories;
using StudentRecordSystem.Application.RRModels;
using StudentRecordSystem.Domain.Entities;
using StudentRecordSystem.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRecordSystem.Persistence.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly StudentRecordSystemDbContext context;
    public CourseRepository(StudentRecordSystemDbContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<Course>> GetCourses()
    {
        return await Task.Run(() => context.Set<Course>());
    }

    public async Task<Course> AddCourse(Course course)
    {
        await context.Set<Course>().AddAsync(course);
        var res = await context.SaveChangesAsync();
        return res > 0 ? course : null;
    }

    public async Task<Course> GetCourseById(Guid id)
    {
        return await context.Set<Course>().FindAsync(id);
    }

    public async Task<Course> UpdateCourse(Course course)
    {
        Task.Run(() => context.Set<Course>().Update(course));
        var res = await context.SaveChangesAsync();
        return res > 0 ? course : null;
    }

    public async Task<int> DeleteCourse(Guid id)
    {
        var obj = await context.Set<Course>().FindAsync(id);
        if(obj != null)
        {
            context.Set<Course>().Remove(obj);
            return await context.SaveChangesAsync();
        }
        else return 0;
    }
}
