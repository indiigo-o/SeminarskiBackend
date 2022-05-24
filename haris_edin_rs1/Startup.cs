using Faisal.Schedulers;
using haris_edin_rs1.Data;
using haris_edin_rs1.EmailConfig;
using haris_edin_rs1.Hubs;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System;

namespace haris_edin_rs1
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
            
            // Add Quartz services
            services.AddHostedService<QuartzHostedService>();
            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            // Add our job
            services.AddSingleton<RemindersJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(RemindersJob),
                cronExpression: "0 0/5 * 1/1 * ? *"));

            services.AddControllers();
            services.AddSignalR();

            services.AddCors();
            services.AddCors(options =>
            {
                options.AddPolicy(
                name: "AllowOrigin",
                builder => {

                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

                });

            });

            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSwaggerGen();
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "V1",
                    Title = "Api",
                    Description = "API za bazu"
                });
            });
            services.AddAntiforgery(options => options.HeaderName = "x-xsrf-token");
            services.AddMvc();
            services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyMethod().AllowAnyHeader()
                .WithOrigins("https://localhost:44308/")
                .AllowCredentials();
            }));
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            var antiforgery = app.ApplicationServices.GetRequiredService<IAntiforgery>();

            app.Use(async (context, next) =>
            {
                string path = context.Request.Path.Value;
                if (path != null )
                {
                    // XSRF-TOKEN used by angular in the $http if provided
                    var tokens = antiforgery.GetAndStoreTokens(context);
                    context.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken,
                        new CookieOptions() { HttpOnly = false });

                }



                await next();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API za bazu");
                c.RoutePrefix = string.Empty; 
            });
            app.UseCors("AllowOrigin");
            app.UseCors(
              options => options
              .SetIsOriginAllowed(x => _ = true)
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials()
          ); //This needs to set everything allowed


            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseCors("CorsPolicy");


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/chatsocket");     // path will look like this https://localhost:44308/chatsocket 
            });



        }

    }
}
