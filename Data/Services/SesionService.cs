using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Tarea_asp.Data.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace Tarea_asp.Data.Services
{
    public class SesionService
    {
        public readonly ProtectedLocalStorage _protectedLocalStorage;
        public SesionService(ProtectedLocalStorage protectedLocal) {
            _protectedLocalStorage = protectedLocal;
        }

        public async Task<Response<Sesion>> IniciarSesion(Usuario usuario) {
            Response<Sesion> respuesta = new Response<Sesion>();
            try
            {
                respuesta = await Consumer.
                    Execute<Usuario, Sesion>(
                        $"https://localhost:7003/api/Sesion", 
                        MethodHttp.POST, 
                        usuario
                    );
                if (respuesta.Ok) await _protectedLocalStorage.SetAsync("token", respuesta.Data);
            }
            catch (Exception e)
            {
                throw e;
            }
            return respuesta;
        }

        public async void CerrarSesion(Sesion sesion) {
            Response<string> respuesta = new Response<string>();
            try
            {
                respuesta = await Consumer.
                    Execute<Sesion, string>(
                        $"https://localhost:7003/api/Sesion", 
                        MethodHttp.DELETE, 
                        sesion
                    );
                if (respuesta.Ok) await _protectedLocalStorage.DeleteAsync("token");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}