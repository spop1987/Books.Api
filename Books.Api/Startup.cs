using Books.DataBase.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Books.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDependencyServices();
            ConfigureDb(services);
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "BookApi", Version = "v1" });
            });
        }

        protected virtual void ConfigureDb(IServiceCollection services)
        {
            services.AddDbContext<BookDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("BooksConn"));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(opt => opt.SwaggerEndpoint("/swagger/v1/swagger.json", "BooksApi v1"));
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            PrepDb.PrepPopulation(app);
        }
    }
}
