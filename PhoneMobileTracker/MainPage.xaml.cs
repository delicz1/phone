using Microsoft.Phone.Shell;
using PhoneMobileTracker.Resources;
using System;
using System.IO.IsolatedStorage;
using System.Windows;
using System.Windows.Navigation;
using Windows.Devices.Geolocation;

namespace PhoneMobileTracker
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            ApplicationBar = new ApplicationBar();
            Loaded += MainPage_Loaded;
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e) {
            InitAppBar();
            var appSetting = IsolatedStorageSettings.ApplicationSettings;
            if (appSetting.Contains(AppSetting.PREF_IMEI))
            {
                Imei.Text = appSetting[AppSetting.PREF_IMEI].ToString();
            }
            EnableDisableStartStopBtn();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
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

        protected override void OnRemovedFromJournal(JournalEntryRemovedEventArgs e)
        {
            App.Geolocator.PositionChanged -= geolocator_PositionChanged;
            App.Geolocator = null;
        }

        void client_WriteGpsCompleted(object sender, WcfMobileTracker.WriteGpsCompletedEventArgs e)
        {
        }

        private string GetAppSettingString(string key)
        {
            string result = "";
            if (IsolatedStorageSettings.ApplicationSettings.Contains(key))
            {
                result = IsolatedStorageSettings.ApplicationSettings[key].ToString();
            }
            return result;
        }

        void geolocator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            string userName = GetAppSettingString(AppSetting.PREF_USER_NAME);
            string password = GetAppSettingString(AppSetting.PREF_USER_PASSWORD);
            string imei = GetAppSettingString(AppSetting.PREF_IMEI);

            string latString = args.Position.Coordinate.Latitude.ToString("0.000000");
            string lngString = args.Position.Coordinate.Longitude.ToString("0.000000");
            double lat = double.Parse(latString);
            double lng = double.Parse(lngString);

            DateTime dateTime = DateTime.UtcNow;
            int timestamp = (int) (dateTime - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds;
            var client = new WcfMobileTracker.ServiceClient();
            client.WriteGpsAsync(userName, password, imei, timestamp, lat, lng);
            client.WriteGpsCompleted += client_WriteGpsCompleted;
            client.CloseAsync();

            if (!App.RunningInBackground)
            {
                Dispatcher.BeginInvoke(() =>
                {
                    LatitudeTextBlock.Text = args.Position.Coordinate.Latitude.ToString("0.00");
                    LongitudeTextBlock.Text = args.Position.Coordinate.Longitude.ToString("0.00");
                });

//                var query = new ReverseGeocodeQuery();
//                query.GeoCoordinate = new GeoCoordinate(lat, lng);
//                query.QueryCompleted += (s, e) =>
//                {
//                    if (e.Error != null)
//                        return;
//                    Dispatcher.BeginInvoke(() =>
//                    {
//                        AddressTextBlock.Text = e.Result[0].Information.Address.ToString();
//                    });
//                };
//                query.QueryAsync();
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

        private void StartTracking()
        {
            if (App.Geolocator == null)
            {
                App.Geolocator = new Geolocator();
                App.Geolocator.DesiredAccuracy = PositionAccuracy.High;
                App.Geolocator.MovementThreshold = 100; // The units are meters.
                App.Geolocator.PositionChanged += geolocator_PositionChanged;
            }
        }

        private void StopTracking()
        {
            App.Geolocator.PositionChanged -= geolocator_PositionChanged;
            App.Geolocator = null;
        }

        private void InitAppBar() 
        {
            var btn = new ApplicationBarIconButton();
            btn.IconUri = new Uri("/Assets/Bar/logout.png", UriKind.Relative);
            btn.Text = AppResources.Logout;
            btn.Click += btnLogOut_Click;

            ApplicationBar.Buttons.Add(btn);
        }

        void btnLogOut_Click(object sender, EventArgs e) 
        {
            IsolatedStorageSettings.ApplicationSettings.Remove(AppSetting.PREF_USER_NAME);
            IsolatedStorageSettings.ApplicationSettings.Remove(AppSetting.PREF_USER_PASSWORD);
            NavigationService.Navigate(new Uri("/LoginPage.xaml", UriKind.Relative));
        }

        private void DeviceConnect(string imei) 
        {
            BtnImei.IsEnabled = false;
            string userName = IsolatedStorageSettings.ApplicationSettings[AppSetting.PREF_USER_NAME].ToString();
            string password = IsolatedStorageSettings.ApplicationSettings[AppSetting.PREF_USER_PASSWORD].ToString();

            var progress = new ProgressIndicator 
            {
                IsVisible = true,
                IsIndeterminate = true,
                Text = AppResources.TitleLoading
            };

            SystemTray.SetProgressIndicator(this, progress);

            var client = new WcfMobileTracker.ServiceClient();
            client.CheckDeviceAsync(userName, password, imei);
            client.CheckDeviceCompleted += client_CheckDeviceCompleted;
            client.CloseAsync();
        }

        void client_CheckDeviceCompleted(object sender, WcfMobileTracker.CheckDeviceCompletedEventArgs e) 
        {
            BtnImei.IsEnabled = true;
            SystemTray.SetProgressIndicator(this, null);

            if (e.Result) 
            {
                MessageBox.Show(AppResources.ConnectionDeviceOn);
                IsolatedStorageSettings.ApplicationSettings[AppSetting.PREF_IMEI] = Imei.Text;
            } else
            {
                MessageBox.Show(AppResources.ConnectionDeviceError);
            }
        }

        private void EnableDisableStartStopBtn()
        {
            var appSetting = IsolatedStorageSettings.ApplicationSettings;
            if (appSetting.Contains(AppSetting.PREF_TRACKING) && appSetting[AppSetting.PREF_TRACKING].ToString() == "1")
            {
                StartTracking();
                BtnStart.IsEnabled = false;
                BtnStop.IsEnabled = true;
            }
            else
            {
                StopTracking();
                LatitudeTextBlock.Text = "-";
                LongitudeTextBlock.Text = "-";
                BtnStart.IsEnabled = true;
                BtnStop.IsEnabled = false;
            }

        }

        private void BtnImei_Click(object sender, RoutedEventArgs e) 
        {
            SetStartStop("0");
            DeviceConnect(Imei.Text);
        }

        private void SetStartStop(string status)
        {
            IsolatedStorageSettings.ApplicationSettings[AppSetting.PREF_TRACKING] = status;
            EnableDisableStartStopBtn();
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            SetStartStop("1");
        }

        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            SetStartStop("0");
        }
    }
}