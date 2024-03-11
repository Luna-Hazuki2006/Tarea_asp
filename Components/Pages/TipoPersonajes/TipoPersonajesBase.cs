using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Tarea_asp.Data.Models;
using Tarea_asp.Data.Services;
using Tarea_asp.Components.Shared;

namespace Tarea_asp.Components
{
    public class TipoPersonajesBase : ComponentBase
    {
        public TipoPersonaje tipoPersonaje = new();

        [Inject]
        public NavigationManager Navigation { get; set; }


        [Inject]
        TipoPersonajeService tipoPersonajeService { get; set; }
        public List<TipoPersonaje>? lstTipoPersonaje { get; set; }

        public bool ShowForm { get; set; }

        public Modal ModalDialog { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await GetAll();
        }

        public void Create()
        {
            ShowForm = true;
            Navigation.NavigateTo("/TipoPersonaje");
        }

        public void Read(TipoPersonaje tipo)
        {
            Navigation.NavigateTo("/TipoPersonaje");
        }

        public void Update(TipoPersonaje tipo)
        {
            ShowForm = true;

            tipoPersonaje = tipo;
        }

        public async void Delete(TipoPersonaje tipo)
        {
            var response = tipoPersonajeService.Delete(tipo);
            await GetAll();

        }

        public async Task GetAll()
        {
            var response = await tipoPersonajeService.GetAll();

            lstTipoPersonaje = response.Data;

        }

    }
}