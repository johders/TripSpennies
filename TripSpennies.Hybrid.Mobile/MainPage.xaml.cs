namespace TripSpennies.Hybrid.Mobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage(AppViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
