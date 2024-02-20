using Application;
using Persistence.ServiceRegistration;
using WebUI.Infrastructure.Routing;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddPersistenceServices(builder.Configuration.GetConnectionString("Mysql")!);
builder.Services.AddApplicationServices();
builder.Services.AddTransient<DynamicRouteHandler>();

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