using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
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
            transaction.Replace(Resource.Id.rootLayout, new StartFragment());
            transaction.Commit();
            _toolbar.Click += toolbarClick;
        }

        private void toolbarClick(object sender, EventArgs e)
        {
            OnBackPressed();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        //public override bool OnOptionsItemSelected(IMenuItem item)
        //{
        //    int id = item.ItemId;
        //    if (id == 16908332)
        //    {
        //        //var transaction = SupportFragmentManager.BeginTransaction();
        //        //transaction.Replace(Resource.Id.rootLayout, new StartFragment());
        //        //transaction.Commit();
        //        //return true;
        //        OnBackPressed();
        //    }
  
        //    return true;
        //}

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
