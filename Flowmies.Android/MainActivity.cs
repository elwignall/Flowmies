using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Facebook;
using Android.Content;
using Xamarin.Facebook.AppEvents;

[assembly: MetaData("com.facebook.sdk.ApplicationId", Value = "@string/facebook_app_id")]
[assembly: MetaData("com.facebook.sdk.ApplicationName", Value = "@string/app_name")]

namespace Flowmies.Droid
{
    [Activity(Label = "Flowmies", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static ICallbackManager CallbackManager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            // Create callback manager using CallbackManagerFactory
            CallbackManager = CallbackManagerFactory.Create();

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            LoadApplication(new Flowmies.App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnActivityResult(
            int requestCode,
            Result resultCode,
            Intent data)
                {
                    base.OnActivityResult(requestCode, resultCode, data);
                    CallbackManager.OnActivityResult(requestCode, Convert.ToInt32(resultCode),
                        data);
                }
        }
}