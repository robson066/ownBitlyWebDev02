using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using WebDev02_Homework;
using WebDev02_Homework.Interfaces;
using WebDevHomework.Interfaces;
using WebDevHomework.Repository;
using WebDevHomework.Services;

namespace WebDevHomework
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
            services.AddDbContext<LinkDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("LinkDbConnection")));            
            services.AddSingleton<Hasher>();
            services.AddTransient<IHashDecoder, Decoder>();
            services.AddTransient<IHashEncoder, Encoder>();
            services.AddTransient<ILinkRepository, LinkRepository>();            
            services.AddTransient<ILinkReader, LinkReader>();
            services.AddTransient<ILinkWriter, LinkWriter>();
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Info{ Title = "OwnBitly API", Version = "v1" }));
            services.AddMvcCore().AddApiExplorer();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseSwagger();            
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OwnBitly API"));
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Link}/{action=Index}/{id?}");
            });
        }
    }
}