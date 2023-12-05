using GeoTaggr.Data.Sqlite.Migrations;
using GeoTaggr.Infrastructure;
using GeoTaggr.Web.Common;
using GeoTaggr.Web.Components;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

IServiceCollection services = builder.Services;

// Add services to the container.
services
    .AddRazorComponents()
    .AddInteractiveServerComponents();

services.AddMudServices();

IDependencyContainer container = new DependencyContainer(services);
DependencyConfig.RegisterDependencies(container, builder.Configuration);

var app = builder.Build();

// run database migrations, and create new if necessary
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<MigrationsContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
