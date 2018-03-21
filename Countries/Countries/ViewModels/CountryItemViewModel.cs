namespace Countries.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using System.Windows.Input;
    using Views;
    using Xamarin.Forms;

    public class CountryItemViewModel : Country
    {
        #region Commands
        public ICommand SelectCountryCommand { get { return new RelayCommand(SelectCountry); } }

        async void SelectCountry()
        {
            MainViewModel.GetInstance().Country = new CountryViewModel(this);
            await App.Navigator.PushAsync(new CountryTabbedPage());
        }
        #endregion
    }
}