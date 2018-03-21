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

            IsToggled = true;
            IsEnabled = true;

            Email = "davidortiz0919@outlook.com";
            Password = "sys80.23";
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

            var token = await apiService.GetToken(
                "http://countriesapi.azurewebsites.net",
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
                    token.ErrorDescription,
                    Languages.Accept);
                Password = string.Empty;
                return;
            }

            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Token = token;
            mainViewModel.Countries = new CountriesViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new CountriesPage());

            IsRunning = false;
            IsEnabled = true;

            Email = string.Empty;
            Password = string.Empty;
        }
        #endregion
    }
}