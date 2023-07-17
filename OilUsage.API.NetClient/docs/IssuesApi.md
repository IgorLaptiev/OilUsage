# OilUsage.API.NetClient.Api.IssuesApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ApiIssuesGet**](IssuesApi.md#apiissuesget) | **GET** /api/Issues |  |
| [**ApiIssuesGetOilForBaseCareGet**](IssuesApi.md#apiissuesgetoilforbasecareget) | **GET** /api/Issues/GetOilForBaseCare |  |
| [**ApiIssuesGetOilForCareProductsGet**](IssuesApi.md#apiissuesgetoilforcareproductsget) | **GET** /api/Issues/GetOilForCareProducts |  |
| [**ApiIssuesGetOilForInternalUsageGet**](IssuesApi.md#apiissuesgetoilforinternalusageget) | **GET** /api/Issues/GetOilForInternalUsage |  |

<a id="apiissuesget"></a>
# **ApiIssuesGet**
> List&lt;IssueDto&gt; ApiIssuesGet ()



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using OilUsage.API.NetClient.Api;
using OilUsage.API.NetClient.Client;
using OilUsage.API.NetClient.Model;

namespace Example
{
    public class ApiIssuesGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: ApiKey
            config.AddApiKey("X-API-Key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("X-API-Key", "Bearer");

            var apiInstance = new IssuesApi(config);

            try
            {
                List<IssueDto> result = apiInstance.ApiIssuesGet();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IssuesApi.ApiIssuesGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiIssuesGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<List<IssueDto>> response = apiInstance.ApiIssuesGetWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling IssuesApi.ApiIssuesGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**List&lt;IssueDto&gt;**](IssueDto.md)

### Authorization

[ApiKey](../README.md#ApiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiissuesgetoilforbasecareget"></a>
# **ApiIssuesGetOilForBaseCareGet**
> List&lt;OilUsageDto&gt; ApiIssuesGetOilForBaseCareGet (List<string> issues = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using OilUsage.API.NetClient.Api;
using OilUsage.API.NetClient.Client;
using OilUsage.API.NetClient.Model;

namespace Example
{
    public class ApiIssuesGetOilForBaseCareGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: ApiKey
            config.AddApiKey("X-API-Key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("X-API-Key", "Bearer");

            var apiInstance = new IssuesApi(config);
            var issues = new List<string>(); // List<string> |  (optional) 

            try
            {
                List<OilUsageDto> result = apiInstance.ApiIssuesGetOilForBaseCareGet(issues);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IssuesApi.ApiIssuesGetOilForBaseCareGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiIssuesGetOilForBaseCareGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<List<OilUsageDto>> response = apiInstance.ApiIssuesGetOilForBaseCareGetWithHttpInfo(issues);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling IssuesApi.ApiIssuesGetOilForBaseCareGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **issues** | [**List&lt;string&gt;**](string.md) |  | [optional]  |

### Return type

[**List&lt;OilUsageDto&gt;**](OilUsageDto.md)

### Authorization

[ApiKey](../README.md#ApiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiissuesgetoilforcareproductsget"></a>
# **ApiIssuesGetOilForCareProductsGet**
> List&lt;OilUsageDto&gt; ApiIssuesGetOilForCareProductsGet (List<string> issues = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using OilUsage.API.NetClient.Api;
using OilUsage.API.NetClient.Client;
using OilUsage.API.NetClient.Model;

namespace Example
{
    public class ApiIssuesGetOilForCareProductsGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: ApiKey
            config.AddApiKey("X-API-Key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("X-API-Key", "Bearer");

            var apiInstance = new IssuesApi(config);
            var issues = new List<string>(); // List<string> |  (optional) 

            try
            {
                List<OilUsageDto> result = apiInstance.ApiIssuesGetOilForCareProductsGet(issues);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IssuesApi.ApiIssuesGetOilForCareProductsGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiIssuesGetOilForCareProductsGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<List<OilUsageDto>> response = apiInstance.ApiIssuesGetOilForCareProductsGetWithHttpInfo(issues);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling IssuesApi.ApiIssuesGetOilForCareProductsGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **issues** | [**List&lt;string&gt;**](string.md) |  | [optional]  |

### Return type

[**List&lt;OilUsageDto&gt;**](OilUsageDto.md)

### Authorization

[ApiKey](../README.md#ApiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiissuesgetoilforinternalusageget"></a>
# **ApiIssuesGetOilForInternalUsageGet**
> List&lt;OilUsageDto&gt; ApiIssuesGetOilForInternalUsageGet (List<string> issues = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using OilUsage.API.NetClient.Api;
using OilUsage.API.NetClient.Client;
using OilUsage.API.NetClient.Model;

namespace Example
{
    public class ApiIssuesGetOilForInternalUsageGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: ApiKey
            config.AddApiKey("X-API-Key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("X-API-Key", "Bearer");

            var apiInstance = new IssuesApi(config);
            var issues = new List<string>(); // List<string> |  (optional) 

            try
            {
                List<OilUsageDto> result = apiInstance.ApiIssuesGetOilForInternalUsageGet(issues);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling IssuesApi.ApiIssuesGetOilForInternalUsageGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiIssuesGetOilForInternalUsageGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<List<OilUsageDto>> response = apiInstance.ApiIssuesGetOilForInternalUsageGetWithHttpInfo(issues);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling IssuesApi.ApiIssuesGetOilForInternalUsageGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **issues** | [**List&lt;string&gt;**](string.md) |  | [optional]  |

### Return type

[**List&lt;OilUsageDto&gt;**](OilUsageDto.md)

### Authorization

[ApiKey](../README.md#ApiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

