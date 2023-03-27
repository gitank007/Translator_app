using hunderan_app.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var conn = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApiDbContext>(options =>
options.UseNpgsql(conn));

builder.Services.AddControllers();


var AllowSpecificOrgins = "_allowSpecificOrgins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowSpecificOrgins,
        policy =>
        {
            policy.WithOrigins("http://localhost:5177")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin()
            .AllowAnyHeader();
        }

        );
});
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

app.UseCors(AllowSpecificOrgins);

app.Run();

