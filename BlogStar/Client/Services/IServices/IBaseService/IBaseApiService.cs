namespace BlogStar.Client.Services.IServices.IBaseService
{
    public interface IBaseApiService
    {
        bool NeedAuthorization { get; set; }
        Task<T> GenerataResponse<T>(HttpResponseMessage response);
        Task<T> GetAsync<T>(string url);

        Task<T> PostAsync<T>(string url, object data);

        Task<T> PutAsync<T>(string url, object data);

        Task<T> DeleteAsync<T>(string url);
    }
}
