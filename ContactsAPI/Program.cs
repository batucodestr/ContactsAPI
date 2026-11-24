using ContactsAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Servis kayıtları
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ContactsAPIDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();


// Swagger/OpenAPI yapılandırması
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();   // JSON tanımını üretir: /openapi/v1.json
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "ContactsAPI v1");
    });
}



// 2. İstek hattı (middleware)
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();