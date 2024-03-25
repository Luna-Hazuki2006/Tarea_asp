using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Tarea_asp.Data.Models;
using Tarea_asp.Data.Services;

namespace Tarea_asp.Components
{
    public class UsuarioBase : ComponentBase
    {
        [Inject]
        public NavigationManager Navigation { get; set; }
        [Inject]
        public UsuarioService usuarioService { get; set; }
        public Usuario usuario = new();
        public string mensaje = "";
        public async Task Modificar()
        {
            mensaje = "";
            Response<Usuario> respuesta = await usuarioService.Modificar(usuario);
            if (respuesta.Ok) Navigation.NavigateTo("/", forceLoad: true);
            else mensaje = respuesta.Message;
        }
    }
}