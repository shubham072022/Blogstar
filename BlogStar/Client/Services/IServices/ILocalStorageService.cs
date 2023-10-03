

using BlogStar.Shared.Dtos;
using System.Security.Claims;

namespace BlogStar.Client.Services.IServices
{
    public interface ILocalStorageService
    {
        Task<T> GetItem<T>(string key);

        Task SetItem<T>(string key, T value);

        Task RemoveItem(string key);

        Task<ClaimDTO> GetClaims();
    }
}
