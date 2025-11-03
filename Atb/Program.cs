using Atb.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//підключення до бази даних PostgreSQL
builder.Services.AddDbContext<MyAppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers();

//налаштування CORS для дозволу запитів з фронтенду на реакті
//який працює на http://localhost:5062
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5062")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

var dirPath = app.Configuration.GetValue<string>("DirPath") ?? "images";
var fullDirPath = Path.Combine(Directory.GetCurrentDirectory(), dirPath);
Directory.CreateDirectory(fullDirPath);
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(fullDirPath),
    RequestPath = $"/{dirPath}"
});

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
