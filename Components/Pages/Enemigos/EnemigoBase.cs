using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Tarea_asp.Data.Models;
using Tarea_asp.Data.Services;

namespace Tarea_asp.Components
{
    public class EnemigoBase : ComponentBase
    {
        [Parameter]
        public EventCallback OnEnemigoCreado { get; set; }

        [Parameter]
        public Enemigo enemigo { get; set; }

        [Parameter]
        public EventCallback ActualizarLista { get; set; }

        [Inject]
        EnemigoService enemigoService { get; set; }

        public Enemigo model = new Enemigo();

        protected override async Task OnInitializedAsync()
        {
            model = enemigo;
        }


        public async Task Post()
        {
            var respuesta = await enemigoService.Create(enemigo);

            if (respuesta.Ok)
            {

                await OnEnemigoCreado.InvokeAsync();
                enemigo = new();

            }
        }
    }
}