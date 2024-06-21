using SQLite;
using System.Diagnostics.CodeAnalysis;

namespace ProyectoFInal.Models
{
    public class Tareas
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Estatus { get; set; }

        
    }
}
