using Microsoft.AspNetCore.Components;

namespace Blazor.HttpClientExample.Web.Features.Home
{
    public interface IHomeView
    {
        void SetUsers(IList<UserViewModel>? users);
    }

    public partial class HomeView : IHomeView
    {
        [Inject]
        public required IHomePresenter Presenter { get; set; }

        private IList<UserViewModel>? _users;

        protected override async Task OnInitializedAsync()
        {
            await Presenter.LoadUsers(this);
        }

        public void SetUsers(IList<UserViewModel>? users)
        {
            _users = users;
        }
    }
}