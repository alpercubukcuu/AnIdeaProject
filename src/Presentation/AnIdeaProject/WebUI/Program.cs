using Application;
using Infrastructure.Model;
using Persistence.ServiceRegistration;
using WebUI.Infrastructure.Routing;
using WebUI.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddPersistenceServices(builder.Configuration.GetConnectionString("Mysql")!);
builder.Services.AddApplicationServices();
builder.Services.AddTransient<DynamicRouteHandler>();
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("ConnectionStrings"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); 
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDynamicControllerRoute<DynamicRouteHandler>("{**slug}");
    
});


app.Run();