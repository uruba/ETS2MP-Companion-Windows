﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TruckersMPApp.Classes.Model;
using TruckersMPApp.Classes.Model.Entities;
using TruckersMPApp.Classes.UI.Dialogs;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TruckersMPApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ServerList _serverList;
        public ObservableCollection<ServerInfo> Servers {
            get
            {
                if (this._serverList.ServerCollection == null || String.IsNullOrEmpty(filterByGameName))
                {
                    return this._serverList.ServerCollection;
                }

                return new ObservableCollection<ServerInfo>(this._serverList.ServerCollection.Where(x => x.gameName.Contains(filterByGameName)));
            }
        }
        private string filterByGameName
        {
            get
            {
                return 
                    (Windows.Storage.ApplicationData.Current.LocalSettings.Values["filterServerByGame"] ?? String.Empty) 
                    as string;
            }
        }

        public DateTime LastUpdated
        {
            get
            {
                return this._serverList.lastUpdated;
            }
        }
        public Visibility EmptyListPlaceholderVisibility
        {
            get
            {
                return (this.Servers == null || this.Servers.Count == 0) && this.loadingProgressBar.Visibility == Visibility.Collapsed ?
                    Visibility.Visible :
                    Visibility.Collapsed;
            }
        }
        public Visibility TextLastUpdatedVisibility
        {
            get;
            private set;
        } = Visibility.Collapsed;

        public MainPage()
        {
            this.InitializeComponent();
            this._serverList = new ServerList();
            this._serverList.beforeFetch += new ServerList.fetchEventHandler(beforeRefresh);
            this._serverList.afterFetch += new ServerList.fetchEventHandler(afterRefresh);

            this.refreshServers();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            this.refreshServers();
        }

        private async void refreshServers()
        {
            await this._serverList.getServers();
        }

        private void beforeRefresh()
        {
            this.loadingProgressBar.Visibility = Visibility.Visible;
        }

        private void afterRefresh()
        {
            this.loadingProgressBar.Visibility = Visibility.Collapsed;
            this.TextLastUpdatedVisibility = Visibility.Visible;

            Bindings.Update();
        }

        private async void Filter_Click(object sender, RoutedEventArgs e)
        {
            ServerFilterDialog filterDialog = new ServerFilterDialog();
            await filterDialog.ShowAsync();
     
            Bindings.Update();
        }
    }
}
