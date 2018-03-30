namespace Countries.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Helpers;
    using Models;
    using Services;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class CountriesViewModel : BaseViewModel
    {
        #region Services
        ApiService apiService;
        #endregion

        #region Attributes
        bool _isRefreshing;
        ObservableCollection<CountryItemViewModel> _countries;
        string _filter;
        #endregion

        #region Properties
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { SetValue(ref _isRefreshing, value); }
        }

        public ObservableCollection<CountryItemViewModel> Countries
        {
            get { return _countries; }
            set { SetValue(ref _countries, value); }
        }

        public string Filter
        {
            get { return _filter; }
            set { SetValue(ref _filter, value); Search(); }
        }
        #endregion

        #region Constructors
        public CountriesViewModel()
        {
            apiService = new ApiService();
            LoadCountries();
        }
        #endregion

        #region Methods
        async void LoadCountries()
        {
            IsRefreshing = true;

            var connection = await apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                IsRefreshing = false;

                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    connection.Message,
                    Languages.Accept);
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }

            var apiCountries = Application.Current.Resources["APICountries"].ToString();
            var response = await apiService.GetList<Country>(
                apiCountries,
                "/rest",
                "/v2/all");

            if (!response.IsSuccess)
            {
                IsRefreshing = false;

                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    response.Message,
                    Languages.Accept);
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }

            MainViewModel.GetInstance().CountryList = (List<Country>)response.Result;
            Countries = new ObservableCollection<CountryItemViewModel>(ToCountryItemViewModel());
            IsRefreshing = false;
        }

        private IEnumerable<CountryItemViewModel> ToCountryItemViewModel()
        {
            return MainViewModel.GetInstance().CountryList.Select(c => new CountryItemViewModel
            {
                Alpha2Code = c.Alpha2Code,
                Alpha3Code = c.Alpha3Code,
                AltSpellings = c.AltSpellings,
                Area = c.Area,
                Borders = c.Borders,
                CallingCodes = c.CallingCodes,
                Capital = c.Capital,
                Cioc = c.Cioc,
                Currencies = c.Currencies,
                Demonym = c.Demonym,
                Flag = c.Flag,
                Gini = c.Gini,
                Languages = c.Languages,
                Latlng = c.Latlng,
                Name = c.Name,
                NativeName = c.NativeName,
                NumericCode = c.NumericCode,
                Population = c.Population,
                Region = c.Region,
                RegionalBlocs = c.RegionalBlocs,
                Subregion = c.Subregion,
                Timezones = c.Timezones,
                TopLevelDomain = c.TopLevelDomain,
                Translations = c.Translations,
            });
        }
        #endregion

        #region Commands
        public ICommand RefreshCommand { get { return new RelayCommand(LoadCountries); } }

        public ICommand SearchCommand { get { return new RelayCommand(Search); } }

        void Search()
        {
            if (string.IsNullOrEmpty(Filter))
            {
                Countries = new ObservableCollection<CountryItemViewModel>(
                    ToCountryItemViewModel());
            }
            else
            {
                Countries = new ObservableCollection<CountryItemViewModel>(
                    ToCountryItemViewModel().Where(
                        l => l.Name.ToLower().Contains(Filter.ToLower()) ||
                             l.Capital.ToLower().Contains(Filter.ToLower())));
            }
        }
        #endregion
    }
}