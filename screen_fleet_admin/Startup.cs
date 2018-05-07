using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using screen_fleet_admin.Contexts;
using screen_fleet_admin.Models;
using screen_fleet_admin.Repositories;

namespace screen_fleet_admin
{
    /*! \brief Auto-generated class used upon the server start */
    public class Startup
    {
        /*! \brief Constructor of the Startup class
         * @param[in]   configuration   The configuration of the software
         */
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /*! @return the server configuration */
        public IConfiguration Configuration { get; }

        /*! \brief Function that configures the services of the server
         * @param[in]   services    The service collection manager
         */
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
            services.AddTransient<MongoContext<ResourceModel>, MongoContext<ResourceModel>>();
        }

        /*! \brief Configure the application
         * @param[in]   app the application builder
         * @param[in]   env the environments host
         */
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
