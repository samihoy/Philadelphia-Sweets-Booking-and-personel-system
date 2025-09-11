
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Philadelphia_Sweets_booking_System__Resturant_.Data;
using Philadelphia_Sweets_booking_System__Resturant_.Repositorys;
using Philadelphia_Sweets_booking_System__Resturant_.Repositorys.IRepository;
using Philadelphia_Sweets_booking_System__Resturant_.Repositorys.IRepositorys;
using Philadelphia_Sweets_booking_System__Resturant_.Services;
using Philadelphia_Sweets_booking_System__Resturant_.Services.IServices;
using System.Security.AccessControl;
using System.Text;

namespace Philadelphia_Sweets_booking_System__Resturant_
{
    public class Program
    {
        public static void Main(string[] args)
        {



            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<PhiladelphiaSweetsResturandDBContext>(options =>
            {
                options.UseSqlServer((builder.Configuration.GetConnectionString("DefaultConnection")));
            });

            builder.Services.AddScoped<ITableRepository, TableRepository>();
            builder.Services.AddScoped<ITableServices, TableServices>();
            builder.Services.AddScoped<IBookingRepository, BookingRepository>();
            builder.Services.AddScoped<IBookingService,BookingServices>();
            builder.Services.AddScoped<IMenuRepository,MenuRepository>();
            builder.Services.AddScoped<IMenuServices, MenuServices>();
            builder.Services.AddScoped<IDishRepository, DishRepository>();
            builder.Services.AddScoped<IDishServices,DishServices>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience =true,
                        ValidateLifetime=true,
                        ValidateIssuerSigningKey=true,
                        ValidIssuer= builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };

                });
            builder.Services.AddAuthorization();

            builder.Services.AddHttpClient<DishApiHttpServices>(client =>
            {
                client.BaseAddress = new Uri("https://www.themealdb.com/");
            });



            var app = builder.Build();


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();


            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();


            app.Run();
           
        
    
            
        }

    }
}
