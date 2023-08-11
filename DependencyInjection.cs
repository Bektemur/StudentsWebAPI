using WebAPI.Contract;
using WebAPI.Middlewares;
using WebAPI.Service;

namespace WebAPI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services,
            ConfigurationManager configuration)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<IGradeService, GradeService>();
            services.AddScoped<ExceptionHandlingMiddleware>();
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IAverageGradesService, AverageGradesService>();
            return services;
        }
    }
}
