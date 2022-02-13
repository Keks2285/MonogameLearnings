using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Microsoft.Xna.Framework;

namespace Niko
{
    [Activity(
        Label = "@string/app_name",
        MainLauncher = true,
        Icon = "@drawable/icon",
        AlwaysRetainTaskState = true,
        LaunchMode = LaunchMode.SingleInstance,
        ScreenOrientation = ScreenOrientation.Landscape,
        ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden | ConfigChanges.ScreenSize
    )]
    public class ActivityMain : AndroidGameActivity
    {
        private NikoGame _game;
        private View _view;
        Bundle b;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            _game = new NikoGame();
            _view = _game.Services.GetService(typeof(View)) as View;

            SetContentView(_view);
            _game.Run();
        }
        //public async void StartLevel2()
        //{
        //    base.OnCreate(b);

        //    var intent = new Intent(this, typeof(Activity2));
        //    intent.SetFlags(ActivityFlags.NewTask);
        //    //Navigation to SecondActivity
        //    StartActivity(intent);
        //    //delete main activity from navigation
        //    Finish();
        //}
    }
}
