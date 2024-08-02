using LearningTDD.Domain.Interfaces;
using LearningTDD.InfraData;
using LearningTDD.InfraData.Business;
using LearningTDD.InfraData.Interfaces;
using LearningTDD.InfraData.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LearningTDD.IOC
{
    public class StartupIoc
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IStudent, StudentBusiness>();
            services.AddTransient<IStudentRepository, StudentRepository>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionString));


        }
    }
}
