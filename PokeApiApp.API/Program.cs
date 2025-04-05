using PokeApiApp.Application.Service;
using PokeApiApp.Infrastructure.Client;
using PokeApiApp.Infrastructure.Repository;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// Registra la implementación concreta `PokemonRepository` como servicio para la interfaz `IPokemonRepository`.
builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
builder.Services.AddScoped<PokemonService>();

// Registra un cliente HTTP Refit para la interfaz `IPokeApiClient`
builder.Services.AddRefitClient<IPokeApiClient>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://pokeapi.co/api/v2/"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(c =>
    {
        // apuntas al path correcto
        c.SwaggerEndpoint("/openapi/v1.json", "PokeApiApp v1");
        c.RoutePrefix = "swaggerPokeApi"; 
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
