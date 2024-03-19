using Lido.Lifestyle.Web.Components;
using Lido.Lifestyle.Application.Common;
using Lido.Lifestyle.Application.UseCases.Session.Commands;
using Lido.Lifestyle.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateSessionCommandHandler).Assembly));
builder.Services.AddDbContext<LidoLifestyleDbContext>();
builder.Services.AddScoped<ILidoLifestyleDbContext>(provider => provider.GetRequiredService<LidoLifestyleDbContext>());

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
