using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TruckersMPApp.Classes.Converters;
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

        public DateTime LastUpdated
        {
            get
            {
                return this._serverList.lastUpdated;
            }
        }

        public MainPage()
        {
            this.InitializeComponent();
            this._serverList = new ServerList();

            this.refreshServers();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            this.refreshServers();
        }

        private async void refreshServers()
        {
            await this._serverList.getServers();
            Bindings.Update();
        }

        private async void Filter_Click(object sender, RoutedEventArgs e)
        {
            ServerFilterDialog filterDialog = new ServerFilterDialog();
            await filterDialog.ShowAsync();
     
            if (!filterDialog.isCancelled)
            {
                Bindings.Update();
            }    
        }
    }
}
