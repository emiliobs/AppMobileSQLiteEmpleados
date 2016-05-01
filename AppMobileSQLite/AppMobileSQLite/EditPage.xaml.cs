using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AppMobileSQLite
{
    public partial class EditPage : ContentPage
    {
        private Empleado empleado;
        public EditPage(Empleado empleado)
        {
            InitializeComponent();
            this.empleado = empleado;

            borrarButton.Clicked += BorrarButton_Clicked;
            actualizarButton.Clicked += ActualizarButton_Clicked;

            nombresEntry.Text = empleado.Nombres;
            apellidosEntry.Text = empleado.Apellidos;
            salarioEntry.Text = empleado.Salario.ToString();
            fechaContratoDatePicker.Date = empleado.FechaContrato;
            activoSwitch.IsToggled = empleado.Activo;
     
        }

        private async void BorrarButton_Clicked(object sender, EventArgs e)
        {
            var rpt = await DisplayAlert("Confirmación","¿Desea Borrar el Empleado?","Si","No");

            if (!rpt)
            {
                return;
            }

            using (var datos = new DataAccess())
            {
                datos.DeleteEmpleado(empleado);
            }

            await DisplayAlert("Confirmación","Empleado Borrado","Aceptar");
            await Navigation.PushAsync(new HomePage());
        }  

        private async void ActualizarButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nombresEntry.Text))
            {
                await DisplayAlert("Error","Debe ingresar Nombres","Aceptar");
                nombresEntry.Focus();
                return;
            }

            if (string.IsNullOrEmpty(apellidosEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar Apellidos", "Aceptar");
                apellidosEntry.Focus();
                return;
            }

            if (string.IsNullOrEmpty(salarioEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar Salario", "Aceptar");
                salarioEntry.Focus();
                return;
            }

            //genero objeto empleado:
            Empleado empleado = new Empleado
            {
                   IDEmpleado = this.empleado.IDEmpleado,
                   Activo = activoSwitch.IsToggled,
                   Apellidos = apellidosEntry.Text,
                   Nombres = nombresEntry.Text,
                   Salario = decimal.Parse(salarioEntry.Text)
            };

            using (var datos = new DataAccess())
            {
                datos.UpdateEmpleado(empleado);
            }

            await DisplayAlert("Confirmación","Empleado Editado","Aceptar");
            await Navigation.PushAsync(new HomePage());
        }
    }
}
