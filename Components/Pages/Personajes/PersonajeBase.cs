using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Tarea_asp.Data.Models;
using Tarea_asp.Data.Services;

namespace Tarea_asp.Components
{
    public class PersonajeBase : ComponentBase
    {
        [Parameter]
        public EventCallback OnPersonajeCreado { get; set; }

        [Parameter]
        public Personaje personaje { get; set; }

        [Parameter]
        public EventCallback ActualizarLista { get; set; }

        [Inject]
        PersonajeService personajeService { get; set; }

        public Personaje model = new Personaje();

        protected override async Task OnInitializedAsync()
        {
            model = personaje;
        }


        public async Task Post()
        {
            var respuesta = await personajeService.Create(personaje);

            if (respuesta.Ok)
            {

                await OnPersonajeCreado.InvokeAsync();
                personaje = new();

            }
        }
    }
}