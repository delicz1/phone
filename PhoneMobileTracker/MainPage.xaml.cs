using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Devices.Geolocation;
using System.Globalization;
using System.IO.IsolatedStorage;
using PhoneMobileTracker.Resources;

namespace PhoneMobileTracker
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            ApplicationBar = new ApplicationBar();
            Loaded += MainPage_Loaded;
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e) {
            InitAppBar();
            if( IsolatedStorageSettings.ApplicationSettings.Contains(AppSetting.PREF_IMEI)) {
                Imei.Text = IsolatedStorageSettings.ApplicationSettings[AppSetting.PREF_IMEI].ToString();
            }
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            NavigationService.RemoveBackEntry();  

            if (App.Geolocator == null)
            {
                App.Geolocator = new Geolocator();
                App.Geolocator.DesiredAccuracy = PositionAccuracy.High;
                App.Geolocator.MovementThreshold = 100; // The units are meters.
                App.Geolocator.PositionChanged += geolocator_PositionChanged;
            }
        }

        protected override void OnRemovedFromJournal(System.Windows.Navigation.JournalEntryRemovedEventArgs e)
        {
            App.Geolocator.PositionChanged -= geolocator_PositionChanged;
            App.Geolocator = null;
        }

        void client_WriteGpsCompleted(object sender, WcfMobileTracker.WriteGpsCompletedEventArgs e)
        {

        }

        void geolocator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            string latString = args.Position.Coordinate.Latitude.ToString("0.000000");
            string lngString = args.Position.Coordinate.Longitude.ToString("0.000000");
            double lat = double.Parse(latString);
            double lng = double.Parse(lngString);

            DateTime dateTime = DateTime.UtcNow;
            int timestamp = (int) (dateTime - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds;
            WcfMobileTracker.ServiceClient client = new WcfMobileTracker.ServiceClient();
            client.WriteGpsAsync("admin", "123456", "123456", (int)timestamp, lat, lng);
            client.WriteGpsCompleted += new EventHandler<WcfMobileTracker.WriteGpsCompletedEventArgs>(client_WriteGpsCompleted);
            client.CloseAsync();

            if (!App.RunningInBackground)
            {
                Dispatcher.BeginInvoke(() =>
                {
                    UnixTimeTextBlock.Text = timestamp.ToString();
                    LatitudeTextBlock.Text = args.Position.Coordinate.Latitude.ToString("0.00");
                    LongitudeTextBlock.Text = args.Position.Coordinate.Longitude.ToString("0.00");
                });
            }
            //else
            //{
            //    Microsoft.Phone.Shell.ShellToast toast = new Microsoft.Phone.Shell.ShellToast();
            //    toast.Content = args.Position.Coordinate.Latitude.ToString("0.00");
            //    toast.Title = "Location: ";
            //    toast.NavigationUri = new Uri("/Page2.xaml", UriKind.Relative);
            //    toast.Show();

            //}
        }

        private void InitAppBar() {
            ApplicationBarIconButton btn = new ApplicationBarIconButton();
            btn.IconUri = new Uri("/Assets/Bar/logout.png", UriKind.Relative);
            btn.Text = "Odhlasit";
            btn.Click += btnLogOut_Click;

            ApplicationBar.Buttons.Add(btn);
        }

        void btnLogOut_Click(object sender, EventArgs e) {
            IsolatedStorageSettings.ApplicationSettings.Remove(AppSetting.PREF_USER_NAME);
            IsolatedStorageSettings.ApplicationSettings.Remove(AppSetting.PREF_USER_PASSWORD);
            NavigationService.Navigate(new Uri("/LoginPage.xaml", UriKind.Relative));
        }

        private void DeviceConnect(string imei) {
            BtnImei.IsEnabled = false;
            string userName = IsolatedStorageSettings.ApplicationSettings[AppSetting.PREF_USER_NAME].ToString();
            string password = IsolatedStorageSettings.ApplicationSettings[AppSetting.PREF_USER_PASSWORD].ToString();

            ProgressIndicator progress = new ProgressIndicator {
                IsVisible = true,
                IsIndeterminate = true,
                Text = AppResources.TitleLoading
            };

            SystemTray.SetProgressIndicator(this, progress);

            WcfMobileTracker.ServiceClient client = new WcfMobileTracker.ServiceClient();
            client.CheckDeviceAsync(userName, password, imei);
            client.CheckDeviceCompleted += client_CheckDeviceCompleted;
            client.CloseAsync();
        }

        void client_CheckDeviceCompleted(object sender, WcfMobileTracker.CheckDeviceCompletedEventArgs e) {
            BtnImei.IsEnabled = true;
            SystemTray.SetProgressIndicator(this, null);

            if ((bool)e.Result) {
                MessageBox.Show("Zarizeni bylo uspesne sparovano");
                IsolatedStorageSettings.ApplicationSettings[AppSetting.PREF_IMEI] = Imei;
            } else {
                MessageBox.Show("Zarizeni nebylo sparovano");
            }
        }

        private void BtnImei_Click(object sender, RoutedEventArgs e) {
            DeviceConnect(Imei.Text);
        }
    }
}