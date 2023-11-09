using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentRecordSystem.Application.Abstractions.IRepositories;
using StudentRecordSystem.Persistence.Data;
using StudentRecordSystem.Persistence.Repositories;

namespace StudentRecordSystem.Persistence;

public static class AssemblyReferences
{
    public static IServiceCollection GetPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddDbContextPool<StudentRecordSystemDbContext>(option => option.UseSqlServer(configuration.GetConnectionString(nameof(StudentRecordSystemDbContext))));
        return services;
    }
}
