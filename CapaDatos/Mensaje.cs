using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto1.CapaDatos
{
    public class Mensaje
    {
        public int Id { get; set; }
        public string Alias { get; set; }

        public DateTime FechaHora { get; set; }

        public bool Editado { get; set; }

        public DateTime? FechaEditado { get; set; }
    }
}