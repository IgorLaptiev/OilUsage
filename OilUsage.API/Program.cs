using Amazon;
using Amazon.DynamoDBv2;
using OilUsage.Data;
using OilUsage.Domain;
using Amazon.Lambda;
using OilUsage.Domain.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection(DatabaseSettings.KeyName));
builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);
// Add services to the container.
//builder.Services.AddSingleton<IAmazonDynamoDB>(_=> builder.Configuration.GetAWSOptions().CreateServiceClient<IAmazonDynamoDB>());
builder.Services.AddAWSService<IAmazonDynamoDB>();
//new AmazonDynamoDBClient(RegionEndpoint.USEast1)));
builder.Services.AddDbContext<OildbContext>();
builder.Services.AddTransient<IOilUsageService, OilUsageDynamoDbService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();

