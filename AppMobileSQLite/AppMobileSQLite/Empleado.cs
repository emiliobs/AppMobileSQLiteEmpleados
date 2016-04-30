﻿using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMobileSQLite
{
   public class Empleado
    {
        [PrimaryKey, AutoIncrement]
        public int IDEmpleado { get; set; }
        public string   Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaContrato { get; set; }
        public decimal Salario { get; set; }
        public bool Activo { get; set; }

        public override string ToString()
        {
            return ($"{IDEmpleado} {Nombres} {Apellidos} {FechaContrato} {Salario} {Activo}");
        }

    }
}
