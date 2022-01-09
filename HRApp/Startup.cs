using System;
using System.IO;
using System.Text;
using HR.BLL;
using HR.DAL;
using HR.DAL.Smtp;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

using Newtonsoft.Json;

namespace HRApp
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
            services.AddDbContext<SmartERPStandardContext>(options => options.UseSqlServer(SmtpConfig.GrtConnectionString()));
            //Microsoft.Extensions.DependencyInjection.OptionsConfigurationServiceCollectionExtensions.Configure<SmtpConfig>(services, Configuration.GetSection("ConnectionString"));
           
            services.AddControllers();
            services.AddMvc();
            services.AddControllersWithViews();
            #region Adding JWT

            services.AddAuthentication(s =>
            {
                s.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                s.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.ASCII.GetBytes(Configuration.GetValue<string>("JWTKey"))
                        
                        ),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });



            services.AddSingleton<IJwtAuthentication>(new JwtAuthentication(Configuration.GetValue<string>("JWTKey")));

            #endregion

            services.AddControllersWithViews().AddNewtonsoftJson(op => 
            { op.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; });
            services.AddHttpContextAccessor();

            //services.AddDbContext<SmartERPStandardContext>();

            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(EmployeeBll));
            services.AddScoped(typeof(AccountBll));
            services.AddScoped(typeof(VacationBll));
            services.AddScoped(typeof(TechnicalSupportBll));
            services.AddScoped(typeof(LeavPermisionBll));
            services.AddScoped(typeof(SalaryIssueBll));
            services.AddScoped(typeof(LoanBll));
            services.AddScoped(typeof(ReportsBLL));
            services.AddScoped(typeof(StoreBLL));
            services.AddScoped(typeof(LocationBLL));
            services.AddScoped(typeof(JobBLL));
            services.AddScoped(typeof(ShiftBLL));
            services.AddScoped(typeof(HomeBLL));
            services.AddScoped(typeof(SettingBLL));
            services.AddScoped(typeof(AppSettingBll));
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           
            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());


            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                  "Default", pattern: "{controller=home}/{action=index}/{id?}"
                  );

            });
        }
    }
}
