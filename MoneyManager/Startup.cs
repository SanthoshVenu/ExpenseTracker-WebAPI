using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
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
using MoneyManager.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MoneyManager.DAL.Contracts;
using MoneyManager.DAL.Repositories;
using MoneyManager.BAL.ViewModels;
using MoneyManager.BAL.Interfaces;
using MoneyManager.BAL.BuisnessLogic;
using MoneyManager.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using System.IO;

namespace MoneyManager
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
            
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var key = "This is my custom Secret key for authnetication";

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            var ConnectionString = Configuration.GetConnectionString("MbkDbConstr");
            services.AddDbContext<MONEYMANAGERContext>(options =>
                options.UseSqlServer(ConnectionString));
            services.AddTransient<IRepository<ExpenseTrackerModel>,RepositoryMoneyManager<ExpenseTrackerModel>>();
            services.AddTransient<IExpenseTrackerBuisnessLogic, ExpenseTrackerBuisnessLogic>();
            services.AddMemoryCache();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(typeof(Startup));
            //var mapperConfig = new MapperConfiguration(mc => {
            //    mc.AddProfile(new MappingProfile());
            //});
            //IMapper mapper = mapperConfig.CreateMapper();
            //services.AddSingleton(mapper);



            // Adding Routing Middleware
             services.AddRouting();
            services.AddMvc();
            services.AddControllers();
            services.Configure<RouteOptions>(option => option.ConstraintMap.Add("weather", typeof(DomainConstraint)));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MoneyManager", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MoneyManager v1"));
            }
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseAuthentication();

            //app.UseRouter(new RouteHandler(
            //    context => context.Response.WriteAsync("Hello!!! This is Santhosh")));

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
