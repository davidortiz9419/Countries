﻿namespace Countries.Droid
{
    using Android.App;
    using Android.Content.PM;
    using Android.OS;
    using FFImageLoading.Forms.Droid;

    [Activity(
        Label = "Countries", 
        Icon = "@drawable/icon", 
        Theme = "@style/MainTheme", 
        MainLauncher = true, 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);
            CachedImageRenderer.Init(true);
            LoadApplication(new App());
        }
    }
}