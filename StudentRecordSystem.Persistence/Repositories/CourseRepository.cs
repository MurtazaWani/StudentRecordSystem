using Microsoft.EntityFrameworkCore;
using StudentRecordSystem.Application.Abstractions.IRepositories;
using StudentRecordSystem.Domain.Entities;
using StudentRecordSystem.Persistence.Data;
using System.Linq.Expressions;

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

    public async Task<int> AddCourse(Course course)
    {
        await context.Set<Course>().AddAsync(course);
        return await context.SaveChangesAsync();
    }

    public async Task<Course> GetCourseById(Guid id)
    {
        return await context.Set<Course>().FindAsync(id);
    }

    public async Task<Course> UpdateCourse(Course course)
    {
        await Task.Run(() => context.Set<Course>().Update(course));
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

    public async Task<IEnumerable<Course>> FindBy(Expression<Func<Course, bool>> expression)
    {
        return await Task.Run(() => context.Set<Course>().Where(expression));
    }

    public Task<bool> IsExists(Expression<Func<Course, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Course>> FetchAllAsync(int pageNo, int pageSize)
    {
        return await context.Set<Course>()
            .Skip((pageNo - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
}
