using RazorPagesEventMaker.Interfaces;
using RazorPagesEventMaker.Services;

namespace EventMakerRazorPage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            //builder.Services.AddSingleton<IEventRepository, FakeEventRepository>();
            builder.Services.AddTransient<IEventRepository, JsonEventRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();    

            app.Run();
        }
    }
}
