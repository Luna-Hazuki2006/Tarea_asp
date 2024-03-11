using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tarea_asp.Data.Models
{
    public class Enemigo
    {
        public int Id {get; set;}
        public string? Nombre {get; set;}
        public int Nivel_Amenaza {get; set;}
        public double Vida {get; set;}
        //public List<string>? Recompensas {get; set;}
        //public List<string>? Habilidades {get; set;}
    }
}