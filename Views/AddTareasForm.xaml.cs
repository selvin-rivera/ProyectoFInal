using ProyectoFInal.Models;
using ProyectoFInal.ViewModels;

namespace ProyectoFInal.Views;

public partial class AddTareasForm : ContentPage
{

    private TareasFormViewModel viewModel;
    public AddTareasForm()
    {
        InitializeComponent();
        viewModel = new TareasFormViewModel();
        BindingContext = viewModel;
    }

    public AddTareasForm(Tareas tareas)
    {
        InitializeComponent();
        viewModel = new TareasFormViewModel(tareas);
        BindingContext = viewModel;
    }
}