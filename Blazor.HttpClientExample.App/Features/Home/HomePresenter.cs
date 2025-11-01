using System.Net.Http.Json;

namespace Blazor.HttpClientExample.App.Features.Home
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

    public interface IHomePresenter
    {
        Task LoadUsers(IHomeView view);
    }

    public class HomePresenter : IHomePresenter
    {
        public HomePresenter(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private readonly HttpClient _httpClient;

        public async Task LoadUsers(IHomeView view)
        {
            var users = await _httpClient.GetFromJsonAsync<List<UserViewModel>>("users");
            await Task.Delay(1500);
            view.SetUsers(users);
        }
    }
}
