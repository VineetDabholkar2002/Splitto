using backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // URL of your React app
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddSingleton<MongoDbService>();
builder.Services.AddControllers();
var app = builder.Build();

// Enable CORS
app.UseCors("AllowReactApp");

app.MapControllers();

app.Run();
