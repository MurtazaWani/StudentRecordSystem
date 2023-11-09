using Microsoft.Extensions.DependencyInjection;
using StudentRecordSystem.Application.Abstractions.IServices;
using StudentRecordSystem.Application.Services;

namespace StudentRecordSystem.Application;

public static class AssemblyReference
{
    public static IServiceCollection GetApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IStudentServices, StudentServices>();
        services.AddScoped<ICourseServices, CourseServices>();
        return services;
    }
}
