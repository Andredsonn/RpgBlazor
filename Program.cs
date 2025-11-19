using System;
using System.Net.Http;
using Blazored.LocalStorage;
using RpgBlazor.Components;
using RpgBlazor.Services;


var builder = WebApplication.CreateBuilder(args);

// configurar HttpClient com a base da API
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://rpgapids20252.azurewebsites.net/")
});

//inicialização da classe para uso em outras classes
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<PersonagemService>();
builder.Services.AddBlazoredLocalStorage();


builder.Services.AddRazorComponents()
.AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
