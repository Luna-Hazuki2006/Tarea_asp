using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tarea_asp.Data.Models
{
    public class Usuario
    {
        public string? Cedula {get; set;}
        public string? Nombres {get; set;}
        public string? Apellidos {get; set;}
        public string? Apodo {get; set;}
        public string? Correo {get; set;}
        public string? Contraseña {get; set;}
        public DateTime Nacimiento {get; set;}
        public string? Genero {get; set;}
    }
}