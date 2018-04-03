namespace Countries
{
    using Helpers;
    using Models;
    using Services;
    using System;
    using System.Threading.Tasks;
    using ViewModels;
    using Views;
    using Xamarin.Forms;

    public partial class App : Application
	{
        #region Properties
        public static NavigationPage Navigator { get; internal set; }
        public static MasterPage Master { get; internal set; }
        #endregion

        #region Constructors
        public App()
        {
            InitializeComponent();

            if (Settings.IsRemembered == "true")
            {
                var dataService = new DataService();
                var token = dataService.First<TokenResponse>(false);

                if (token != null && token.Expires > DateTime.Now)
                {
                    var user = dataService.First<UserLocal>(false);
                    var mainViewModel = MainViewModel.GetInstance();
                    mainViewModel.Token = token;
                    mainViewModel.User = user;
                    mainViewModel.Countries = new CountriesViewModel();
                    Current.MainPage = new MasterPage();
                }
                else
                {
                    this.MainPage = new NavigationPage(new LoginPage());
                }
            }
            else
            {
                this.MainPage = new NavigationPage(new LoginPage());
            }
        }
        #endregion

        #region Methods
        public static Action HideLoginView
        {
            get
            {
                return new Action(() => Current.MainPage =
                                  new NavigationPage(new LoginPage()));
            }
        }

        public static async Task NavigateToProfile(Models.FacebookResponse profile)
        {
            if (profile == null)
            {
                Current.MainPage = new NavigationPage(new LoginPage());
                return;
            }

            var apiService = new ApiService();
            var dataService = new DataService();

            var apiSecurity = Current.Resources["APISecurity"].ToString();
            var token = await apiService.LoginFacebook(
                apiSecurity,
                "/api",
                "/Users/LoginFacebook",
                profile);

            if (token == null)
            {
                Current.MainPage = new NavigationPage(new LoginPage());
                return;
            }

            var user = await apiService.GetUserByEmail(
                apiSecurity,
                "/api",
                "/Users/GetUserByEmail",
                token.TokenType,
                token.AccessToken,
                token.UserName);

            UserLocal userLocal = null;
            if (user != null)
            {
                userLocal = Converter.ToUserLocal(user);
                dataService.DeleteAllAndInsert(userLocal);
            }

            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Token = token;
            mainViewModel.User = userLocal;
            mainViewModel.Countries = new CountriesViewModel();
            Current.MainPage = new MasterPage();
            Settings.IsRemembered = "true";

            mainViewModel.Countries = new CountriesViewModel();
            Current.MainPage = new MasterPage();
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        } 
        #endregion
    }
}