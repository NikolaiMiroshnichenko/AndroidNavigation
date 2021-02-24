using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Widget;
using App1.Fragments;

namespace App1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private LinearLayout _linearLayout;
        private Android.Support.V7.Widget.Toolbar _toolbar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            _toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(_toolbar);

            _linearLayout = FindViewById<LinearLayout>(Resource.Id.rootLayout);

            var transaction = SupportFragmentManager.BeginTransaction();
            transaction.Replace(Resource.Id.rootLayout, new PlanetsListFragment());
            transaction.Commit();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnResume()
        {
            _toolbar.NavigationClick += toolbarClick;
            base.OnResume();
        }

        protected override void OnStop()
        {
            _toolbar.NavigationClick -= toolbarClick;
            base.OnResume();
        }

        private void toolbarClick(object sender, EventArgs e)
        {
            OnBackPressed();
        }
    }
}
