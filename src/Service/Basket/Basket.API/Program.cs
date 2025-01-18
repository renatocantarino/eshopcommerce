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
    opts.Schema.For<ShoppingCart>().Identity(x => x.Document);
}).UseLightweightSessions();

builder.Services.AddOpenApi();

builder.Services.AddHealthChecks()
        .AddNpgSql(builder.Configuration.GetConnectionString("dataBase")!);

var app = builder.Build();

app.MapOpenApi();
app.UseSwaggerUI(opts => opts.SwaggerEndpoint("/openapi/v1.json", "basket api"));
app.MapCarter();

app.UseExceptionHandler(opts => { });
app.UseHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();