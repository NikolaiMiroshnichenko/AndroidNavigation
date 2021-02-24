using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace App1.ViewHolders
{
    public class PlanetViewHolder : RecyclerView.ViewHolder
    {
        public TextView nameTW, terrainTW, poppulationTW;

        public PlanetViewHolder(View view) : base(view)
        {
            nameTW = (TextView)view.FindViewById(Resource.Id.nameTextView);
            terrainTW = (TextView)view.FindViewById(Resource.Id.terrainTextView);
            poppulationTW = (TextView)view.FindViewById(Resource.Id.poppulationTextView);
        }
    }
}

