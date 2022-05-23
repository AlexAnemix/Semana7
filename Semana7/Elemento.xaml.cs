using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Semana7.Models;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Semana7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {
        private SQLiteAsyncConnection con;
        IEnumerable<Estudiante> Delete1;
        IEnumerable<Estudiante> Update1;
        public int idSeleccionado;
        public Elemento(int id)
        {
            InitializeComponent();
            idSeleccionado = id;
        }

        public static IEnumerable<Estudiante> Delete(SQLiteConnection db, int id)
        {
            return db.Query<Estudiante>("DELETE FROM Estudiante where Id = ?", id);
        }

        public static IEnumerable<Estudiante> Update(SQLiteConnection db, string nombre, string usuario, string contrasenia, int id)
        {
            return db.Query<Estudiante>("UPDATE Estudiante SET Nombre =?, Usuario=?, Password =? where Id =?", nombre, usuario, contrasenia, id);
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "semana7.db3");
                var db = new SQLiteConnection(databasePath);
                Delete1 = Update(db, txtNombre.Text, txtUsuario.Text, txtContrasenia.Text, idSeleccionado);
                DisplayAlert("Alerta", "Se actualizo correctamente", "ok");
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", "ERROR" + ex.Message, "ok");
            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "semana7.db3");
                var db = new SQLiteConnection(databasePath);
                Delete1 = Delete(db, idSeleccionado);
                DisplayAlert("Alerta", "Se elimino correctamente", "ok");
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", "ERROR" + ex.Message, "ok");
            }
        }
    }
}