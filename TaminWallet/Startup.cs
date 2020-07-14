using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Data;
using Data.Repositories;
using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Parbad.Builder;

namespace TaminWallet
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _siteSetting = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
            _Parbad = configuration.GetSection(nameof(Common.Parbad)).Get<Common.Parbad>();
        }
        private readonly SiteSettings _siteSetting;
        private readonly Common.Parbad _Parbad;
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SqlServer")));
            services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {

                //Password Settings
                options.Password.RequireDigit = _siteSetting.IdentitySettings.PasswordRequireDigit;
                options.Password.RequiredLength = _siteSetting.IdentitySettings.PasswordRequiredLength;
                options.Password.RequireNonAlphanumeric = _siteSetting.IdentitySettings.PasswordRequireNonAlphanumic; //#@!
                options.Password.RequireUppercase = _siteSetting.IdentitySettings.PasswordRequireUppercase;
                options.Password.RequireLowercase = _siteSetting.IdentitySettings.PasswordRequireLowercase;
                //UserName Settings
                options.User.RequireUniqueEmail = _siteSetting.IdentitySettings.RequireUniqueEmail;
                //Singin Settings
                options.SignIn.RequireConfirmedEmail = true;
                //identityOptions.SignIn.RequireConfirmedPhoneNumber = false;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                // If the LoginPath isn't set, ASP.NET Core defaults 
                // the path to /Account/Login.
                options.LoginPath = "/Account/Login";
                // If the AccessDeniedPath isn't set, ASP.NET Core defaults 
                // the path to /Account/AccessDenied.
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddParbad()
                .ConfigureGateways(gateways =>
                {
                    if (!string.IsNullOrEmpty(_Parbad.Gateways.IranKish.MerchantId))
                    {
                        gateways
                        .AddIranKish().WithAccounts(accounts =>
                        {
                            accounts.AddInMemory(acc =>
                            {
                                acc.MerchantId = _Parbad.Gateways.IranKish.MerchantId;
                                acc.Name = "Default";
                            });
                        });
                    }
                    if (!string.IsNullOrEmpty(_Parbad.Gateways.Mellat.MyUsername))
                    {
                        gateways.AddMellat().WithAccounts(accounts =>
                        {
                            accounts.AddInMemory(account =>
                            {
                                account.TerminalId = _Parbad.Gateways.Mellat.TerminalId;
                                account.UserName = _Parbad.Gateways.Mellat.MyUsername;
                                account.UserPassword = _Parbad.Gateways.Mellat.UserPassword;
                            });
                        });
                    }
                    if (!string.IsNullOrEmpty(_Parbad.Gateways.ZarinPall.Name))
                    {
                        gateways
                        .AddZarinPal()
                        .WithAccounts(accounts =>
                        {
                            accounts.AddInMemory(acc =>
                            {
                                acc.IsSandbox = _Parbad.Gateways.ZarinPall.IsSandbox;
                                acc.MerchantId = _Parbad.Gateways.ZarinPall.MerchantId;
                                acc.Name = _Parbad.Gateways.ZarinPall.Name;
                            });
                        });
                    }
                    if (!string.IsNullOrEmpty(_Parbad.Gateways.Parsian.Pin))
                    {
                        gateways
                        .AddParsian()
                        .WithAccounts(accounts =>
                        {
                            accounts.AddInMemory(acc =>
                            {
                                acc.LoginAccount = _Parbad.Gateways.Parsian.Pin;
                            });
                        });
                    }

                    gateways
                        .AddParbadVirtual()
                        .WithOptions(options => options.GatewayPath = "/MyVirtualGateway");
                })
                .ConfigureHttpContext(builder => builder.UseDefaultAspNetCore())
                .ConfigureStorage(builder => builder.UseMemoryCache());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();
            app.UseCookiePolicy();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Payment}/{action=Pay}/{id?}");
            });
            app.UseParbadVirtualGatewayWhenDeveloping();
        }
    }
}
