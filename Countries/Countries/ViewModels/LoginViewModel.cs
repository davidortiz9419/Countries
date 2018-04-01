namespace Countries.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Helpers;
    using Services;
    using System.Windows.Input;
    using Views;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {
        #region Services
        ApiService apiService;
        DataService dataService;
        #endregion

        #region Attributes
        bool _isEnable;
        bool _isRunning;
        bool _isToggled;
        string _email;
        string _password;
        #endregion

        #region Properties
        public bool IsEnabled
        {
            get { return _isEnable; }
            set { SetValue(ref _isEnable, value); }
        }

        public bool IsRunning
        {
            get { return _isRunning; }
            set { SetValue(ref _isRunning, value); }
        }

        public bool IsToggled
        {
            get { return _isToggled; }
            set { SetValue(ref _isToggled, value); }
        }

        public string Email
        {
            get { return _email; }
            set { SetValue(ref _email, value); }
        }

        public string Password
        {
            get { return _password; }
            set { SetValue(ref _password, value); }
        }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            apiService = new ApiService();
            dataService = new DataService();

            IsToggled = true;
            IsEnabled = true;
        }
        #endregion

        #region Commands
        public ICommand LoginCommand { get { return new RelayCommand(Login); } }

        async void Login()
        {
            if (string.IsNullOrEmpty(Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.EmailValidation,
                    Languages.Accept);
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.PasswordValidation,
                    Languages.Accept);
                return;
            }

            IsRunning = true;
            IsEnabled = false;

            var connection = await apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                IsRunning = false;
                IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    connection.Message,
                    Languages.Accept);
                return;
            }
            var apiSecurity = Application.Current.Resources["APISecurity"].ToString();
            var token = await apiService.GetToken(
                apiSecurity,
                Email,
                Password);

            if (token == null)
            {
                IsRunning = false;
                IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.SomethingWrong,
                    Languages.Accept);
                return;
            }

            if (string.IsNullOrEmpty(token.AccessToken))
            {
                IsRunning = false;
                IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.LoginError,
                    Languages.Accept);
                Password = string.Empty;
                return;
            }

            var user = await apiService.GetUserByEmail(
                apiSecurity,
                "/api",
                "/Users/GetUserByEmail",
                token.TokenType,
                token.AccessToken,
                Email);

            var userLocal = Converter.ToUserLocal(user);
            userLocal.Password = Password;

            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Token = token;
            mainViewModel.User = userLocal;

            if (IsToggled)
            {
                Settings.IsRemembered = "true";
            }
            else
            {
                Settings.IsRemembered = "false";
            }

            dataService.DeleteAllAndInsert(userLocal);
            dataService.DeleteAllAndInsert(token);

            mainViewModel.Countries = new CountriesViewModel();
            Application.Current.MainPage = new MasterPage();

            IsRunning = false;
            IsEnabled = true;

            Email = string.Empty;
            Password = string.Empty;
        }

        public ICommand RegisterCommand { get { return new RelayCommand(Register); } }

        async void Register()
        {
            MainViewModel.GetInstance().Register = new RegisterViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }
        #endregion
    }
}