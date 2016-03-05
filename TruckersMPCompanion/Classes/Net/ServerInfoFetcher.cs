using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using TruckersMPApp.Classes.Constants;
using TruckersMPApp.Classes.Model;
using Windows.Data.Json;
using Windows.Web.Http;

namespace TruckersMPApp
{
    public sealed class ServerInfoFetcher
    {
        public static async Task<ObservableCollection<ServerInfo>> fetchServers()
        {
            HttpResponseMessage response = await new HttpClient().GetAsync(new Uri(URL.SERVER_LIST));
            string rawResponse = await response.Content.ReadAsStringAsync().AsTask();
            JsonArray responseArray = JsonObject.Parse(rawResponse)["response"].GetArray();

            ObservableCollection<ServerInfo> serverCollection = new ObservableCollection<ServerInfo>();

            foreach (JsonValue entryValue in responseArray)
            {
                JsonObject entryObject = entryValue.GetObject();

                ServerInfo serverInfoEntry = new ServerInfo(
                    entryObject["online"].GetBoolean(), 
                    entryObject["game"].GetString(), 
                    entryObject["name"].GetString(), 
                    entryObject["players"].GetNumber(), 
                    entryObject["maxplayers"].GetNumber()
                    );

                serverCollection.Add(serverInfoEntry);
            }

            return new ObservableCollection<ServerInfo>(serverCollection.OrderByDescending(a => a.playerCountCurrent));
        }
    }
}
