using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Tarea_asp.Data.Models;
using Tarea_asp.Data.Services;

namespace Tarea_asp.Components
{
    public class TipoPersonajeBase : ComponentBase
    {
        [Parameter]
        public EventCallback OnTipoPersonajeCreado { get; set; }

        [Parameter]
        public TipoPersonaje tipoPersonaje { get; set; }

        [Parameter]
        public EventCallback ActualizarLista { get; set; }

        [Inject]
        TipoPersonajeService TipoPersonajeService { get; set; }

        public TipoPersonaje model = new TipoPersonaje();

        protected override async Task OnInitializedAsync()
        {
            model = tipoPersonaje;
        }


        public async Task Post()
        {
            var respuesta = await TipoPersonajeService.Create(tipoPersonaje);

            if (respuesta.Ok)
            {

                await OnTipoPersonajeCreado.InvokeAsync();
                tipoPersonaje = new();

            }
            else
            {
                //mensaje = respuesta.Message;
            }
        }
    }
}