using GeoTaggr.Infrastructure;
using GeoTaggr.Web.Common;
using GeoTaggr.Web.Components;

var builder = WebApplication.CreateBuilder(args);

IServiceCollection services = builder.Services;

// Add services to the container.
services
    .AddRazorComponents()
    .AddInteractiveServerComponents();

IDependencyContainer container = new DependencyContainer(services);
DependencyConfig.RegisterDependencies(container, builder.Configuration);

var app = builder.Build();

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
