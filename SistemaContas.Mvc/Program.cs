using SistemaContas.Data.Repositories;
using SistemaContas.Domain.Interfaces.Reports;
using SistemaContas.Domain.Interfaces.Repositories;
using SistemaContas.Domain.Interfaces.Services;
using SistemaContas.Domain.Services;
using SistemaContas.Infra.Reports;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IContaDomainService, ContaDomainService>();
builder.Services.AddTransient<IContaRepository, ContaRepository>();
builder.Services.AddTransient<IContaReport, ContaReport>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Contas}/{action=Dashboard}/{id?}");

app.Run();
