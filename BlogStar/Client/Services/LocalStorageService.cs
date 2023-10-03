using BlogStar.Client.Services.IServices;
using BlogStar.Shared.Dtos;
using Microsoft.JSInterop;
using System.Security.Claims;
using System.Text.Json;

namespace BlogStar.Client.Services
{
    public class LocalStorageService : ILocalStorageService
    {
        private IJSRuntime _jsRuntime;
        public LocalStorageService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
        public async Task<T> GetItem<T>(string key)
        {
            var json = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", key);
            if(json == null)
            {
                return default;
            }

            return JsonSerializer.Deserialize<T>(json);
        }

        public async Task SetItem<T>(string key, T value)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", key, JsonSerializer.Serialize(value));
        }

        public async Task RemoveItem(string key)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", key);
        }

        public async Task<ClaimDTO> GetClaims()
        {
            var auth = await GetItem<TokenDTO>("auth");
            return ParseClaimsFromJwt(auth.AccessToken);
        }

        private static ClaimDTO ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            //var response = keyValuePairs.Select(kvp => new Claim(kvp.Key,kvp.Value.ToString()));
            //return response;
            return new ClaimDTO
            {
                Email = keyValuePairs["Email"].ToString(),
                Id = keyValuePairs["Id"].ToString(),
                Name = keyValuePairs["Name"].ToString(),
                Expiration = keyValuePairs["Expiration"].ToString(),
                Jti = keyValuePairs["jti"].ToString()
            };
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}
