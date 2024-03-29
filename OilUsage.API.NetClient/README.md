# OilUsage.API.NetClient - the C# library for the OilUsage.API

No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)

This C# SDK is automatically generated by the [OpenAPI Generator](https://openapi-generator.tech) project:

- API version: 1.0
- SDK version: 1.0.0
- Build package: org.openapitools.codegen.languages.CSharpNetCoreClientCodegen

<a id="frameworks-supported"></a>
## Frameworks supported
- .NET Core >=1.0
- .NET Framework >=4.6
- Mono/Xamarin >=vNext

<a id="dependencies"></a>
## Dependencies

- [RestSharp](https://www.nuget.org/packages/RestSharp) - 106.13.0 or later
- [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json/) - 13.0.2 or later
- [JsonSubTypes](https://www.nuget.org/packages/JsonSubTypes/) - 1.8.0 or later
- [System.ComponentModel.Annotations](https://www.nuget.org/packages/System.ComponentModel.Annotations) - 5.0.0 or later

The DLLs included in the package may not be the latest version. We recommend using [NuGet](https://docs.nuget.org/consume/installing-nuget) to obtain the latest version of the packages:
```
Install-Package RestSharp
Install-Package Newtonsoft.Json
Install-Package JsonSubTypes
Install-Package System.ComponentModel.Annotations
```

NOTE: RestSharp versions greater than 105.1.0 have a bug which causes file uploads to fail. See [RestSharp#742](https://github.com/restsharp/RestSharp/issues/742).
NOTE: RestSharp for .Net Core creates a new socket for each api call, which can lead to a socket exhaustion problem. See [RestSharp#1406](https://github.com/restsharp/RestSharp/issues/1406).

<a id="installation"></a>
## Installation
Generate the DLL using your preferred tool (e.g. `dotnet build`)

Then include the DLL (under the `bin` folder) in the C# project, and use the namespaces:
```csharp
using OilUsage.API.NetClient.Api;
using OilUsage.API.NetClient.Client;
using OilUsage.API.NetClient.Model;
```
<a id="usage"></a>
## Usage

To use the API client with a HTTP proxy, setup a `System.Net.WebProxy`
```csharp
Configuration c = new Configuration();
System.Net.WebProxy webProxy = new System.Net.WebProxy("http://myProxyUrl:80/");
webProxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
c.Proxy = webProxy;
```

<a id="getting-started"></a>
## Getting Started

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using OilUsage.API.NetClient.Api;
using OilUsage.API.NetClient.Client;
using OilUsage.API.NetClient.Model;

namespace Example
{
    public class Example
    {
        public static void Main()
        {

            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: ApiKey
            config.ApiKey.Add("X-API-Key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.ApiKeyPrefix.Add("X-API-Key", "Bearer");

            var apiInstance = new IssuesApi(config);

            try
            {
                List<IssueDto> result = apiInstance.ApiIssuesGet();
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling IssuesApi.ApiIssuesGet: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }

        }
    }
}
```

<a id="documentation-for-api-endpoints"></a>
## Documentation for API Endpoints

All URIs are relative to *http://localhost*

Class | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------
*IssuesApi* | [**ApiIssuesGet**](docs\IssuesApi.md#apiissuesget) | **GET** /api/Issues | 
*IssuesApi* | [**ApiIssuesGetOilForBaseCareGet**](docs\IssuesApi.md#apiissuesgetoilforbasecareget) | **GET** /api/Issues/GetOilForBaseCare | 
*IssuesApi* | [**ApiIssuesGetOilForCareProductsGet**](docs\IssuesApi.md#apiissuesgetoilforcareproductsget) | **GET** /api/Issues/GetOilForCareProducts | 
*IssuesApi* | [**ApiIssuesGetOilForInternalUsageGet**](docs\IssuesApi.md#apiissuesgetoilforinternalusageget) | **GET** /api/Issues/GetOilForInternalUsage | 
*OilsApi* | [**ApiOilsGet**](docs\OilsApi.md#apioilsget) | **GET** /api/Oils | 
*OilsApi* | [**ApiOilsIdDelete**](docs\OilsApi.md#apioilsiddelete) | **DELETE** /api/Oils/{id} | 
*OilsApi* | [**ApiOilsIdGet**](docs\OilsApi.md#apioilsidget) | **GET** /api/Oils/{id} | 
*OilsApi* | [**ApiOilsIdPut**](docs\OilsApi.md#apioilsidput) | **PUT** /api/Oils/{id} | 
*OilsApi* | [**ApiOilsPost**](docs\OilsApi.md#apioilspost) | **POST** /api/Oils | 


<a id="documentation-for-models"></a>
## Documentation for Models

 - [Model.IssueDto](docs\IssueDto.md)
 - [Model.OilDto](docs\OilDto.md)
 - [Model.OilUsageDto](docs\OilUsageDto.md)


<a id="documentation-for-authorization"></a>
## Documentation for Authorization


Authentication schemes defined for the API:
<a id="ApiKey"></a>
### ApiKey

- **Type**: API key
- **API key parameter name**: X-API-Key
- **Location**: HTTP header

