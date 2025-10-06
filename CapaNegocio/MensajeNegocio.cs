using Proyecto1.CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto1.CapaNegocio
{
    public class MensajeNegocio
    {
        private MensajeRepositorio repo =new MensajeRepositorio();

        public List<Mensaje> Listar()
        {
            return repo.ObtenerTodos();
        }
        public void Agregar(Mensaje mensaje)
        {
            repo.Insertar(mensaje);
        }
        public void Actualizar(int id, string alias, string nuevoTexto)
        {
            repo.Actualizar(id,alias, nuevoTexto);
        }
        public void Eliminar(int id, string alias)
        {
            repo.Eliminar(id, alias);
        }
    }
}