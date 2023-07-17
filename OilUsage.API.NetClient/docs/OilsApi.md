# OilUsage.API.NetClient.Api.OilsApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ApiOilsGet**](OilsApi.md#apioilsget) | **GET** /api/Oils |  |
| [**ApiOilsIdDelete**](OilsApi.md#apioilsiddelete) | **DELETE** /api/Oils/{id} |  |
| [**ApiOilsIdGet**](OilsApi.md#apioilsidget) | **GET** /api/Oils/{id} |  |
| [**ApiOilsIdPut**](OilsApi.md#apioilsidput) | **PUT** /api/Oils/{id} |  |
| [**ApiOilsPost**](OilsApi.md#apioilspost) | **POST** /api/Oils |  |

<a id="apioilsget"></a>
# **ApiOilsGet**
> List&lt;OilDto&gt; ApiOilsGet ()



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using OilUsage.API.NetClient.Api;
using OilUsage.API.NetClient.Client;
using OilUsage.API.NetClient.Model;

namespace Example
{
    public class ApiOilsGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: ApiKey
            config.AddApiKey("X-API-Key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("X-API-Key", "Bearer");

            var apiInstance = new OilsApi(config);

            try
            {
                List<OilDto> result = apiInstance.ApiOilsGet();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OilsApi.ApiOilsGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiOilsGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<List<OilDto>> response = apiInstance.ApiOilsGetWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling OilsApi.ApiOilsGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**List&lt;OilDto&gt;**](OilDto.md)

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

<a id="apioilsiddelete"></a>
# **ApiOilsIdDelete**
> void ApiOilsIdDelete (int id)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using OilUsage.API.NetClient.Api;
using OilUsage.API.NetClient.Client;
using OilUsage.API.NetClient.Model;

namespace Example
{
    public class ApiOilsIdDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: ApiKey
            config.AddApiKey("X-API-Key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("X-API-Key", "Bearer");

            var apiInstance = new OilsApi(config);
            var id = 56;  // int | 

            try
            {
                apiInstance.ApiOilsIdDelete(id);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OilsApi.ApiOilsIdDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiOilsIdDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    apiInstance.ApiOilsIdDeleteWithHttpInfo(id);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling OilsApi.ApiOilsIdDeleteWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** |  |  |

### Return type

void (empty response body)

### Authorization

[ApiKey](../README.md#ApiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apioilsidget"></a>
# **ApiOilsIdGet**
> string ApiOilsIdGet (int id)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using OilUsage.API.NetClient.Api;
using OilUsage.API.NetClient.Client;
using OilUsage.API.NetClient.Model;

namespace Example
{
    public class ApiOilsIdGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: ApiKey
            config.AddApiKey("X-API-Key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("X-API-Key", "Bearer");

            var apiInstance = new OilsApi(config);
            var id = 56;  // int | 

            try
            {
                string result = apiInstance.ApiOilsIdGet(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OilsApi.ApiOilsIdGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiOilsIdGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<string> response = apiInstance.ApiOilsIdGetWithHttpInfo(id);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling OilsApi.ApiOilsIdGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** |  |  |

### Return type

**string**

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

<a id="apioilsidput"></a>
# **ApiOilsIdPut**
> void ApiOilsIdPut (int id, string body = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using OilUsage.API.NetClient.Api;
using OilUsage.API.NetClient.Client;
using OilUsage.API.NetClient.Model;

namespace Example
{
    public class ApiOilsIdPutExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: ApiKey
            config.AddApiKey("X-API-Key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("X-API-Key", "Bearer");

            var apiInstance = new OilsApi(config);
            var id = 56;  // int | 
            var body = "body_example";  // string |  (optional) 

            try
            {
                apiInstance.ApiOilsIdPut(id, body);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OilsApi.ApiOilsIdPut: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiOilsIdPutWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    apiInstance.ApiOilsIdPutWithHttpInfo(id, body);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling OilsApi.ApiOilsIdPutWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** |  |  |
| **body** | **string** |  | [optional]  |

### Return type

void (empty response body)

### Authorization

[ApiKey](../README.md#ApiKey)

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apioilspost"></a>
# **ApiOilsPost**
> void ApiOilsPost (string body = null)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using OilUsage.API.NetClient.Api;
using OilUsage.API.NetClient.Client;
using OilUsage.API.NetClient.Model;

namespace Example
{
    public class ApiOilsPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: ApiKey
            config.AddApiKey("X-API-Key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("X-API-Key", "Bearer");

            var apiInstance = new OilsApi(config);
            var body = "body_example";  // string |  (optional) 

            try
            {
                apiInstance.ApiOilsPost(body);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OilsApi.ApiOilsPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiOilsPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    apiInstance.ApiOilsPostWithHttpInfo(body);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling OilsApi.ApiOilsPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **body** | **string** |  | [optional]  |

### Return type

void (empty response body)

### Authorization

[ApiKey](../README.md#ApiKey)

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

