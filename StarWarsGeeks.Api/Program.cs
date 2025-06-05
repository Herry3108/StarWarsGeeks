WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient("StarWarsClient",
    client =>
    {
        client.BaseAddress = new Uri("https://swapi.info/api/");
        client.DefaultRequestHeaders.Add("Accept", "application/json");
    });

builder.Services.AddBusinessServices();

IConfiguration configuration = builder.Configuration;
builder.Services.AddDatabaseRepositories(configuration);

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
