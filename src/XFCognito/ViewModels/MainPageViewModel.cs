using Prism.Commands;
using Prism.Navigation;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials.Interfaces;

namespace XFCognito.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IWebAuthenticator _webAuthenticator;

        private string _accessToken;
        public string AccessToken
        {
            get => _accessToken;
            set => SetProperty(ref _accessToken, value);
        }

        private DelegateCommand _loginCommand;
        public DelegateCommand LoginCommand => _loginCommand ?? (_loginCommand = new DelegateCommand(ExecuteLoginCommand));

        public MainPageViewModel(INavigationService navigationService, IWebAuthenticator webAuthenticator) : base(navigationService)
        {
            _webAuthenticator = webAuthenticator;
            Title = "AWS Cognito & Xamarin Forms";
        }

        async void ExecuteLoginCommand()
        {
            try
            {
                var results = await _webAuthenticator.AuthenticateAsync(
                    new Uri("https://myxamarinapp.auth.us-east-1.amazoncognito.com/login?client_id=4jlfe2iki0ucn32uc44clmib3d&response_type=token&scope=email+openid+profile&redirect_uri=myxfcognitoapp://"),
                    new Uri("myxfcognitoapp://"));

                AccessToken = results?.AccessToken;
            }
            catch (TaskCanceledException e)
            {
                AccessToken = "You've cancelled.";
            }
        }
    }

}
