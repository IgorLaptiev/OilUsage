/*
 * OilUsage.API
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 1.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using Xunit;

using OilUsage.API.NetClient.Client;
using OilUsage.API.NetClient.Api;
// uncomment below to import models
//using OilUsage.API.NetClient.Model;

namespace OilUsage.API.NetClient.Test.Api
{
    /// <summary>
    ///  Class for testing IssuesApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class IssuesApiTests : IDisposable
    {
        private IssuesApi instance;

        public IssuesApiTests()
        {
            instance = new IssuesApi();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of IssuesApi
        /// </summary>
        [Fact]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsType' IssuesApi
            //Assert.IsType<IssuesApi>(instance);
        }

        /// <summary>
        /// Test ApiIssuesGet
        /// </summary>
        [Fact]
        public void ApiIssuesGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.ApiIssuesGet();
            //Assert.IsType<List<IssueDto>>(response);
        }

        /// <summary>
        /// Test ApiIssuesGetOilForBaseCareGet
        /// </summary>
        [Fact]
        public void ApiIssuesGetOilForBaseCareGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //List<string> issues = null;
            //var response = instance.ApiIssuesGetOilForBaseCareGet(issues);
            //Assert.IsType<List<OilUsageDto>>(response);
        }

        /// <summary>
        /// Test ApiIssuesGetOilForCareProductsGet
        /// </summary>
        [Fact]
        public void ApiIssuesGetOilForCareProductsGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //List<string> issues = null;
            //var response = instance.ApiIssuesGetOilForCareProductsGet(issues);
            //Assert.IsType<List<OilUsageDto>>(response);
        }

        /// <summary>
        /// Test ApiIssuesGetOilForInternalUsageGet
        /// </summary>
        [Fact]
        public void ApiIssuesGetOilForInternalUsageGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //List<string> issues = null;
            //var response = instance.ApiIssuesGetOilForInternalUsageGet(issues);
            //Assert.IsType<List<OilUsageDto>>(response);
        }
    }
}
