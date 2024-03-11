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
    public class EnemigosBase : ComponentBase
    {
        public Enemigo enemigo = new();

        [Inject]
        public NavigationManager Navigation { get; set; }


        [Inject]
        EnemigoService enemigoService { get; set; }
        public List<Enemigo>? lstEnemigo { get; set; }

        public bool ShowForm { get; set; }

        public Modal ModalDialog { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await GetAll();
        }

        public void Create()
        {
            ShowForm = true;
            Navigation.NavigateTo("/Enemigo");
        }

        public void Read(Enemigo ene)
        {
            Navigation.NavigateTo("/Enemigo");
        }

        public void Update(Enemigo ene)
        {
            ShowForm = true;

            enemigo = ene;
        }

        public async void Delete(Enemigo ene)
        {
            var response = enemigoService.Delete(ene);
            await GetAll();

        }

        public async Task GetAll()
        {
            var response = await enemigoService.GetAll();

            lstEnemigo = response.Data;

        }
    }
}