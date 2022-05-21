using System;
using System.Collections.Generic;
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
    public partial class Registrar : ContentPage
    {
        private SQLiteAsyncConnection con;

        public Registrar()
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();
        }

        private void bntAgregar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var Registros = new Estudiante { Nombre = txtNombre.Text, Usuario = txtUsuario.Text, Password = txtContrasenia.Text };
                con.InsertAsync(Registros);
                limpiarFormulario();
                DisplayAlert("Alerta", "Dato ingresado", "ok");

            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "ok");
            }
        }

        void limpiarFormulario()
        {
            txtNombre.Text = "";
            txtUsuario.Text = "";
            txtContrasenia.Text = "";
            
        }
    }
}