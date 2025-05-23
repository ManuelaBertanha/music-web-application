using System.Reflection;
using music_web_application.Authorization;
using music_web_application.Services;
using music_web_application.Services.Interfaces;

namespace music_web_application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthentication()
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Unauthorized/";
                    options.AccessDeniedPath = "/Account/Forbidden/";
                })
                .AddJwtBearer(options =>
                {
                    options.Audience = "http://localhost:5001/";
                    options.Authority = "http://localhost:5000/";
                });

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            builder.Services.AddAuthorization();
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            
            builder.Services.AddHttpClient<SpotifyAuthService>();
            builder.Services.AddSingleton<SpotifyAuthService>();
            
            builder.Services.AddScoped<IAlbumHandlingService, AlbumHandlingService>();
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
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
