using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using PaymentAPI.Domain.Interfaces.Repositorys;
using PaymentAPI.Infrastructure.Context;
using PaymentAPI.Infrastructure.Repositorys;

namespace PaymentAPI.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();

            builder.Services.AddDbContext<PaymentAPIContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("Default"),
                                  b => b.MigrationsAssembly("PaymentAPI.API"));
            });

            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseAuthorization();

            app.MapControllers();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.Run();
        }
    }
}
