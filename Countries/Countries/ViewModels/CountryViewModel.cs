namespace Countries.ViewModels
{
    using Models;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class CountryViewModel : BaseViewModel
    {
        #region Attributes
        ObservableCollection<Border> _borders;
        ObservableCollection<Currency> _currencies;
        ObservableCollection<Language> _languages;
        #endregion

        #region Properties
        public Country Country { get; set; }

        public ObservableCollection<Border> Borders
        {
            get { return _borders; }
            set { SetValue(ref _borders, value); }
        }

        public ObservableCollection<Currency> Currencies
        {
            get { return _currencies; }
            set { SetValue(ref _currencies, value); }
        }

        public ObservableCollection<Language> Languages
        {
            get { return _languages; }
            set { SetValue(ref _languages, value); }
        }
        #endregion

        #region Constructors
        public CountryViewModel(Country country)
        {
            Country = country;
            LoadBorders();
            Currencies = new ObservableCollection<Currency>(country.Currencies);
            Languages = new ObservableCollection<Language>(country.Languages);
        }
        #endregion

        #region Methods
        void LoadBorders()
        {
            Borders = new ObservableCollection<Border>();
            foreach (var border in Country.Borders)
            {
                var country = MainViewModel.GetInstance().CountryList
                    .Where(c => c.Alpha3Code == border)
                    .FirstOrDefault();

                if (country != null)
                {
                    Borders.Add(new Border
                    {
                        Code = country.Alpha3Code,
                        Name = country.Name,
                    });
                }
            }
        }
        #endregion
    }
}