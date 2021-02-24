using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using App1.Adapters;
using App1.Models;
using App1.Services;
using ModernHttpClient;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace App1.Fragments
{
    public class PlanetsListFragment : Android.Support.V4.App.Fragment
    {
        private FloatingActionButton _fab;
        private IPlanetsApi _planetsApi;
        private RecyclerView _recyclerView;
        private List<Planet> _planets = new List<Planet>();
        private PlanetAdapter _adapter;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            InitializeRestServices();
            InitializePlanetsList();
            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.planets_list_fragment_layout, container, false);

            _recyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);
            _adapter = new PlanetAdapter(Activity, _planets);
            _recyclerView.SetLayoutManager(new LinearLayoutManager(Activity));
            _recyclerView.SetAdapter(_adapter);
            _fab = view.FindViewById<FloatingActionButton>(Resource.Id.fab);

            return view;
        }

        public override void OnResume()
        {
            Activity.Title = "Planets List";
            _fab.Click += NavigateToFragment;
            if (Activity is MainActivity activity)
            {
                activity.SupportActionBar.SetDisplayHomeAsUpEnabled(false);
            }
            base.OnResume();
        }

        public override void OnStop()
        {
            _fab.Click -= NavigateToFragment;
            base.OnStop();
        }

        private void NavigateToFragment(object sender, EventArgs e)
        {
            Activity.Title = "SecondFragment";
            var transaction = Activity.SupportFragmentManager.BeginTransaction();
            var fragment2 = new Fragment2();
            transaction.Replace(Resource.Id.rootLayout, new Fragment2());
            transaction.AddToBackStack(null);
            transaction.Commit();
        }

        private void InitializePlanetsList()
        {
            var task = Task.Run(async () =>
            {
                try
                {
                    _planets.Clear();
                    _planets.AddRange((await _planetsApi.GetPlanets()).Results);
                    Activity.RunOnUiThread(() => _adapter.NotifyDataSetChanged());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });
        }

        private void InitializeRestServices()
        {
            var client = new HttpClient(new NativeMessageHandler())
            {
                BaseAddress = new Uri("https://swapi.dev/api")
            };
            _planetsApi = RestService.For<IPlanetsApi>(client);
        }
    }
}