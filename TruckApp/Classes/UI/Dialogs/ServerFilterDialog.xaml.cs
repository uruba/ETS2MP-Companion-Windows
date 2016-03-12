using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using TruckersMPApp;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TruckersMPApp.Classes.UI.Dialogs
{
    // TODO: Maybe rethink this class to conform more to the MVVM principles
    public sealed partial class ServerFilterDialog : ContentDialog
    {
        private string _selectedGameName;
        private Windows.Storage.ApplicationDataContainer localSettings;

        public bool isCancelled
        {
            get;
            private set;
        } = false;

        public ServerFilterDialog()
        {
            this.InitializeComponent();
            localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            initRadioButtons();
        }

        private void initRadioButtons()
        {
            RadioButton toSelect = null;

            string filterByGame = localSettings.Values["filterServerByGame"] as string;

            switch (filterByGame)
            {
                case "ETS2":
                    toSelect = ETS2;
                    break;
                case "ATS":
                    toSelect = ATS;
                    break;
                default:
                    toSelect = ALL;
                    break;
            }

            toSelect.IsChecked = true;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (_selectedGameName != null)
            {
                localSettings.Values["filterServerByGame"] = _selectedGameName;
            }

            isCancelled = false;
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            isCancelled = true;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;

            if (radioButton != null)
            {
                _selectedGameName = radioButton.Tag.ToString();
            }
        }
    }
}
