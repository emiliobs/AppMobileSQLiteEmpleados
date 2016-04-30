using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AppMobileSQLite
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            agregarButton.Clicked += AgregarButton_Clicked;

            using (var datos = new DataAccess())
            {
                listaListView.ItemsSource = datos.GetEmpleados();
            }
        }

        private async void AgregarButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nombresEntry.Text))
            {
                await DisplayAlert("ERROR:","Debe ingresar Nombres.","Aceptar");
                nombresEntry.Focus();
                return;
            }

            if (string.IsNullOrEmpty(apellidosEntry.Text))
            {
                await DisplayAlert("ERROR:", "Debe ingresar Apellidos.", "Aceptar");
                apellidosEntry.Focus();
                return;
            }

            if (string.IsNullOrEmpty(salarioEntry.Text))
            {
                await DisplayAlert("ERROR:", "Debe ingresar Salario.", "Aceptar");
                salarioEntry.Focus();
                return;
            }

            //dela clase empleado creo un objeto empleado:
            Empleado empleado = new Empleado
            {
                Activo = activoSwitch.IsToggled,
                Apellidos = apellidosEntry.Text,
                FechaContrato = fechaContratoDatePicker.Date,
                Nombres = nombresEntry.Text,
                Salario = decimal.Parse(salarioEntry.Text)
            };

            //inserto el empleado a la base dedatos:
            using (var datos = new DataAccess())
            {
                datos.InsertEmpleado(empleado);
                listaListView.ItemsSource = datos.GetEmpleados();
            }

            apellidosEntry.Text = string.Empty;
            nombresEntry.Text = string.Empty;
            fechaContratoDatePicker.Date = DateTime.Now;
            salarioEntry.Text = string.Empty;
            

            await DisplayAlert("Mensaje","Empelado Creado Corectamenete","Aceptar");

            nombresEntry.Focus();
        }
    }
}
