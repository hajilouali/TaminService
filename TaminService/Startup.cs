using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using ElmahCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Services.Services.EmailService;
using WebFramework.Configuration;
using WebFramework.CustomMapping;
using WebFramework.Middlewares;
using WebFramework.Swagger;

namespace TaminService
{
    public class Startup
    {
        private readonly SiteSettings _siteSetting;
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            AutoMapperConfiguration.InitializeAutoMapper();

            _siteSetting = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var emailConfig = Configuration.GetSection(nameof(SiteSettings))
                .Get<SiteSettings>();
            services.AddSingleton(emailConfig.EmailConfiguration);
            //services.AddScoped<IEmailSender, EmailSender>();
            services.Configure<FormOptions>(o => {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });

            services.Configure<SiteSettings>(Configuration.GetSection(nameof(SiteSettings)));


            services.AddDbContext(Configuration);

            services.AddCustomIdentity(_siteSetting.IdentitySettings);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //services.AddMinimalMvc();

            services.AddElmah(Configuration, _siteSetting);

            services.AddJwtAuthentication(_siteSetting.JwtSettings);

            services.AddCustomApiVersioning();

            services.AddSwagger();

            return services.BuildAutofacServiceProvider();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            app.IntializeDatabase();

            app.UseCustomExceptionHandler();

            app.UseHsts(env);

            app.UseElmah();

            app.UseHttpsRedirection();

            app.UseSwaggerAndUI();

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
