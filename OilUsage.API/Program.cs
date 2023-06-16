using Amazon;
using Amazon.DynamoDBv2;
using OilUsage.Data;
using OilUsage.Domain;
using Amazon.Lambda;
using OilUsage.Domain.Settings;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddLambdaLogger(new LambdaLoggerOptions(builder.Configuration));
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection(DatabaseSettings.KeyName));
builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);
// Add services to the container.
builder.Services.AddAWSService<IAmazonDynamoDB>();
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

