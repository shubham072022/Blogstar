using BlogStar.Client.Services.IServices;
using BlogStar.Client.Services.IServices.IBaseService;
using BlogStar.Shared.Dtos;
using BlogStar.Shared.Wrapper.Concrete;
using Newtonsoft.Json;
using System;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace BlogStar.Client.Services.BaseService
{
    public class BaseApiService : IBaseApiService
    {
        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorageService;
        public bool NeedAuthorization { get; set; }

        public BaseApiService(HttpClient http, ILocalStorageService localStorageService)
        {
            _http = http;
            _localStorageService = localStorageService;
            
        }

        public async Task<T> GenerataResponse<T>(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }

        public async Task<T> DeleteAsync<T>(string url)
        {
            return await GenerataResponse<T>(await _http.DeleteAsync("api/" + url));
        }

        public async Task<T> GetAsync<T>(string url)
        {
            return await GenerataResponse<T>(await  _http.GetAsync("api/" + url));
        }

        public async Task<T> PostAsync<T>(string url, object data)
        {
            return await GenerataResponse<T>(await _http.PostAsJsonAsync<object>("api/" + url, data));
        }

        public async Task<T> PutAsync<T>(string url, object data)
        {
            return await GenerataResponse<T>(await _http.PutAsJsonAsync<object>("api/" + url, data));
        }
    }
}
