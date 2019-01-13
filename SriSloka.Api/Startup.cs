using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;
using SriSloka.Api.ActionFilters;
using SriSloka.Data;
using SriSloka.Model;

namespace SriSloka.Api
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

      services.AddDbContext<SriSlokaDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("SriSlokaTest"),
          b => b.MigrationsAssembly("SriSloka.Api")));

      services.AddMvc(options => options.MaxModelValidationErrors = 10)
        .AddJsonOptions(opts =>
        {
              // To suppress circular reference serialization issue (Temp fix).
              opts.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
              // JSON will stop serializing null values.
              opts.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        });

      services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

      // Needed for NLog
      services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


      services.AddIdentity<ApplicationUser, IdentityRole>(
          opts =>
          {
            opts.Password.RequireDigit = false;
            opts.Password.RequireLowercase = false;
            opts.Password.RequireUppercase = false;
            opts.Password.RequireNonAlphanumeric = false;
            opts.Password.RequiredLength = 6;
            opts.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(20);
            opts.Lockout.MaxFailedAccessAttempts = 15;
          })
        .AddEntityFrameworkStores<SriSlokaDbContext>();

      // Add Authentication
      services.AddAuthentication(opts =>
        {
          opts.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
          opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
          opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        // Add Jwt token support
        .AddJwtBearer(cfg =>
        {
          cfg.RequireHttpsMetadata = false;
          cfg.SaveToken = true;
          cfg.TokenValidationParameters = new TokenValidationParameters()
          {
            // standard configuration
            ValidIssuer = Configuration["Auth:Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(
              Encoding.UTF8.GetBytes(Configuration["Auth:Jwt:Key"])),
            ValidAudience = Configuration["Auth:Jwt:Audience"],
            ClockSkew = TimeSpan.Zero,

            // security switches
            RequireExpirationTime = true,
            ValidateIssuer = true,
            ValidateIssuerSigningKey = true,
            ValidateAudience = true
          };
          cfg.IncludeErrorDetails = true;
        });
      // Authorization policy
      //services.AddAuthorization(options =>
      //{
      //  options.AddPolicy("AdminStaffOnly", policy => policy.RequireClaim("role", "Administrator"));
      //});
	  
      services.AddAutoMapper();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
      loggerFactory.AddNLog();

      env.ConfigureNLog("nlog.config");

      LogManager.Configuration.Variables["connectionString"] = Configuration.GetConnectionString("SriSlokaTest");

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseMvc();

      app.UseAuthentication();

      // Create a service scope to get an ApplicationDbContext instance using DI
      using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
      {
        var dbContext = serviceScope.ServiceProvider.GetService<SriSlokaDbContext>();
        var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
        var userManager = serviceScope.ServiceProvider.GetService<UserManager<ApplicationUser>>();

        // Create the Db if it doesn't exist and applies any pending migration.
        dbContext.Database.Migrate();

        //DbSeeder.Seed(dbContext, roleManager, userManager);
      }
    }
  }
}
