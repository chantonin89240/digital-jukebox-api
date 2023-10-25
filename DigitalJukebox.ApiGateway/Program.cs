using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("ocelot.json", optional: false);

builder.Services.AddOcelot();
builder.Services.AddCors();
builder.Services.AddMvc();


var app = builder.Build();

app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


app.UseOcelot();

app.Run();