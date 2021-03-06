using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMAPI.Middlewares;
using VMBusiness.Abstract;
using VMBusiness.Concrete;
using VMBusiness.MapProfiles;
using VMDataAccess.Abstract.Repositories;
using VMDataAccess.Concrete.RepositoryImplementations;
using VMEntities.JWT;

namespace VMAPI
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
            services.AddMemoryCache();

            services.AddSingleton<IBrandService, BrandService>();
            services.AddSingleton<IBrandDal, BrandDal>();

            services.AddSingleton<IJwtAuthManager, JwtAuthManager>();
            services.AddSingleton<IMemoryCache, MemoryCache>();

            services.AddSingleton<IModelService, ModelService>();
            services.AddSingleton<IModelDal, ModelDal>();

            services.AddSingleton<IVehicleService, VehicleService>();
            services.AddSingleton<IVehicleDal, VehicleDal>();

            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IUserDal, UserDal>();

            services.AddSingleton<IAuthService, AuthService>();

            services.AddSingleton<IUserRoleDal, UserRoleDal>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "VMAPI",
                    Version = "v1",
                    Contact = new OpenApiContact()
                    {
                        Name = "Okan Kaan CETINKAYA",
                        Email = "okankaan.cetinkaya@gmail.com"
                    }
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                   {
                     new OpenApiSecurityScheme
                     {
                       Reference = new OpenApiReference
                       {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                       }
                      },
                      new string[] { }
                    }
                  });

                
            });

            //JWT Token Autherization Settings
            var jwtTokenConfig = Configuration.GetSection("jwtTokenConfig").Get<JwtTokenConfig>();
            services.AddSingleton(jwtTokenConfig);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtTokenConfig.Issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtTokenConfig.Secret)),
                    ValidAudience = jwtTokenConfig.Audience,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(1)
                };
            });

            //AutoMapper.Extensions.Microsoft.DependencyInjection Included to BusinessLayer and configured here
            services.AddAutoMapper(typeof(MapProfile));

            //FluentValidation.AspNetCore Included to ApiLayer
            services.AddControllers()
                .AddJsonOptions(jsonOptions =>
                {
                    jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
                    jsonOptions.JsonSerializerOptions.IgnoreNullValues = true;
                })
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VMAPI v1"));
            }

            //ExceptionHandling configuration
            app.UseMiddleware<GeneralExceptionHandlingMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            //JWT Token Auth
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
