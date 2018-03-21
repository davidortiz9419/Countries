namespace Countries.ViewModels
{
    using Models;
    using System.Collections.Generic;

    public class MainViewModel
    {
        #region Properties
        public List<Country> CountryList { get; set; }

        public TokenResponse Token { get; set; }
        #endregion

        #region ViewModels
        public CountryViewModel Country { get; set; }

        public CountriesViewModel Countries { get; set; }

        public LoginViewModel Login { get; set; }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;
            Login = new LoginViewModel();
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
    }
}