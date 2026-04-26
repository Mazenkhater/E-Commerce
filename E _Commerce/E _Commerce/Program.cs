
using E__Commerce.DataBase;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using E_Commerce.Core.Interfaces.Base;
using E_Commerce.Core.Models;
using E__Commerce.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace E__Commerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = "Enter JWT Token like this: Bearer your_token"
                });

                options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
            });
            builder.Services.AddDbContext<DataContext>(Options => { Options.UseSqlServer(builder.Configuration.GetConnectionString("DB")); });
            builder.Services.AddIdentity<AppUser,IdentityRole>().AddEntityFrameworkStores<DataContext>();
            builder.Services.AddScoped(typeof(IRepository<>),typeof(MainRepository<>));
            //builder.Services.AddScoped<ICategoryRepository ,  CategoryRepository>();
            //builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            //builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            //builder.Services.AddScoped<IProductRepository, ProductRepository>();

            //[Authoriz] used jwt token in check Authentication
            var Configuration = builder.Configuration;
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = Configuration["JWT : validissuer"],
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT :validaudience "],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["jWT:secret"]))

                };

            });
            builder.Services.AddCors(CorsOptions => {
                CorsOptions.AddPolicy("MyPolicy", CorsPolicyBuilder =>
                {
                    CorsPolicyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
                });
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddMemoryCache();
            builder.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = builder.Configuration.GetConnectionString("Redis");
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("MyPolicy");

            app.UseAuthentication();  //check jwt token

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
