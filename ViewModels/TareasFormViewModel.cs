
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProyectoFInal.Models;
using ProyectoFInal.Services;

namespace ProyectoFInal.ViewModels
{
    public partial class TareasFormViewModel : ObservableObject
    {
        [ObservableProperty]
        private int idProperty;

        [ObservableProperty]
        private string descripcionProperty;

        [ObservableProperty]
        private string estatusProperty;

 

        private readonly TareasService tareasService;

        public TareasFormViewModel()
        {
            tareasService = new TareasService();
        }

        public TareasFormViewModel(Tareas tareas)
        {
            IdProperty = tareas.Id;
            DescripcionProperty = tareas.Descripcion;
            EstatusProperty = tareas.Estatus;                   

            tareasService = new TareasService();
        }

        private void Alerta(String Titulo, String Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        [RelayCommand]
        private async Task AddUpdate()
        {
            try
            {
                Tareas tareas = new Tareas
                {
                    Id = idProperty,
                    Descripcion = descripcionProperty,
                    Estatus = estatusProperty
                    
                };

                if (Validar(tareas))
                {
                    if (IdProperty == 0)
                    {
                        tareasService.Insert(tareas);
                    }
                    else
                    {
                        tareasService.Update(tareas);
                    }
                    await App.Current!.MainPage!.Navigation.PopAsync();

                }


            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }

        private bool Validar(Tareas tareas)
        {
            if (tareas.Descripcion == null || tareas.Descripcion == "")
            {
                Alerta("ADVERTENCIA", "Ingrese la descripción de la tarea");
                return false;
            }
            else if (tareas.Estatus== null || tareas.Estatus=="" || tareas.Estatus!="En Progreso" && tareas.Estatus!="Finalizada" && tareas.Estatus != "Por Hacer") 
                {
                Alerta("ADVERTENCIA", "Ingrese un estatus aceptable");
                return false;
                }
            else
            {
                return true;
            }

        }
    }
}