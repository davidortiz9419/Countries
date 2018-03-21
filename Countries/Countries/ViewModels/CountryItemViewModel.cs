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
        public ICommand SelectLandCommand { get { return new RelayCommand(SelectLand); } }

        async void SelectLand()
        {
            MainViewModel.GetInstance().Country = new CountryViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new CountryTabbedPage());
        }
        #endregion
    }
}