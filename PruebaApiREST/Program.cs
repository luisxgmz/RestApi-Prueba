using Microsoft.EntityFrameworkCore;
using PruebaApiREST.Models;
using PruebaApiREST.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TodoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion")));
    //options.UseSqlServer(Configuration.GetConnectionString("Conexion")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepository, Repository<TodoContext>>();

//builder.Services.AddTransient(typeof(IRepository<>),typeof(Repository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseEndpoints(endpoints =>
{
endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
});



app.UseDefaultFiles();
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
