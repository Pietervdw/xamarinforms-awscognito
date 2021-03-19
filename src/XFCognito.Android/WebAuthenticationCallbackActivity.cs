using Android.App;
using Android.Content.PM;

namespace XFCognito.Droid
{
    [Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
    [IntentFilter(new[] {Android.Content.Intent.ActionView},
        Categories = new[] {Android.Content.Intent.CategoryDefault, Android.Content.Intent.CategoryBrowsable},
        DataScheme = "myxfcognitoapp")]
    public class WebAuthenticationCallbackActivity
        : Xamarin.Essentials.WebAuthenticatorCallbackActivity
    {

    }
}