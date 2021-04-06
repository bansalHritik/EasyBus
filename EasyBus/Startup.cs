using EasyBus.Business;
using EasyBus.Configuration;
using EasyBus.Data.Contexts;
using EasyBus.Persistence;
using EasyBus.Shared.Functional.Profiles;
using EasyBus.Shared.Infrastructure.Business;
using EasyBus.Shared.Repository.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace EasyBus
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
            // for loading JwtConfig as dependency
            services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));

            // adding cors policies
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://localhost:3000")
                    .WithHeaders("Content-Type", "Authorization");
                });
            });


            // adding Authentication with JWT Scheme
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                var key = Encoding.UTF8.GetBytes(Configuration["JwtConfig:Secret"]);
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateLifetime = true,
                    RequireExpirationTime = false,
                };
            });

            // adding dbContexts
            services.AddDbContext<ApplicationContext>(
               options => options.UseSqlServer(
                   Configuration.GetConnectionString("ApplicationContext")));

            // for identity framework with authentication
            services.AddDefaultIdentity<ApplicationUser>(options => 
                options.SignIn.RequireConfirmedAccount = false
            )
            .AddEntityFrameworkStores<ApplicationContext>();

            services.AddControllers();
            
            // adding profiles for automapper
            services.AddAutoMapper(m =>
            {
                m.AddProfile<BookingMappingProfile>();
                m.AddProfile<BusMappingProfile>();
                m.AddProfile<BusRouteMappingProfile>();
                m.AddProfile<RouteMappingProfile>();
                m.AddProfile<StopMappingProfile>();
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EasyBus", Version = "v1" });
            });

            //adding Dependencies
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IBusBDC, BusBDC>();
            services.AddTransient<IStopBDC, StopBDC>();
            services.AddTransient<IRouteBDC, RouteBDC>();
            services.AddTransient<IBookingBDC, BookingBDC>();
            services.AddTransient<IBusRouteBDC, BusRouteBDC>();
            services.AddTransient<UserManager<ApplicationUser>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EasyBus v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}