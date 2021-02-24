using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace App1.ViewHolders
{
    public class PlanetViewHolder : RecyclerView.ViewHolder
    {
        public TextView NameTextView { get; internal set; } 
        public TextView TerrainTextView { get; internal set; }
        public TextView PoppulationTextView { get; internal set; }

        public PlanetViewHolder(View view) : base(view)
        {
            NameTextView = (TextView)view.FindViewById(Resource.Id.nameTextView);
            TerrainTextView = (TextView)view.FindViewById(Resource.Id.terrainTextView);
            PoppulationTextView = (TextView)view.FindViewById(Resource.Id.poppulationTextView);
        }
    }
}

