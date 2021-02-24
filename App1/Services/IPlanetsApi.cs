using Android.App;
using Android.Content;
using App1.Models;
using Refit;
using System.Threading.Tasks;

namespace App1.Services
{
    public interface IPlanetsApi
    {
        [Get("/planets")]
        Task<PlanetsResponse> GetPlanets();
    }
}