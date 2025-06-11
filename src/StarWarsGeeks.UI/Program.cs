using MudBlazor.Services;
using StarWarsGeeks.UI.Components;
using StarWarsGeeks.UI.Service;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddHttpClient("StarWarsClient",
    client =>
    {
        client.BaseAddress = new Uri("https://localhost:7120/api/StarWars/");
        client.DefaultRequestHeaders.Add("Accept", "application/json");
    });

// Add MudBlazor services
builder.Services.AddMudServices();

builder.Services.AddScoped<StarWarsService>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    _ = app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    _ = app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
