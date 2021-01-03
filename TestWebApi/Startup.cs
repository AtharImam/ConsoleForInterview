using System;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using TestWebApi.Database;

namespace TestWebApi
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
            services.AddResponseCompression();
            
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });
            
            //services.Configure<KestrelServerOptions>(Configuration.GetSection("Kestrel"));
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new PersonTypeConverter());
            });

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("TestDb"));
            });

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
               {
                   x.RequireHttpsMetadata = false;
                   x.SaveToken = true;
                   x.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("12b6fb24-adb8-4ce5-aa49-79b265ebf256")),
                       ValidateIssuer = false,
                       ValidateAudience = false,
                   };
               });

            services.AddMvc(config => config.ModelBinderProviders.Insert(0, new EmployeeModelBinderProvider()))
                .AddJsonOptions(option => option
                .JsonSerializerOptions.IgnoreNullValues = true);
        }

        public static string DecodeComressedResponseString(string str)
        {
            byte[] stringBuffer = Convert.FromBase64String(str);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                int stringLength = BitConverter.ToInt32(stringBuffer, 0);
                memoryStream.Write(stringBuffer, 0, stringBuffer.Length);

                byte[] contentBuffer = new byte[stringLength];

                memoryStream.Position = 0;
                int contentLength;
                using (GZipStream zip = new GZipStream(memoryStream, CompressionMode.Decompress))
                {
                    contentLength = zip.Read(contentBuffer, 0, contentBuffer.Length);
                }

                var contentBytes = new byte[contentLength];
                Array.Copy(contentBuffer, contentBytes, contentLength);
                return Encoding.UTF8.GetString(contentBytes);
            }
        }

        //Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJPbmxpbmUgSldUIEJ1aWxkZXIiLCJpYXQiOjE1OTE5MDE4MzgsImV4cCI6MTYyMzQzNzgzOCwiYXVkIjoid3d3LmV4YW1wbGUuY29tIiwic3ViIjoianJvY2tldEBleGFtcGxlLmNvbSIsIkdpdmVuTmFtZSI6IkpvaG5ueSIsIlN1cm5hbWUiOiJSb2NrZXQiLCJFbWFpbCI6Impyb2NrZXRAZXhhbXBsZS5jb20iLCJSb2xlIjpbIk1hbmFnZXIiLCJQcm9qZWN0IEFkbWluaXN0cmF0b3IiXX0.I9Zthgg6BGM_ZpNFsaklWFcPJrPxUdYrsxL5lUbYR-0

        //    {
        //"iss": "Online JWT Builder",
        //"iat": 1591901838,
        //"exp": 1623437838,
        //"aud": "www.example.com",
        //"sub": "jrocket@example.com",
        //"GivenName": "Johnny",
        //"Surname": "Rocket",
        //"Email": "jrocket@example.com",
        //"Role": [
        //    "Manager",
        //    "Project Administrator"
        //]
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseAuthentication();

            app.UseAuthorization();
            app.UseHttpsRedirection();

            app.UseCors(options => options.AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
