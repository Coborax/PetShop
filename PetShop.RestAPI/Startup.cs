using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PetShop.Core.Services;
using PetShop.Domain.Repositories;
using PetShop.Domain.Services;
using PetShop.Infrastructure.Data.EFCore;
using PetShop.Infrastructure.Data.EFCore.Repositories;
using PetShop.Infrastructure.Data.InMemory;
using PetShop.Infrastructure.Data.InMemory.Repositories;

namespace PetShop.RestAPI
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "PetShop.RestAPI", Version = "v1"});
            });

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });

            services.AddDbContext<PetShopContext>(opt =>
            {
                opt
                    .UseLoggerFactory(loggerFactory)
                    .UseSqlite("Data Source=petShop.db");
            }, ServiceLifetime.Transient);

            //services.AddSingleton<FakeDB>();
            services.AddScoped<IPetRepo, EFCorePetRepo>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IPetTypeRepo, EFCorePetTypeRepo>();
            services.AddScoped<IPetTypeService, PetTypeService>();
            //services.AddScoped<IUnitOfWork, InMemoryUnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PetShop.RestAPI v1"));

                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<PetShopContext>();
                    ctx.Database.EnsureDeleted();
                    ctx.Database.EnsureCreated();
                }
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}