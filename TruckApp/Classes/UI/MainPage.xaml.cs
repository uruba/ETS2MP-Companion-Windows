using System;
using TruckersMPApp.Classes.Model;
using TruckersMPApp.Classes.UI.Dialogs;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TruckersMPApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private ServerList _serverList;

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
