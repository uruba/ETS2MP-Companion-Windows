using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TruckersMPApp.Classes.Model.Entities;
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
        private ObservableCollection<ServerInfo> _serverList;
        public ObservableCollection<ServerInfo> Servers {
            get
            {
                return this._serverList;
            }
        }
        public Windows.UI.Xaml.Visibility EmptyListPlaceholderVisibility
        {
            get
            {
                return (this._serverList == null || this._serverList.Count == 0) && this.loadingProgressBar.Visibility == Windows.UI.Xaml.Visibility.Collapsed ? 
                    Windows.UI.Xaml.Visibility.Visible :
                    Windows.UI.Xaml.Visibility.Collapsed;
            }
        }

        public MainPage()
        {
            this.InitializeComponent();
            this.fetchServers();
        }

        private async void fetchServers()
        {
            this.loadingProgressBar.Visibility = Visibility.Visible;
            this._serverList = await ServerInfoFetcher.fetchServers();
            this.loadingProgressBar.Visibility = Visibility.Collapsed;
            Bindings.Update();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            this.fetchServers();
        }
    }
}
