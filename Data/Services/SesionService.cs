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

        public async Task<Response<string>> IniciarSesion(Usuario usuario) {
            Response<string> respuesta = new Response<string>();
            try
            {
                respuesta = await Consumer.
                    Execute<Usuario, string>(
                        $"https://localhost:7082/api/Sesion/IniciarSesion", 
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

        public void CerrarSesion() {

        }
    }
}