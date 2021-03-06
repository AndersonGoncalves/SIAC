﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SiacWeb.Models;
using SiacWeb.Data;
using SiacWeb.Services;
using SiacWeb.Models.Interface;
using Microsoft.AspNetCore.Identity;
using SessionSample.Middleware;

namespace SiacWeb
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<SiacWebContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SiacWebContext")));

            //Registrando os serviços no sistema de injeção de dependência da aplicação
            services.AddScoped<SeedingService>();
            services.AddScoped<EmpresaService>();
            services.AddScoped<CentroDeCustoService>();
            services.AddScoped<FuncionarioService>();
            services.AddScoped<FornecedorService>();
            services.AddScoped<TransportadoraService>();
            services.AddScoped<AutonomoService>();
            services.AddScoped<IUser, AspNetUser>();
            services.AddScoped<RoleService>();
            services.AddScoped<UsuarioService>();
            services.AddScoped<ClienteService>();
            services.AddScoped<AuditoriaService>();
            services.AddScoped<GrupoDeProdutoService>();
            services.AddScoped<SubGrupoDeProdutoService>();
            services.AddScoped<ProdutoService>();
            services.AddScoped<CodigoDeBarraService>();
            services.AddScoped<InventarioService>();
            services.AddScoped<InventarioItemService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;
                options.User.RequireUniqueEmail = true;
            });
            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromDays(150);
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });
            // Add application services.
            //services.AddTransient<IEmailSender, EmailSender>();
            services.AddMvc();

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromDays(1); //Obrigar o usuário fazer o login depois de um dia logado
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SeedingService seedingService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                seedingService.Seed();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseSession();
            app.UseHttpContextItemsMiddleware();
            app.UseMvc();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{produtoId?}");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{inventarioId?}");
            });

        }
    }
}