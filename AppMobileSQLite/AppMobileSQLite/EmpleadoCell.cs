using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppMobileSQLite
{
    public class EmpleadoCell : ViewCell
    {
       public EmpleadoCell()
        {
            var IDEmpleadoLabel = new Label
            {
                TextColor = Color.White,
                FontFamily = Font.SystemFontOfSize(12, FontAttributes.Bold).ToString(),
                HorizontalOptions = LayoutOptions.Start
            };

            IDEmpleadoLabel.SetBinding(Label.TextProperty, new Binding("IDEmpleado"));

            var Nombrelabel = new Label
            {
                TextColor = Color.White,
                FontFamily = Font.SystemFontOfSize(12, FontAttributes.Bold).ToString(),
                HorizontalOptions = LayoutOptions.Fill
            };

            Nombrelabel.SetBinding(Label.TextProperty, new Binding("Nombres"));

            var Apellidoslabel = new Label
            {
                TextColor = Color.White,
                FontFamily = Font.SystemFontOfSize(15, FontAttributes.Bold).ToString(),
                HorizontalOptions = LayoutOptions.Fill
            };

            Apellidoslabel.SetBinding(Label.TextProperty, new Binding("Apellidos"));

            var Salariolabel = new Label
            {
                TextColor = Color.White,
                FontFamily = Font.SystemFontOfSize(15, FontAttributes.Bold).ToString(),
                HorizontalOptions = LayoutOptions.Fill
            };

            Salariolabel.SetBinding(Label.TextProperty, new Binding("Salario"));

            var FechaContractolabel = new Label
            {
                TextColor = Color.White,
                FontFamily = Font.SystemFontOfSize(15, FontAttributes.Bold).ToString(),
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            FechaContractolabel.SetBinding(Label.TextProperty, new Binding("FechaContrato"));

            var ActivoSwich = new Switch
            {
                IsEnabled=false,
                HorizontalOptions = LayoutOptions.End
            };
            ActivoSwich.SetBinding(Switch.IsToggledProperty, new Binding("Activo"));

            var panel1 = new StackLayout
            {
             Children = { IDEmpleadoLabel, Nombrelabel,Apellidoslabel,Salariolabel,FechaContractolabel } ,
             Orientation = StackOrientation.Horizontal
            };

            var panel2 = new StackLayout
            {
                Children = { ActivoSwich }
                //Orientation = StackOrientation.Horizontal
            };


            View = new StackLayout
            {
                  Children = { panel1, panel2  },
                  Orientation = StackOrientation.Horizontal                 
            };


        }
    }
}
