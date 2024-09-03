using LearningTDD.IOC;


namespace LearningTDD.API
{
    public class Startup(IConfiguration configuration)
    {
        public IConfiguration Configuration { get; } = configuration;

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers().AddNewtonsoftJson();
            object p = services.AddControllersWithViews().AddNewtonsoftJson();
            services.AddSwaggerGen(c => { }).AddSwaggerGenNewtonsoftSupport();
            StartupIoc.ConfigureServices(services, Configuration);

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
