using System.Text.Json.Serialization;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddJsonOptions(x => 
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddSwaggerGen();
builder.Host.UseSerilog((hostingContext, configuration) => 
    configuration.ReadFrom.Configuration(hostingContext.Configuration));

var app = builder.Build();

app.UseSerilogRequestLogging();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "EleCRM API v. 0.0.0");
});

app.UseDefaultFiles();
app.UseStaticFiles();
app.MapControllers();

app.Run();