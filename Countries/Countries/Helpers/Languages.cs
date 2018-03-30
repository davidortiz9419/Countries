namespace Countries.Helpers
{
    using Xamarin.Forms;
    using Interfaces;
    using Resources;

    public static class Languages
    {
        static Languages()
        {
            var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }

        public static string Accept
        {
            get { return Resource.Accept; }
        }

        public static string AlphaCode2
        {
            get { return Resource.AlphaCode2; }
        }

        public static string AlphaCode3
        {
            get { return Resource.AlphaCode3; }
        }

        public static string Area
        {
            get { return Resource.Area; }
        }

        public static string Borders
        {
            get { return Resource.Borders; }
        }

        public static string Brazilian
        {
            get { return Resource.Brazilian; }
        }

        public static string Cancel
        {
            get { return Resource.Cancel; }
        }

        public static string Capital
        {
            get { return Resource.Capital; }
        }

        public static string ChagePasswordConfirm
        {
            get { return Resource.ChagePasswordConfirm; }
        }

        public static string ChangePassword
        {
            get { return Resource.ChangePassword; }
        }

        public static string CIOC
        {
            get { return Resource.CIOC; }
        }

        public static string Confirm
        {
            get { return Resource.Confirm; }
        }

        public static string Confirmation
        {
            get { return Resource.Confirmation; }
        }

        public static string ConfirmValidation
        {
            get { return Resource.ConfirmValidation; }
        }

        public static string ConfirmValidation2
        {
            get { return Resource.ConfirmValidation2; }
        }

        public static string ConnectionError1
        {
            get { return Resource.ConnectionError1; }
        }

        public static string ConnectionError2
        {
            get { return Resource.ConnectionError2; }
        }

        public static string Countries
        {
            get { return Resource.Countries; }
        }

        public static string Country
        {
            get { return Resource.Country; }
        }

        public static string Croatian
        {
            get { return Resource.Croatian; }
        }

        public static string Currencies
        {
            get { return Resource.Currencies; }
        }

        public static string CurrentPassword
        {
            get { return Resource.CurrentPassword; }
        }

        public static string Demonym
        {
            get { return Resource.Demonym; }
        }

        public static string Dutch
        {
            get { return Resource.Dutch; }
        }

        public static string Email
        {
            get { return Resource.Email; }
        }

        public static string EmailValidation
        {
            get { return Resource.EmailValidation; }
        }

        public static string EmailValidation2
        {
            get { return Resource.EmailValidation2; }
        }

        public static string Error
        {
            get { return Resource.Error; }
        }

        public static string FirstName
        {
            get { return Resource.FirstName; }
        }

        public static string FirstNameValidation
        {
            get { return Resource.FirstNameValidation; }
        }

        public static string Forgot
        {
            get { return Resource.Forgot; }
        }

        public static string French
        {
            get { return Resource.French; }
        }

        public static string FromCamera
        {
            get { return Resource.FromCamera; }
        }

        public static string FromGallery
        {
            get { return Resource.FromGallery; }
        }

        public static string German
        {
            get { return Resource.German; }
        }

        public static string GINI
        {
            get { return Resource.GINI; }
        }

        public static string IncorrectPassword
        {
            get { return Resource.IncorrectPassword; }
        }

        public static string Information
        {
            get { return Resource.Information; }
        }

        public static string Italian
        {
            get { return Resource.Italian; }
        }

        public static string Japanese
        {
            get { return Resource.Japanese; }
        }

        public static string LastName
        {
            get { return Resource.LastName; }
        }

        public static string LastNameValidation
        {
            get { return Resource.LastNameValidation; }
        }

        public static string Login
        {
            get { return Resource.Login; }
        }

        public static string LoginError
        {
            get { return Resource.LoginError; }
        }

        public static string Logout
        {
            get { return Resource.Logout; }
        }

        public static string Menu
        {
            get { return Resource.Menu; }
        }

        public static string MyLanguages
        {
            get { return Resource.MyLanguages; }
        }

        public static string MyProfile
        {
            get { return Resource.MyProfile; }
        }

        public static string NativeName
        {
            get { return Resource.NativeName; }
        }

        public static string NewPassword
        {
            get { return Resource.NewPassword; }
        }

        public static string NumericCode
        {
            get { return Resource.NumericCode; }
        }

        public static string Password
        {
            get { return Resource.Password; }
        }

        public static string PasswordValidation
        {
            get { return Resource.PasswordValidation; }
        }

        public static string PasswordValidation2
        {
            get { return Resource.PasswordValidation2; }
        }

        public static string Persian
        {
            get { return Resource.Persian; }
        }

        public static string Phone
        {
            get { return Resource.Phone; }
        }

        public static string PhoneValidation
        {
            get { return Resource.PhoneValidation; }
        }

        public static string Population
        {
            get { return Resource.Population; }
        }

        public static string Portuguese
        {
            get { return Resource.Portuguese; }
        }

        public static string Region
        {
            get { return Resource.Region; }
        }

        public static string Register
        {
            get { return Resource.Register; }
        }

        public static string RegisterTitle
        {
            get { return Resource.RegisterTitle; }
        }

        public static string Rememberme
        {
            get { return Resource.Rememberme; }
        }

        public static string Save
        {
            get { return Resource.Save; }
        }

        public static string Search
        {
            get { return Resource.Search; }
        }

        public static string SomethingWrong
        {
            get { return Resource.SomethingWrong; }
        }

        public static string SourceImageQuestion
        {
            get { return Resource.SourceImageQuestion; }
        }

        public static string Spanish
        {
            get { return Resource.Spanish; }
        }

        public static string Statistics
        {
            get { return Resource.Statistics; }
        }

        public static string Subregion
        {
            get { return Resource.Subregion; }
        }

        public static string Translations
        {
            get { return Resource.Translations; }
        }

        public static string UserRegisteredMessage
        {
            get { return Resource.UserRegisteredMessage; }
        }
    }
}