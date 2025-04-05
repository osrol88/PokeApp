using Microsoft.EntityFrameworkCore;
using PokeApiApp.Application.Service;
using PokeApiApp.Infrastructure;
using PokeApiApp.Infrastructure.Client;
using PokeApiApp.Infrastructure.Repository;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
// Registra la implementación concreta `PokemonRepository` como servicio para la interfaz `IPokemonRepository`.
builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
builder.Services.AddScoped<PokemonService>();

builder.Services.AddRefitClient<IPokeApiClient>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://pokeapi.co/api/v2/"));

builder.Services.AddDbContext<PokemonDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("pokeConn")));


var app = builder.Build();

// Esto crea la BD y las tablas si no existen
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<PokemonDbContext>();
    dbContext.Database.EnsureCreated(); 
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
