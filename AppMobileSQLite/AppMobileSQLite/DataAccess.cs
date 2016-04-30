using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using SQLite.Net;
using Xamarin.Forms;
using System.IO;

namespace AppMobileSQLite
{
    public class DataAccess : IDisposable
    {

        private SQLiteConnection Con;
        public DataAccess ()
        {
            var config = DependencyService.Get<IConfig>();
            Con = new SQLiteConnection(config.Plataforma, Path.Combine(config.DirectorioDB, "Empleados.db3"));
            //crea la tabla basada en la clase empleados: y si ya esta creda no vuelve a crearla:
            Con.CreateTable<Empleado>();
        }

        public void InsertEmpleado(Empleado empleado)
        {
            Con.Insert(empleado);
        }

        public void UpdateEmpleado(Empleado empleado)
        {
            Con.Update(empleado);
        }

        public void DeleteEmpleado(Empleado empleado)
        {
            Con.Delete(empleado);
        }

        //retorna un solo empleado:
        public Empleado GetEmpleado(int IDEmpleado)
        {
            return Con.Table<Empleado>().FirstOrDefault(c => c.IDEmpleado == IDEmpleado);
        }

        //Método, me devuelve varios empleados:
        public List<Empleado> GetEmpleados()
        {
            return Con.Table<Empleado>().OrderBy(c => c.Apellidos).ToList();
        }
        public void Dispose()
        {
            Con.Dispose();
        }
    }
}
