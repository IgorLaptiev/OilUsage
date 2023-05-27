using System.Diagnostics;
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
        return await Query<IssueDto>(GetKeyAttributeValue<IssueDto>());
    }

    public async Task<List<OilDto>> GetOilsAsync()
    {
        return await Query<OilDto>(GetKeyAttributeValue<OilDto>());
    }


    private async Task<List<T>> Query<T>(AttributeValue? keyValue) where T : class
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
                        AttributeValueList = new List<AttributeValue?>() { keyValue }
                    }
                }
            },
        };
        var result = await _dbClient.QueryAsync(query);
        return result.Items
            .Select(issue =>
            {
                var issueSerialized = Document.FromAttributeMap(issue);
                return JsonSerializer.Deserialize<T>(issueSerialized.ToJson());
            })
            .Where(dto => dto != null)
            .ToList()!;
    }

    private static AttributeValue? GetKeyAttributeValue<T>(string value = "") where T : class
    {
        AttributeValue? attrValue = null;
        var t = typeof(T);
        if (t.IsAssignableTo(typeof(IssueDto)))
        {
            attrValue = new AttributeValue($"ISSUE#{value}");
        }
        else if (t.IsAssignableTo(typeof(OilDto)))
        {
            attrValue = new AttributeValue($"OIL#{value}");
        }

        return attrValue;
    }

    public Task<List<OilUsageDto>> GetOilByIssue(UsageType type, string[] issues)
    {
        var issueKeys = issues.Select(i => GetKeyAttributeValue<IssueDto>(i)).ToList();

    }

    private async Task<List<T>> GetUsageQuery<T>(List<AttributeValue> keys) where T : class
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
                        AttributeValueList = keys
                    }
                },
                {
                    "SK",
                    new Condition()
                    {
                        ComparisonOperator = ComparisonOperator.BEGINS_WITH,
                        AttributeValueList = new List<AttributeValue?>() { GetKeyAttributeValue<OilDto>() }
                    }
                }
            },
        };
        var result = await _dbClient.QueryAsync(query);
        return result.Items
            .Select(issue =>
            {
                var issueSerialized = Document.FromAttributeMap(issue);
                return JsonSerializer.Deserialize<T>(issueSerialized.ToJson());
            })
            .Where(dto => dto != null)
            .ToList()!;
    }
}