// See https://aka.ms/new-console-template for more information

using System.Collections.Concurrent;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.Configuration;
using OilUsage.API.NetClient.Api;
using OilUsage.API.NetClient.Client;

Console.OutputEncoding = Encoding.Unicode;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
    .Build();

var section = configuration.GetSection("OilUsageAPI");
var config = new Configuration();
config.BasePath = section["BasePath"];
config.ApiKey.Add("X-API-Key", section["ApiKey"]);

var api = new IssuesApi(config);
var issues = await api.ApiIssuesGetAsync();
issues?.ForEach(issue => Console.WriteLine(issue.Name));
Console.ReadLine();