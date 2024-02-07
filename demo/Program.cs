using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using demo.Data;
using demo;
using DataLayer;
using demo.Features.Home;
using DataLayer.Cards;
using DataLayer.Watches;
using DataLayer.Utilizador;
using DataLayer.Leilao;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Authorization;
using BlazorServerAutheticationAndAuthorization.Authetication;
using DataLayer.Licitacao;
using DataLayer.LeilaoFavorito;
using DataLayer.Notificacao;
using demo.Features.Notificacoes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthenticationCore();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAutheticationStateProvider>();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddHttpClient();
builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddTransient<ICardRepository, CardRepository>();
builder.Services.AddTransient<IWatchRepository, WatchRepository>();
builder.Services.AddTransient<ILeilaoRepository, LeilaoRepository>();
builder.Services.AddTransient<IUtilizadorRepository, UtilizadorRepository>();
builder.Services.AddTransient<ILeilaoRepository, LeilaoRepository>();
builder.Services.AddTransient<ILicitacaoRepository, LicitacaoRepository>();
builder.Services.AddTransient<ILeilaoFavoritoRepository, LeilaoFavoritoRepository>();
builder.Services.AddTransient<INotificacaoRepository, NotificacaoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
