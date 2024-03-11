using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tarea_asp.Data.Models
{
    public class TipoPersonaje
    {
        public int Id {get; set;}
        public string? Nombre {get; set;}
        public string? Descripcion {get; set;}
    }
}