﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
using PhoneMobileTracker.Resources;

namespace PhoneMobileTracker
{
    public partial class LoginPage : PhoneApplicationPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Loaded += LoginPage_Loaded;
        }

        void LoginPage_Loaded(object sender, RoutedEventArgs e) {
            if (IsolatedStorageSettings.ApplicationSettings.Contains(AppSetting.PREF_USER_NAME)) {
                Login(IsolatedStorageSettings.ApplicationSettings[AppSetting.PREF_USER_NAME].ToString(), 
                    IsolatedStorageSettings.ApplicationSettings[AppSetting.PREF_USER_PASSWORD].ToString());
            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e) {
            NavigationService.RemoveBackEntry();
        }


        private void Login(string userName, string userPass) {

            LoginBtn.IsEnabled = false;

            var progress = new ProgressIndicator {
                IsVisible = true,
                IsIndeterminate = true,
                Text = AppResources.TitleLoading
            };

            SystemTray.SetProgressIndicator(this, progress);

            var client = new WcfMobileTracker.ServiceClient();
            client.UserExistAsync(userName, userPass);
            client.UserExistCompleted += userExist_response;
            client.CloseAsync();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            string error = "";
            string userName = UserName.Text;
            string userPass = UserPassword.Password;

            if(userName.Count() < 4) {
                error = AppResources.ShortUserName;
            }
            if(userPass.Count() < 5) {
                error = AppResources.ShortPassword;
            }

            if(!error.Any()) {
                IsolatedStorageSettings.ApplicationSettings[AppSetting.PREF_USER_NAME] = userName;
                IsolatedStorageSettings.ApplicationSettings.Add(AppSetting.PREF_USER_PASSWORD, userPass);
                Login(userName, userPass);
            } else {
                MessageBox.Show(error);
            }

        }

        private void userExist_response(object sender, WcfMobileTracker.UserExistCompletedEventArgs e) {
            if (e.Result) {
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            } else {
                if (IsolatedStorageSettings.ApplicationSettings.Contains(AppSetting.PREF_USER_NAME)) {
                    IsolatedStorageSettings.ApplicationSettings.Remove(AppSetting.PREF_USER_NAME);
                    IsolatedStorageSettings.ApplicationSettings.Remove(AppSetting.PREF_USER_NAME);
                    IsolatedStorageSettings.ApplicationSettings.Remove(AppSetting.PREF_USER_PASSWORD);
                }
                LoginBtn.IsEnabled = true;
                SystemTray.SetProgressIndicator(this, null);
                MessageBox.Show(AppResources.LoginError);
            }
        }
    }
}