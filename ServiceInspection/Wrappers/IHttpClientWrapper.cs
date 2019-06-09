using System.Threading.Tasks;

namespace ServiceInspection.Wrappers
{
    public interface IHttpClientWrapper
    {
        void Initialize(string baseUrl, string apiName);
        Task<T> GetAsync<T>(string apiMethod);
        Task<T> PostAsJsonAsync<T>(string apiMethod, object value);
    }
}