
using OrientationLayoutDemo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrientationLayoutDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomeView : ContentPage
	{
		public HomeView ()
		{
			InitializeComponent ();
            BindingContext = new HomeViewModel();
        }
	}
}