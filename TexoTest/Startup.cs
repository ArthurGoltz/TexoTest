using Microsoft.OpenApi.Models;
using TexoTest.Data;
using Microsoft.EntityFrameworkCore;
using TexoTest.Service;
using TexoTest.Repository;
using LightInject;
namespace TexoTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<ICSVService, CSVService>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "MovieReader", Version = "v1" });
            });
            //services.AddDbContext<MovieReaderContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("MovieReaderDB"))); 
            
            services.AddDbContext<MovieReaderContext>(options => options.UseInMemoryDatabase("MovieReaderDB"));
            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "My API V2");
             
            });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
