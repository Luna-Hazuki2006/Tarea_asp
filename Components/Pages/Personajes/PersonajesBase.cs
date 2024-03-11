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
    public class PersonajesBase : ComponentBase
    {
        public Personaje personaje = new();

        [Inject]
        public NavigationManager Navigation { get; set; }


        [Inject]
        PersonajeService personajeService { get; set; }
        [Inject]
        public string Valor {get; set;}
        public List<Personaje>? lstPersonaje { get; set; }

        public bool ShowForm { get; set; }

        public Modal ModalDialog { get; set; }
        public Tarea_asp.Components.Pages.Personajes.Personaje personajecomponente { get; set; }


        protected override async Task OnInitializedAsync()
        {
            await GetAll();
            Personaje personaje = personajecomponente.personaje;
            Valor = personaje.ToString();
        }

        public void Create()
        {
            ShowForm = true;
            Navigation.NavigateTo("/Personaje");
        }

        public void Read(Personaje per)
        {
            Navigation.NavigateTo("/Personaje");
        }

        public void Update(Personaje per)
        {
            ShowForm = true;

            personaje = per;
        }

        public async void Delete(Personaje per)
        {
            var response = personajeService.Delete(per);
            await GetAll();

        }

        public async Task GetAll()
        {
            var response = await personajeService.GetAll();

            lstPersonaje = response.Data;

        }
    }
}