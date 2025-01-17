using FluentValidation;
using Kernel.Behaviors;
using Kernel.Exceptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();

var _assembly = typeof(Program).Assembly;

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(_assembly);
    cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
    cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(_assembly);

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("dataBase")!);
}).UseLightweightSessions();

builder.Services.AddOpenApi();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();

app.MapOpenApi();
app.UseSwaggerUI(opts => opts.SwaggerEndpoint("/openapi/v1.json", "products apis"));

app.MapCarter();
app.UseExceptionHandler(opts => { });

app.Run();