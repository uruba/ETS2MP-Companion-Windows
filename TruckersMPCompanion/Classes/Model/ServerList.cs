using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckersMPApp.Classes.Model.Entities;

namespace TruckersMPApp.Classes.Model
{
    class ServerList
    {
        public delegate void fetchEventHandler();

        public event fetchEventHandler beforeFetch;
        public event fetchEventHandler afterFetch;

        public ObservableCollection<ServerInfo> ServerCollection
        {
            get;
            private set;
        }

        public async Task<ObservableCollection<ServerInfo>> fetchServers()
        {
            beforeFetch();
            this.ServerCollection = await ServerInfoFetcher.fetchServers();
            afterFetch();
            return this.ServerCollection;
        }
    }
}
