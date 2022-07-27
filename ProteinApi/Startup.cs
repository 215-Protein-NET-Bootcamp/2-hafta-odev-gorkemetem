using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ProteinApi.Data;
using ProteinApi.Service;
using ProteinApi.Service.Mapper;

namespace ProteinApi
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

            // db  sql server or posgre
            var dbtype = Configuration.GetSection("ConnectionStrings:DbType").Get<string>().ToString();
            if (dbtype == "SQL")
            {
                var dbConfig = Configuration.GetConnectionString("DefaultConnection");
                services.AddDbContext<AppDbContext>(options => options
                   .UseSqlServer(dbConfig)
                   );
            }
            else if (dbtype == "Postgre")
            {
                var dbConfig = Configuration.GetConnectionString("PostgreSqlConnection");
                services.AddDbContext<AppDbContext>(options => options
                   .UseNpgsql(dbConfig)
                   );
            }

            // dapper 
            services.AddSingleton<DapperDbContext>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDepartmentService, DepartmentService>();

            // uow
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // mapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            services.AddSingleton(mapperConfig.CreateMapper());


            // services
            services.AddSingleton<SingletonService>();
            services.AddScoped<ScopedService>();
            services.AddTransient<TransientService>();

            // add services
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IFolderRepository, FolderRepository>();
            services.AddScoped<IFolderService, FolderService>();
            

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProteinApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProteinApi v1"));

            app.UseHttpsRedirection();


            // middleware 
            app.UseMiddleware<HeartbeatMiddleware>();
            app.UseMiddleware<ErrorHandlerMiddleware>();


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            // services for Transient - Singleton - Scoped
            app.Use((ctx, next) =>
            {
                // Get all the services and increase their counters...
                var singleton = ctx.RequestServices.GetRequiredService<SingletonService>();
                var scoped = ctx.RequestServices.GetRequiredService<ScopedService>();
                var transient = ctx.RequestServices.GetRequiredService<TransientService>();

                singleton.Counter++;
                scoped.Counter++;
                transient.Counter++;

                return next();
            });
            app.Run(async ctx =>
            {
                // ...then do it again...
                var singleton = ctx.RequestServices.GetRequiredService<SingletonService>();
                var scoped = ctx.RequestServices.GetRequiredService<ScopedService>();
                var transient = ctx.RequestServices.GetRequiredService<TransientService>();

                singleton.Counter++;
                scoped.Counter++;
                transient.Counter++;

                // ...and display the counter values.
                await ctx.Response.WriteAsync($"Singleton: {singleton.Counter}\n");
                await ctx.Response.WriteAsync($"Scoped: {scoped.Counter}\n");
                await ctx.Response.WriteAsync($"Transient: {transient.Counter}\n");
            });

        }
    }
}
