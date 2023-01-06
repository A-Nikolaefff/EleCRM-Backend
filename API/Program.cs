using System.Text.Json.Serialization;
using Application;
using Application.Services;
using Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddJsonOptions(options => 
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddDateOnlyTimeOnlyStringConverters();
builder.Services.AddSwaggerGen(c => c.UseDateOnlyTimeOnlyStringConverters());
builder.Services.AddDbContext<EleCrmContext>();
builder.Services.AddCustomServices();
builder.Services.AddAutoMapper(typeof(RequestMappingProfile));
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
app.MapFallbackToFile("index.html");

app.Run();