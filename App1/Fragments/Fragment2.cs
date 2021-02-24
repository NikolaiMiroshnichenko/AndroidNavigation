using Android.OS;
using Android.Views;

namespace App1.Fragments
{
    public class Fragment2 : Android.Support.V4.App.Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            HasOptionsMenu = true;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment2_layout, container, false);
            return view;
        }

        public override void OnResume()
        {
            if (Activity is MainActivity activity)
            {
                activity.SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            }
            base.OnResume();

        }

    }
}