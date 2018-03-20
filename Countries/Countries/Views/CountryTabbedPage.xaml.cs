namespace Countries.Views
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CountryTabbedPage : TabbedPage
	{
		public CountryTabbedPage ()
		{
			InitializeComponent ();
		}
	}
}