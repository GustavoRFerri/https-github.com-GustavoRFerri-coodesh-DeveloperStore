
using DeveloperStore.src.repositories;
using DeveloperStore.src.service;
using DeveloperStore.src.service.@interface;

namespace DeveloperStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<IDiscountService,DiscountService>();
            builder.Services.AddScoped<IDataBaseSale,DataBaseSale>();
            builder.Services.AddScoped<ISearchProductService, SearchProductService>();
            builder.Services.AddScoped<IQuantityProductService,QuantityProductService>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
