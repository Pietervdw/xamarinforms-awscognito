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

        private string _authenticateUrl;
        public string AuthenticateUrl
        {
            get => _authenticateUrl;
            set => SetProperty(ref _authenticateUrl, value);
        }

        private string _callbackUrl;
        public string CallbackUrl
        {
            get => _callbackUrl;
            set => SetProperty(ref _callbackUrl, value);
        }
        
        private DelegateCommand _loginCommand;
        public DelegateCommand LoginCommand => _loginCommand ?? (_loginCommand = new DelegateCommand(ExecuteLoginCommand));

        public MainPageViewModel(INavigationService navigationService, IWebAuthenticator webAuthenticator) : base(navigationService)
        {
            _webAuthenticator = webAuthenticator;
            Title = "AWS Cognito & Xamarin Forms";
            AuthenticateUrl = "https://vuleinip.auth.us-east-2.amazoncognito.com/login?client_id=5d55renrdia8r2cg2hocmn98me&response_type=token&scope=aws.cognito.signin.user.admin+email+openid+phone+profile&redirect_uri=myxfcognitoapp://";
            CallbackUrl = "myxfcognitoapp://";
        }

        async void ExecuteLoginCommand()
        {
            try
            {
                var results = await _webAuthenticator.AuthenticateAsync(
                    new Uri(AuthenticateUrl),
                    new Uri(CallbackUrl));

                AccessToken = results?.AccessToken;
            }
            catch (TaskCanceledException e)
            {
                AccessToken = "You've cancelled.";
            }
        }
    }

}
