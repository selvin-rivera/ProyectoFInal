
using ProyectoFInal.Models;
using SQLite;

namespace ProyectoFInal.Services
{
    public class TareasService
    {
        private readonly SQLiteConnection dbConnection;
        public TareasService()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Tareas.db3");
            dbConnection = new SQLiteConnection(dbPath);
            dbConnection.CreateTable<Tareas>();

        }

        public List<Tareas> GetAll()
        {
            var res = dbConnection.Table<Tareas>().ToList();
            return res;
        }

        public int Insert(Tareas tareas)
        {
            return dbConnection.Insert(tareas);
        }

        public int Update(Tareas tareas)
        {
            return dbConnection.Update(tareas);
        }
        public int Delete(Tareas tareas)
        {
            return dbConnection.Delete(tareas);
        }
    }
}
