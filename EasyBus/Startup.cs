using EasyBus.Business;
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
            services.AddControllers();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"])),
                };
            });


            services.AddDbContext<ApplicationContext>(
                options => options.UseSqlServer(
                    Configuration.GetConnectionString("ApplicationContext")));


            services.AddDefaultIdentity<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();


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


            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IBusBDC, BusBDC>();
            services.AddTransient<IStopBDC, StopBDC>();
            services.AddTransient<IRouteBDC, RouteBDC>();
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

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}