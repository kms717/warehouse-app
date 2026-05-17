using Microsoft.EntityFrameworkCore;
using WarehouseApp.Components;
using WarehouseApp.Data;
using WarehouseApp.Services;

namespace WarehouseApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IProductService, ProductService>();

            builder.Services.AddScoped<ISaleService, SaleService>();
            
            builder.Services.AddScoped<ISaleService, SaleService>();

            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                await db.Database.MigrateAsync();
            }

            app.Run();
        }
    }
}