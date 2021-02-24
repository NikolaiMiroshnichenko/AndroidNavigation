using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using App1.Models;
using App1.ViewHolders;
using System.Collections.Generic;
using System.Linq;

namespace App1.Adapters
{
    public class PlanetAdapter : RecyclerView.Adapter
    {
        private readonly LayoutInflater _inflater;
        private readonly List<Planet> _planets;

        public override int ItemCount => _planets.Count;

        public PlanetAdapter(Context context, List<Planet> planets)
        {
            _planets = planets;
            _inflater = LayoutInflater.From(context);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = _inflater.Inflate(Resource.Layout.item_layout, parent, false);
            return new PlanetViewHolder(view);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            Planet planet = _planets.ElementAt(position);
            var planetVH = (PlanetViewHolder)holder;
            planetVH.NameTextView.Text = planet.Name;
            planetVH.TerrainTextView.Text = planet.Terrain;
            planetVH.PoppulationTextView.Text = planet.Population;
        }
    }
}