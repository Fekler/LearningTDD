using LearningTDD.API.Business;
using LearningTDD.API.Interfaces;
using LearningTDD.API.Repository;
using LearningTDD.Controllers;
using LearningTDD.Domain.Interfaces;
using Microsoft.OpenApi.Models;


namespace LearningTDD.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers().AddNewtonsoftJson();
            object p = services.AddControllersWithViews().AddNewtonsoftJson();
            services.AddSwaggerGen(c => { }).AddSwaggerGenNewtonsoftSupport();

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Courses"));
            app.UseHttpsRedirection();
            app.UseStatusCodePages();
            app.UseRouting();
            //app.UseAuthentication();
            //app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
