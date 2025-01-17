using FluentValidation;
using Kernel.Behaviors;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();

var _assembly = typeof(Program).Assembly;

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(_assembly);
    cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(_assembly);

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("dataBase")!);
}).UseLightweightSessions();

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();
app.UseSwaggerUI(opts => opts.SwaggerEndpoint("/openapi/v1.json", "products apis"));

app.MapCarter();

app.Run();