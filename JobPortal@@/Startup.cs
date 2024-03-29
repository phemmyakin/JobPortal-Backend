﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using JobPortal__.Data;
using JobPortal__.Services;
using JobPortal2.Services;
using JobPortal2.Model;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using JobPortal2.Extension;
using Microsoft.Extensions.Logging;

namespace JobPortal__
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Job Portal", Version = "v1" });
            //});

            services.AddSwaggerDocumentation();
            services.AddCors();

            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IEmployerRepository, EmployerRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();

            services.AddMvc();
            services.AddAuthentication(cfg =>
            {
                cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddCookie(cfg => cfg.SlidingExpiration = true)
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = MVSToken.Issuer,
                        ValidAudience = MVSToken.Audience,
                        IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(MVSToken.Key))
                    };
                });


            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = true;
                //options.SignIn.RequireConfirmedEmail = true;
            });
            services.ConfigureApplicationCookie(options =>
            {

                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
            });


            // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=532713

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();


            app.UseAuthentication();
            app.UseSwaggerDocumentation();
            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Job Portal V1");

            //});
            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());


            app.UseMvc();
           // CreateRoles(serviceProvider).Wait();
        }
//        private async Task CreateRoles(IServiceProvider serviceProvider)
//        {
//            //adding custom roles
//            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
//            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
//            string[] roleNames = { "Admin", "Company", "JobSeeker" };
//            IdentityResult roleResult;
//​
//            foreach (var roleName in roleNames)
//            {
//                //creating the roles and seeding them to the database
//                var roleExist = await RoleManager.RoleExistsAsync(roleName);
//                if (!roleExist)
//                {
//                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
//                }
//            }
//​
//            //creating a super user who could maintain the web app
//            var poweruser = new ApplicationUser
//            {
//                UserName = Configuration.GetSection("UserSettings")["Email"],
//                Email = Configuration.GetSection("UserSettings")["Email"]
//            };
//​
//            string UserPassword = Configuration.GetSection("UserSettings")["Password"];
//            var _user = await UserManager.FindByEmailAsync(Configuration.GetSection("UserSettings")["Email"]);
//​
//            if (_user == null)
//            {
//                var createPowerUser = await UserManager.CreateAsync(poweruser, UserPassword);
//                if (createPowerUser.Succeeded)
//                {
//                    //here we tie the new user to the "Admin" role 
//                    await UserManager.AddToRoleAsync(poweruser, "Admin");
//​
//                    }
//            }

//        }
    }
}
