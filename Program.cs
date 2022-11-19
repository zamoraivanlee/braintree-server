using Braintree.Services;
using BraintreeServer.Configurations;
using BraintreeServer.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new HttpExceptionFilter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<BraintreeConfiguration>(builder.Configuration.GetSection("Braintree"));
builder.Services.Configure<TestConfiguration>(builder.Configuration.GetSection("Test"));

builder.Services.AddScoped<IBraintreeService, BraintreeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(policy =>
{
    var configuration = builder.Configuration.GetSection("Cors").Get<CorsConfiguration>();

    if (configuration?.AllowedHeaders != null) policy.WithHeaders(configuration.AllowedHeaders);
    if (configuration?.AllowedMethods != null) policy.WithMethods(configuration.AllowedMethods);
    if (configuration?.AllowedOrigins != null) policy.WithOrigins(configuration.AllowedOrigins);
});

app.Run();
