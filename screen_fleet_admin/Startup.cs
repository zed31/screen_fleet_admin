using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using screen_fleet_admin.Contexts;
using screen_fleet_admin.Models;
using screen_fleet_admin.Repositories;

namespace screen_fleet_admin
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
            services.AddMvc();
            services.Configure<Settings>(options =>
            {
                options.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                options.Database = Configuration.GetSection("MongoConnection:Database").Value;
                options.Collection = Configuration.GetSection("MongoConnection:Collection").Value;
            });
            services.AddTransient<ITVRepository, TVRepository>();
            services.AddTransient<IResourceRepository, ResourceRepository>();
            services.AddTransient<MongoClientContext, MongoClientContext>();
            services.AddTransient<MongoContext<TVModel>, MongoContext<TVModel>>();
            services.AddTransient<MongoContext<DbModelBase>, MongoContext<DbModelBase>>();
            services.AddTransient<MongoContext<CompositionModel>, MongoContext<CompositionModel>>();
            services.AddTransient<MongoContext<ResourceModel>, MongoContext<ResourceModel>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes => 
            {
                routes.MapRoute(
                    name: "SystemConfig",
                    template: "api/{controller}/tv",
                    defaults: new { controller = "System", Action = "PostTv" }
                );
            });
        }
    }
}
