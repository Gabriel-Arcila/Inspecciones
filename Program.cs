using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using Blazored.LocalStorage;
using Inspecciones.Data;
using Inspecciones.Services;
using Inspecciones.Model;
using Radzen;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents()
    .AddInteractiveServerComponents();


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<Radzen.ThemeService>();

builder.Services.AddScoped<IEmailServices,EmailServices>();


builder.Services.AddBlazoredLocalStorage();

builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();
builder.Services.AddOptions();  
builder.Services.AddAuthorizationCore();



builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<DialogService>();

builder.Services.AddDbContext<DbNeoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDbNeo")),ServiceLifetime.Transient
);

builder.Services.AddScoped<IDataInspeccion,DataInspeccion>();
builder.Services.AddScoped<IDataPregunta,DataPregunta>();
builder.Services.AddScoped<IDataMaquina,DataMaquina>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// builder.Services.AddDbContext<DbNeoContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDbNeo")),ServiceLifetime.Transient
// );

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
