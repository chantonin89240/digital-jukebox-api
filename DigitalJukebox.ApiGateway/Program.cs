using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("ocelot.json", optional: false);

builder.Services.AddOcelot();
//builder.Services.AddCors(option => { option.AddPolicy("policyCors", builder => { builder.WithOrigins("http://digitaljukeboxg2.reseau-labo.fr").AllowAnyHeader().AllowAnyMethod(); }); });
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:3000", "http://digitaljukeboxg2.reseau-labo.fr/") // Spécifiez les domaines autorisés
                  .AllowAnyHeader()
                  .AllowCredentials()
                  .AllowAnyMethod();
        });
});
builder.Services.AddMvc();


var app = builder.Build();

app.UseCors();
//app.UseRouting();


app.UseOcelot();

app.Run();