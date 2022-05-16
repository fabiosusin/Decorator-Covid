using DecoratorProject.DTO.Enum;
using DecoratorProject.DTO.Services.Covid.Output;
using Services.Integration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace DecoratorProject.Services.Covid
{
    internal class CovidApiService
    {
        private readonly ApiDispatcher _apiDispatcher;
        private static readonly string BaseUrl = "https://api.covid19api.com";

        public CovidApiService() => _apiDispatcher = new ApiDispatcher();

        public async Task<CovidSummaryOutput> CovidSummary() => await SendRequest<CovidSummaryOutput>(RequestMethodEnum.GET, $"{ BaseUrl }/summary");

        private static Tuple<HttpRequestHeader, string>[] DefaultHeaders() => 
            new List<Tuple<HttpRequestHeader, string>> { new Tuple<HttpRequestHeader, string>(HttpRequestHeader.ContentType, "application/json") }.ToArray();

        private async Task<T> SendRequest<T>(RequestMethodEnum method, string url, object body = null)
        {
            try { return await _apiDispatcher.DispatchWithResponseAsync<T>(url, method, body, DefaultHeaders()); } catch { throw; }
        }
    }
}