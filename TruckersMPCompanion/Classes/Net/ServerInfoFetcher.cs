using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
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
            ObservableCollection<ServerInfo> serverCollection = new ObservableCollection<ServerInfo>();

            try
            {
                string response = await new HttpClient().GetStringAsync(new Uri(URL.SERVER_LIST));
                JsonArray responseArray = JsonObject.Parse(response)["response"].GetArray();

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
            } catch (Exception)
            {
                return new ObservableCollection<ServerInfo>();
            }


            return new ObservableCollection<ServerInfo>(serverCollection.OrderByDescending(a => a.playerCountCurrent));
        }
    }
}
