using LearningTDD.Domain.Interfaces;
using LearningTDD.InfraData.Business;
using LearningTDD.InfraData.Interfaces;
using LearningTDD.InfraData.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LearningTDD.IOC
{
    public class StartupIoc
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IStudent, StudentBusiness>();
            services.AddSingleton<IStudentRepository, StudentRepository>();

        }
    }
}
