using ProyectoFInal.Views;

namespace ProyectoFInal
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TareasMain());
        }
    }
}
