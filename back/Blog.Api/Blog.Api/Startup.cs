using Blog.Api.Extensions;
using Blog.DataAccess;
using Blog.DataAccess.Context;
using Blog.DataAccess.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Blog.Api.SeedData;
using Blog.Application.Services.Auth.AuthOption;

namespace Blog.Api
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
            var authOptions = Configuration.GetSection("Auth").Get<AuthOptions>();
            services.Configure<AuthOptions>(Configuration.GetSection("Auth"));
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = authOptions.Issuer,
                    ValidAudience = authOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authOptions.Secret))
                };
            });
            services.AddControllers();
            services.AddAutoMapper(typeof(ApiMappingProfile), typeof(DataAccessMappingProfile));
            services.AddDbContext<AppDbContext>(x => x.UseSqlite(Configuration.GetConnectionString("SqliteConnection"),
                optionsBuilder =>
                    optionsBuilder.MigrationsAssembly("Blog.Api")));
            services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>();
            services.AddScoped(cfg => cfg.GetService<IOptions<AuthOptions>>().Value);
            services.AddRepositories();
            services.AddServices();
            // add identity
            var builder = services.AddIdentityCore<UserEntity>(o =>
            {
                // configure identity options
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
            });
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);
            builder.AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Blog.Api", Version = "v1" });
            });
            services.AddTransient<AuthContextSeedData>();

            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AuthContextSeedData seeder)
        {
            
            if (env.IsDevelopment())
            {
                seeder.SeedAdminUser();
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blog.Api v1"));
            }

            app.UseCors("EnableCORS");
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
