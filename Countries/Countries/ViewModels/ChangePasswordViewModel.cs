namespace Countries.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Helpers;
    using Models;
    using Services;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class ChangePasswordViewModel : BaseViewModel
    {
        #region Services
        ApiService apiService;
        DataService dataService;
        #endregion

        #region Attributes
        bool _isEnabled;
        bool _isRunning;
        #endregion

        #region Properties
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { SetValue(ref _isEnabled, value); }
        }

        public bool IsRunning
        {
            get { return _isRunning; }
            set { SetValue(ref _isRunning, value); }
        }

        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }

        public string Confirm { get; set; }
        #endregion

        #region Constructors
        public ChangePasswordViewModel()
        {
            apiService = new ApiService();
            dataService = new DataService();

            IsEnabled = true;
        }
        #endregion

        #region Commands
        public ICommand ChangePasswordCommand { get { return new RelayCommand(ChangePassword); } }

        async void ChangePassword()
        {
            if (string.IsNullOrEmpty(CurrentPassword))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.PasswordValidation,
                    Languages.Accept);
                return;
            }

            if (CurrentPassword.Length < 6)
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.PasswordValidation2,
                    Languages.Accept);
                return;
            }

            if (CurrentPassword != MainViewModel.GetInstance().User.Password)
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.PasswordError,
                    Languages.Accept);
                return;
            }

            if (string.IsNullOrEmpty(NewPassword))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.PasswordValidation,
                    Languages.Accept);
                return;
            }

            if (NewPassword.Length < 6)
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.PasswordValidation2,
                    Languages.Accept);
                return;
            }

            if (string.IsNullOrEmpty(Confirm))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.ConfirmValidation,
                    Languages.Accept);
                return;
            }

            if (NewPassword != Confirm)
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.ConfirmValidation2,
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

            var request = new ChangePasswordRequest
            {
                CurrentPassword = CurrentPassword,
                Email = MainViewModel.GetInstance().User.Email,
                NewPassword = NewPassword,
            };

            var apiSecurity = Application.Current.Resources["APISecurity"].ToString();
            var response = await apiService.ChangePassword(
                apiSecurity,
                "/api",
                "/Users/ChangePassword",
                MainViewModel.GetInstance().Token.TokenType,
                MainViewModel.GetInstance().Token.AccessToken,
                request);

            if (!response.IsSuccess)
            {
                IsRunning = false;
                IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.ErrorChangingPassword,
                    Languages.Accept);
                return;
            }

            MainViewModel.GetInstance().User.Password = NewPassword;
            dataService.Update(MainViewModel.GetInstance().User);

            IsRunning = false;
            IsEnabled = true;

            await Application.Current.MainPage.DisplayAlert(
                Languages.Confirmation,
                Languages.ChagePasswordConfirm,
                Languages.Accept);
            await App.Navigator.PopAsync();
        }
        #endregion
    }
}