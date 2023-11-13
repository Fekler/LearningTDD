using LearningTDD.API.Business;
using LearningTDD.API.Interfaces;
using LearningTDD.API.Repository;
using LearningTDD.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LearningTDD.IOC
{
    public class StartupIoc
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IStudent, StudentBusiness>();
            services.AddTransient<IStudentRepository, StudentRepository>();

        }
    }
}
