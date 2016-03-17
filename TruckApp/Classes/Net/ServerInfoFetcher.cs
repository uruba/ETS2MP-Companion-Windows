using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using TruckersMPApp.Classes.Constants;
using TruckersMPApp.Classes.Model.Entities;
using TruckersMPApp.Classes.Net.Interfaces;
using Windows.Data.Json;

namespace TruckersMPApp
{
    public sealed class ServerInfoFetcher : GenericFetcher
    {
        public static async Task<ObservableCollection<ServerInfo>> fetchServers()
        {
            ObservableCollection<ServerInfo> serverCollection = new ObservableCollection<ServerInfo>();

            try
            {
                string response = await ServerInfoFetcher.fetchRawData(new Uri(URL.SERVER_LIST));
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
                return null;
            }


            return new ObservableCollection<ServerInfo>(serverCollection.OrderByDescending(a => a.playerCountCurrent));
        }
    }
}
