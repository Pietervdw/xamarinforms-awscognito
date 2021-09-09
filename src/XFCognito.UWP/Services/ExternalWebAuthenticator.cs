using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Essentials;
using Xamarin.Essentials.Interfaces;

namespace XFCognito.UWP.Services
{
    public class ExternalWebAuthenticator : IWebAuthenticator
    {
        public static TaskCompletionSource<WebAuthenticatorResult> BrowserAuthenticationTaskCompletionSource { get; set; }

        public Task<WebAuthenticatorResult> AuthenticateAsync(Uri url, Uri callbackUrl)
        {
            return BrowserAuthenticateAsync(url, callbackUrl);
        }

        public Task<WebAuthenticatorResult> AuthenticateAsync(WebAuthenticatorOptions webAuthenticatorOptions)
        {
            return AuthenticateAsync(webAuthenticatorOptions.Url, webAuthenticatorOptions.CallbackUrl);
        }

        static Task<WebAuthenticatorResult> BrowserAuthenticateAsync(Uri url, Uri callbackUrl)
        {
            BrowserAuthenticationTaskCompletionSource = new TaskCompletionSource<WebAuthenticatorResult>();
            //var urlParts = HttpUtility.ParseQueryString(url.ToString());
            //urlParts.Set("redirect_uri", HttpUtility.UrlEncode(callbackUrl.ToString()));
            //var uriWithCallBack = new Uri(urlParts.ToString());
            Launcher.OpenAsync(url);
            return BrowserAuthenticationTaskCompletionSource.Task;
        }


    }
}
