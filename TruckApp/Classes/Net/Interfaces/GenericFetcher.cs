using System;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace TruckersMPApp.Classes.Net.Interfaces
{
    public abstract class GenericFetcher
    {
        public static async Task<string> fetchRawData(Uri uri)
        {
            return await new HttpClient().GetStringAsync(uri);
        }
    }
}
