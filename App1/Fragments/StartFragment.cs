using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App1.Fragments
{
    public class StartFragment : Android.Support.V4.App.Fragment
    {
        private Button _button;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.strat_fragment_layout, container, false);
            _button = view.FindViewById<Button>(Resource.Id.button1);
            return view;
        }

        public override void OnResume()
        {
            Activity.Title = "AndroidNavigation";
            _button.Click += NavigteToFragment;
            if (Activity is MainActivity activity)
            {
                activity.SupportActionBar.SetDisplayHomeAsUpEnabled(false);
            }
            base.OnResume();
        }

        public override void OnStop()
        {
            _button.Click -= NavigteToFragment;
            base.OnStop();
        }

        private void NavigteToFragment(object sender, EventArgs e)
        {
            Activity.Title = "SecondFragment";
            var transaction = Activity.SupportFragmentManager.BeginTransaction();
            var fragment2 = new Fragment2();
            transaction.Replace(Resource.Id.rootLayout, new Fragment2());
            transaction.AddToBackStack(null);
            transaction.Commit();
        }
    }
}