using System.Diagnostics;

namespace MAUIFolderFocker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new ContentPage
            {
                Content = new Label
                {
                    Text = "HELLO",
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center
                }
            };

        }


        protected override Window CreateWindow(IActivationState? activationState)
        {
            Debug.WriteLine("CreateWindow wywołane");
            return new Window(new MainPage()) { Title = "MAUIFolderFocker" };
        }
    }
}
