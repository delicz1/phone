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

namespace PhoneMobileTracker
{
    public partial class Page2 : PhoneApplicationPage
    {
        public Page2()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
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
            Dispatcher.BeginInvoke(() =>
                {
                    string name = e.Result.ToString();
                    MessageBox.Show(name);
                });
        }

        void geolocator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            string latString = args.Position.Coordinate.Latitude.ToString("0.000000");
            string lngString = args.Position.Coordinate.Longitude.ToString("0.000000");
            float lat = float.Parse(latString, CultureInfo.InvariantCulture.NumberFormat);
            float lng = float.Parse(lngString, CultureInfo.InvariantCulture.NumberFormat);

            DateTime dateTime = DateTime.UtcNow;
            int timestamp = (int) (dateTime - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds;
            WcfMobileTracker.ServiceClient client = new WcfMobileTracker.ServiceClient();
            client.WriteGpsAsync("admin", "123456", "123456", (int) timestamp, lat, lng);
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
            else
            {
                Microsoft.Phone.Shell.ShellToast toast = new Microsoft.Phone.Shell.ShellToast();
                toast.Content = args.Position.Coordinate.Latitude.ToString("0.00");
                toast.Title = "Location: ";
                toast.NavigationUri = new Uri("/Page2.xaml", UriKind.Relative);
                toast.Show();

            }


        }
    }
}