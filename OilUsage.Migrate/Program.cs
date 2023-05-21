// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;
using Microsoft.EntityFrameworkCore;
using OilUsage.Data;

var table = "OilUsage";
var context = new OildbContext();
//var credentials = new BasicAWSCredentials(accessKey, secretKey);
var dynamoDb = new AmazonDynamoDBClient();

context.Oils.ToList().ForEach(async oil =>
{
    var ojson = JsonSerializer.Serialize(oil);
    var attrmap = Document.FromJson(ojson).ToAttributeMap();
    var createRequest = new PutItemRequest
    {
        TableName = table,
        Item = attrmap
    };

    await dynamoDb.PutItemAsync(createRequest);
    //Console.WriteLine($"{oil.Name} - {oil.OilGuid }");
});

context.Issues.ToList().ForEach(async issue =>
{
    var ojson = JsonSerializer.Serialize(issue);
    var attrmap = Document.FromJson(ojson).ToAttributeMap();
    var createRequest = new PutItemRequest
    {
        TableName = table,
        Item = attrmap
    };

    await dynamoDb.PutItemAsync(createRequest);
    //Console.WriteLine($"{issue.Name} - {issue.IssueGuid}");
});

context.Usages
    .Include(u => u.Issue)
    .Include(u => u.Oil)
    .ToList()
    .ForEach(async usage =>
{
    var ojson = JsonSerializer.Serialize(usage);
    var attrmap = Document.FromJson(ojson).ToAttributeMap();
    var createRequest = new PutItemRequest
    {
        TableName = table,
        Item = attrmap
    };

    await dynamoDb.PutItemAsync(createRequest);
    //Console.WriteLine($"{issue.Name} - {issue.IssueGuid}");
});
Console.ReadLine();

