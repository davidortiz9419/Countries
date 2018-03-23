﻿namespace Countries.ViewModels
{
    using Helpers;
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Views;
    using Xamarin.Forms;

    public class MenuItemViewModel
    {
        #region Properties
        public string Icon { get; set; }

        public string Title { get; set; }

        public string PageName { get; set; }
        #endregion

        #region Commands
        public ICommand NavigationCommand { get { return new RelayCommand(Navigation); }  }

        void Navigation()
        {
            App.Master.IsPresented = false;

            if (PageName == "LoginPage")
            {
                Settings.Token = string.Empty;
                Settings.TokenType = string.Empty;
                var mainViewModel = MainViewModel.GetInstance();
                mainViewModel.Token = string.Empty;
                mainViewModel.TokenType = string.Empty;
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
        }
        #endregion
    }
}