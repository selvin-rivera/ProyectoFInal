using ProyectoFInal.ViewModels;

namespace ProyectoFInal.Views;

public partial class TareasMain : ContentPage
{
    public TareasMainViewModel viewModel;

    public TareasMain()
    {
        InitializeComponent();
        viewModel = new TareasMainViewModel();
        this.BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.GetAll();
    }
}