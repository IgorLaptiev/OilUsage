using Amazon;
using Amazon.DynamoDBv2;
using OilUsage.Data;
using OilUsage.Domain;
using Amazon.Lambda;
using Amazon.Runtime;
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;
using Microsoft.OpenApi.Models;
using OilUsage.API.Authorization;
using OilUsage.API.Settings;
using OilUsage.Domain.Settings;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration
    .AddSystemsManager(source =>
        {
            source.Path = "/oilUsage";
            source.Optional = true;
            source.ReloadAfter = TimeSpan.FromSeconds(30);
            source.AwsOptions = new Amazon.Extensions.NETCore.Setup.AWSOptions()
            {
                Region = RegionEndpoint.USEast1,
            };   
        });

builder.Logging.AddLambdaLogger(new LambdaLoggerOptions(builder.Configuration));
builder.Services.AddHealthChecks();
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection(DatabaseSettings.KeyName));
builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection(ApiSettings.KeyName));
builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);
// Add services to the container.
builder.Services.AddAWSService<IAmazonDynamoDB>();
builder.Services.AddDbContext<OildbContext>();
builder.Services.AddTransient<IOilUsageService, OilUsageDynamoDbService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition(
        "ApiKey",
        new OpenApiSecurityScheme()
        {
            Description = "ApiKey must appear in header",
            Type = SecuritySchemeType.ApiKey,
            Name = ApiKeyAuthorizationFilter.ApiKeyHeaderName,
            In = ParameterLocation.Header,
            Scheme = "ApiKeyScheme"
        });
    var key = new OpenApiSecurityScheme()
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "ApiKey"
        },
        In = ParameterLocation.Header
    };
    var requirement = new OpenApiSecurityRequirement
    {
        { key, new List<string>() }
    };
    options.AddSecurityRequirement(requirement);
});

builder.Services.AddSingleton<ApiKeyAuthorizationFilter>();
builder.Services.AddSingleton<IApiKeyValidator, ApiKeyValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapHealthChecks("/healthcheck");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

