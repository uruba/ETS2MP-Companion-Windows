using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using TruckersMPApp.Classes.Model.Entities;

namespace TruckersMPApp.Classes.Model
{
    class ServerList : INotifyPropertyChanged
    {
        public ObservableCollection<ServerInfo> ServerCollection
        {
            get;
            private set;
        }

        public ObservableCollection<ServerInfo> Servers
        {
            get
            {
                if (this.ServerCollection == null || String.IsNullOrEmpty(filterByGameName))
                {
                    return this.ServerCollection;
                }

                return new ObservableCollection<ServerInfo>(this.ServerCollection.Where(x => x.gameName.Contains(filterByGameName)));
            }
        }

        public bool TextFilterByGameVisibility
        {
            get
            {
                if (String.IsNullOrEmpty(filterByGameName) || EmptyListPlaceholderVisibility == true || TextLastUpdatedVisibility == false)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public bool EmptyListPlaceholderVisibility
        {
            get
            {
                return (this.Servers == null || this.Servers.Count == 0) && this.isLoading == false ?
                    true :
                    false;
            }
        }
        public bool TextLastUpdatedVisibility
        {
            get
            {
                return (this.EmptyListPlaceholderVisibility || this.Servers == null || this.Servers.Count == 0) ?
                    false :
                    true;
            }
        }

        private bool _isLoading;

        public bool isLoading
        {
            get
            {
                return _isLoading;
            }
            private set
            {
                _isLoading = value;
                OnPropertyChanged("isLoading");
            }
        }

        public string filterByGameName
        {
            get
            {
                return (Windows.Storage.ApplicationData.Current.LocalSettings.Values["filterServerByGame"] ?? String.Empty)
                    as string;
            }
        }

        public DateTime lastUpdated
        {
            get;
            private set;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public async Task<ObservableCollection<ServerInfo>> getServers()
        {
            this.isLoading = true;
            this.ServerCollection = await ServerInfoFetcher.fetchServers();
            this.lastUpdated = DateTime.Now;
            this.isLoading = false;
            return this.ServerCollection;
        }
    }
}
