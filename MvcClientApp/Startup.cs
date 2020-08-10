using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Net.Http.Headers;

namespace MvcClientApp
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
            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
            services.AddHttpClient("ApiClient", async (serviceProvider, client) =>
            {
                var context = serviceProvider.GetService<IHttpContextAccessor>();
                var token = await context.HttpContext.GetTokenAsync("access_token");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                client.BaseAddress = new Uri("http://localhost:57741");
            });

            services.AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                config.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
                .AddCookie()
                .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, config =>
                {
                    config.RequireHttpsMetadata = false;
                    config.Authority = "http://localhost:58995";
                    config.ClientId = "MvcClientApp";
                    config.ClientSecret = "MvcClientAppSecret";
                    config.ResponseType = OpenIdConnectResponseType.Code;
                    config.SaveTokens = true;
                    config.Scope.Add("api1");
                });
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

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}