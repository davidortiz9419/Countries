namespace Countries.ViewModels
{
    using Helpers;
    using Models;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class MainViewModel : BaseViewModel
    {
        #region Attributes
        UserLocal _user;
        #endregion

        #region Properties
        public List<Country> CountryList { get; set; }

        public TokenResponse Token { get; set; }

        public string TokenType { get; set; }

        public ObservableCollection<MenuItemViewModel> Menus { get; set; }

        public UserLocal User
        {
            get { return _user; }
            set { SetValue(ref _user, value); }
        }
        #endregion

        #region ViewModels
        public CountryViewModel Country { get; set; }

        public CountriesViewModel Countries { get; set; }

        public LoginViewModel Login { get; set; }

        public RegisterViewModel Register { get; set; }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;
            Login = new LoginViewModel();
            LoadMenu();
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
        #endregion

        #region Methods
        void LoadMenu()
        {
            Menus = new ObservableCollection<MenuItemViewModel>();
            Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_settings",
                PageName = "MyProfilePage",
                Title = Languages.MyProfile,
            });

            Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_graph",
                PageName = "StatisticsPage",
                Title = Languages.Statistics,
            });

            Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_exit",
                PageName = "LoginPage",
                Title = Languages.Logout,
            });
        }
        #endregion
    }
}