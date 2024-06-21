
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using ProyectoFInal.Models;
using ProyectoFInal.Services;
using ProyectoFInal.Views;
using CommunityToolkit.Mvvm.Input;


namespace ProyectoFInal.ViewModels
{
    public partial class TareasMainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Tareas> tareasCollection = new ObservableCollection<Tareas>();

        private readonly TareasService tareasService;
        public TareasMainViewModel()
        {
            tareasService = new TareasService();
        }

        public void GetAll()
        {
            var getAll = tareasService.GetAll();

            if (getAll?.Count() > 0)
            {
                TareasCollection.Clear();
                foreach (var tareas in getAll)
                {
                    TareasCollection.Add(tareas);
                }

            }
        }

        [RelayCommand]
        private async Task goToAddTareasForm()
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new AddTareasForm());
        }

        [RelayCommand]
        private async Task SelectTareas(Tareas tareas)
        {
            try
            {
                string res = await App.Current!.MainPage!.DisplayActionSheet("Opciones", "Cancelar", null, "Actualizar", "Eliminar");
                switch (res)
                {
                    case "Actualizar":
                        await App.Current!.MainPage.Navigation.PushAsync(new AddTareasForm(tareas));
                        break;
                    case "Eliminar":
                        bool respuesta = await App.Current!.MainPage!.DisplayAlert("Eliminar Tareas", "¿Desea eliminar Tarea?", "Si", "No");
                        if (respuesta)
                        {
                            int del = tareasService.Delete(tareas);
                            if (del > 0)
                            {
                                TareasCollection.Remove(tareas);

                            }
                        }

                        break;
                }

            }
            catch (Exception ex)
            {
                Alerta("Error", ex.Message);
            }
        }
        private void Alerta(String Titulo, String Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }
    }
}
