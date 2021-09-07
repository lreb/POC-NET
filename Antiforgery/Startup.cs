using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Antiforgery
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

            string[] origins = new string[] { "http://localhost:4200", "http://localhost:4201" };

            string[] methods = new string[] { "GET", "POST", "DELETE" };

            services.AddCors(o => o.AddPolicy("CorePolicy", builder =>
            {
                builder
                .SetIsOriginAllowed(origin => true)
                //.WithOrigins(origins)
                .AllowAnyHeader()
                .AllowAnyMethod() //.WithMethods(methods)
                .AllowCredentials(); // <<< this is required for cookies to be set on the client - sets the 'Access-Control-Allow-Credentials' to true
            }));

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Antiforgery", Version = "v1" });
            });

            /// CONFIGURE
            /// enable server to detect XSRF-TOKEN 
            /// enabled CSRF token validation in AspNet Core.
            services.AddAntiforgery(options => 
            {
                options.Cookie.Name = "AntiForgeryCookie";
                options.HeaderName = "X-XSRF-TOKEN";

                options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // make secure the cookie

                options.Cookie.HttpOnly = false;
                options.Cookie.IsEssential = true;
                options.Cookie.SameSite = SameSiteMode.None;
                options.Cookie.Path = "/";
            }).AddMvc();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IAntiforgery antiforgery)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Antiforgery v1"));
            }

            /// SERVICE
            /// set a cookie, with the token value, so that it can process the request
            app.UseAntiforgeryToken();

            

            app.UseCors("CorePolicy"); //Tried to put this first line too, but no luck

            //app.UseCors(x => x
            ////.WithOrigins(origins)
            //.AllowAnyOrigin()
            //.AllowAnyMethod()
            //.AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

          

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
