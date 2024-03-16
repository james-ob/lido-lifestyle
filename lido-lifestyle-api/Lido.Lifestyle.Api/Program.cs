using Lido.Lifestyle.Application.Common;
using Lido.Lifestyle.Application.UseCases.Session.Commands;
using Lido.Lifestyle.Infrastructure.Data;
using System.Text.Json.Serialization;

Console.WriteLine("starting up");
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateSessionCommandHandler).Assembly));
builder.Services.AddDbContext<LidoLifestyleDbContext>();
builder.Services.AddScoped<ILidoLifestyleDbContext>(provider => provider.GetRequiredService<LidoLifestyleDbContext>());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
app.Run();
