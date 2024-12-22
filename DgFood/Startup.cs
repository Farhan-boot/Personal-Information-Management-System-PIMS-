using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PTSL.DgFood.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTSL.DgFood.Common.Const;
using PTSL.DgFood.Api.Helpers;
using PTSL.DgFood.DAL.UnitOfWork;
using Newtonsoft.Json;

namespace DgFood
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
            services.AddDbContext<DgFoodWriteOnlyCtx>(options =>
               options.UseSqlServer(Configuration.GetConnectionString(DbContextConst.ConnectionString),
                   b => b.MigrationsAssembly(typeof(Startup).Assembly.FullName)
               ), ServiceLifetime.Scoped
            );

            services.AddDbContext<DgFoodReadOnlyCtx>(options =>
               options.UseSqlServer(Configuration.GetConnectionString(DbContextConst.ConnectionString),
                   b => b.MigrationsAssembly(typeof(Startup).Assembly.FullName)
               ), ServiceLifetime.Scoped
            );

            //Register All Services
            services.AddScoped(serviceType: typeof(DgFoodUnitOfWork), implementationType: typeof(DgFoodUnitOfWork));
            services.AddDependecyResolver();
            services.AddSession();
            services.AddHttpClient();

            //Register Automaper
            ConfigureAutoMapper(services);

            // Register the Swagger generator, defining 1 or more Swagger documents
            SetupwaggerGenServices(services);

            //jwt Token
            SetupJWTServices(services);

            //services.AddControllers();
            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddMvc().AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            //services.AddMvc().AddNewtonsoftJson(o =>
            //{
            //    o.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //    o.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            //    o.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            //    // ^^ IMPORTANT PART ^^
            //}).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
        private void SetupwaggerGenServices(IServiceCollection services)
        {
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo
            //    {
            //        Version = "v1",
            //        Title = "Prime DgFood API",
            //        Description = "Prime DgFood API using .net core",
            //        TermsOfService = new Uri("http://primetechbd.com"),
            //        Contact = new OpenApiContact
            //        {
            //            Name = "Primetech Solution Ltd",
            //            Email = "info@primetechbd.com",
            //            Url = new Uri("http://primetechbd.com"),
            //        }
            //    });

            //    //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //    //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            //    //c.IncludeXmlComments(xmlPath);
            //});
            services.AddSwaggerGenNewtonsoftSupport();
            services.AddSwaggerGen(c =>
            {
                
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Prime DgFood API",
                    Description = "Prime DgFood API using .net core",
                    TermsOfService = new Uri("http://primetechbd.com"),
                    Contact = new OpenApiContact
                    {
                        Name = "Primetech Solution Ltd",
                        Email = "info@primetechbd.com",
                        Url = new Uri("http://primetechbd.com"),
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

                c.SchemaFilter<SwaggerExcludeFilter>();

            });
        }
        private void SetupJWTServices(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "bearer";
                options.DefaultChallengeScheme = "bearer";
            }).AddJwtBearer("bearer", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };

                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });
        }
        private static void ConfigureAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            //MapperConfiguration mapperConfiguration = new MapperConfiguration(config =>
            //{
            //    config.AddProfile<AutoMapperProfile>();
            //});

            //mapperConfiguration.CreateMapper();

            //services.AddSingleton(mapperConfiguration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSession();
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DefaultModelExpandDepth(2);
                c.DefaultModelsExpandDepth(-1);
                c.DisplayOperationId();
                c.DisplayRequestDuration();
                c.EnableDeepLinking();
                c.EnableFilter();
                c.ShowExtensions();
                c.EnableValidator();
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Prime DgFood API V1");
            });

            // global cors policy
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
