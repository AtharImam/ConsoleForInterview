using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using TestWebApp.Database;

namespace TestWebApp
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
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build();
            });

            services.AddDbContext<Chain1DbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Chain1Db"));
            });

            services.AddDbContext<Chain2DbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Chain2Db"));
            });

            services.AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            //.AddCookie("Bearer", options =>
            //  {
            //      options.LoginPath = "/auth/index";
            //      options.LogoutPath = "/auth/logout";
            //      options.AccessDeniedPath = "/auth/index";
            //      options.Cookie.HttpOnly = true;
            //      options.Cookie.Name = Constants.AuthCookie;
            //      options.ExpireTimeSpan = TimeSpan.FromHours(1);
            //  });
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = GetTokenValidationParameters();
                options.ForwardSignIn = "/auth/index";
                //options.LoginPath = "/auth/index";
                //options.LogoutPath = "/auth/logout";
                //options.AccessDeniedPath = "/auth/index";
                //options.Cookie.HttpOnly = true;
                //options.Cookie.Name = Constants.AuthCookie;
                //options.ExpireTimeSpan = TimeSpan.FromHours(1);
            });

            services.AddControllersWithViews();
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
            }

            app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthentication();
            //app.UseCookiePolicy();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private TokenValidationParameters GetTokenValidationParameters()
        {
            return new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey =
                   new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Constants.SecretKey)),
                ValidateIssuer = true,
                ValidIssuer = Constants.Issuer,

                ValidateAudience = true,
                ValidAudience = Constants.Issuer,

                ValidateLifetime = true
            };
        }
    }
}
