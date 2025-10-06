using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto1.CapaDatos
{
    public class MensajeRepositorio
    {
        private static List<Mensaje> mensajes = new List<Mensaje>();

        public static int contadorId = 1;

        public void Insertar(Mensaje mensaje) // para insertar un alumno a la lista 
        {
            mensaje.Id = contadorId++; //asigna un id unico y incrementa el contador
            mensaje.FechaHora =DateTime.Now;
            mensajes.Add(mensaje);   //agrega el nuevo mensaje a la lista
        }
        public List<Mensaje> ObtenerTodos() //read devolver los alumnos de la lista
        {
            return mensajes;
        }
        public void Actualizar(int id, string alias, string nuevoTexto)//actualiza los datos de un estudiante existente
        {
            var existente = mensajes.FirstOrDefault(a => a.Id == id && a.Alias == alias );//busca el alumno con el id unico que tiene 

            if (existente != null )//si lo encuentra actualiza los datos 
            {
                existente.Texto = nuevoTexto;
                existente.Editado = true;
                existente.FechaEditado = DateTime.Now;
            }
        }
        public void Eliminar(int id, string alias) //funcion para eliminar un alumno de la lista 
        {
            var mensaje = mensajes.FirstOrDefault(a => a.Id == id && a.Alias == alias);//busca por id el alumno 

            if (mensaje != null)//si lo encuentra lo mata (borra)
            {
                mensajes.Remove(mensaje);
            }
        }
    }
}