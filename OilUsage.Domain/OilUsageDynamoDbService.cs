using System.Text.Json;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Microsoft.Extensions.Options;
using OilUsage.Domain.Models;
using OilUsage.Domain.Settings;

namespace OilUsage.Domain;

public class OilUsageDynamoDbService : IOilUsageService
{
    private readonly IAmazonDynamoDB _dbClient;
    private readonly IOptions<DatabaseSettings> _databaseSettings;

    public OilUsageDynamoDbService(IAmazonDynamoDB dbClient, IOptions<DatabaseSettings> databaseSettings)
    {
        _dbClient = dbClient;
        _databaseSettings = databaseSettings;
    }
    
    public async Task<List<IssueDto>> GetIssuesAsync()
    {
        var query = new QueryRequest()
        {
            TableName = _databaseSettings.Value.TableName,
            KeyConditions = new Dictionary<string, Condition>()
            {
                {
                    "PK",
                    new Condition()
                    {
                        ComparisonOperator = ComparisonOperator.EQ,
                        AttributeValueList = new List<AttributeValue>() { new("ISSUE#") }
                    }
                }
            },
        };
        var result = await _dbClient.QueryAsync(query);
        return result.Items
            .Select(issue =>
                {
                    var issueSerialized = Document.FromAttributeMap(issue);
                    return JsonSerializer.Deserialize<IssueDto>(issueSerialized.ToJson());
                })
            .Where(dto => dto !=null)
            .ToList()!;
    }

    public Task<List<OilDto>> GetOilsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<OilUsageDto>> GetOilByIssue(UsageType type, string[] issues)
    {
        throw new NotImplementedException();
    }
}