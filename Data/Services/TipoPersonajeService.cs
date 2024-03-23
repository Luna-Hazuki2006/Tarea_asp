using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarea_asp.Data.Models;
using Tarea_asp.Data;
using Newtonsoft.Json;
using System.Text;
using Tarea_asp.Components.Pages.Personajes;

namespace Tarea_asp.Data.Services
{
    public class TipoPersonajeService
    {
        public async Task<Response<string>> Create(TipoPersonaje tipo) {
            Response<string> response = new Response<string>();
            try
            {
                response.Message = (await
                    Consumer.Execute<TipoPersonaje, TipoPersonaje>(
                        "https://localhost:7128/api/Tipo_Personaje",
                        MethodHttp.GET,
                        tipo
                    )).Message;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return response;
        }

        public async Task<Response<List<TipoPersonaje>>> GetAll()
        {
            Response<List<TipoPersonaje>> response = new Response<List<TipoPersonaje>>();
            List<TipoPersonaje> tipoPersonajes = new List<TipoPersonaje>();

            try
            {
                response = await Consumer
                    .Execute<List<TipoPersonaje>, List<TipoPersonaje>>(
                        "http://localhost:5284/api/Tipo_Personaje",
                        MethodHttp.GET,
                        tipoPersonajes
                    );
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<Response<TipoPersonaje>> Update(TipoPersonaje tipo)
        {
            Response<TipoPersonaje> response = new Response<TipoPersonaje>();
            try
            {
                response = await Consumer
                    .Execute<TipoPersonaje, TipoPersonaje>(
                        $"http://localhost:5284/api/Tipo_Personaje/{tipo.Id}",
                        MethodHttp.PUT,
                        tipo
                    );
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<Response<string>> Delete(TipoPersonaje tipo)
        {
            Response<string> response = new Response<string>();
            try
            {
                response.Message = (await
                    Consumer.Execute<TipoPersonaje, TipoPersonaje>(
                        $"https://localhost:7128/api/Tipo_Personaje/{tipo.Id}",
                        MethodHttp.DELETE,
                        tipo
                    )).Message;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<Response<TipoPersonaje>> GetOne(TipoPersonaje tipo)
        {
            Response<TipoPersonaje> response = new Response<TipoPersonaje>();
            try
            {
                response = await Consumer
                    .Execute<TipoPersonaje, TipoPersonaje>(
                        $"http://localhost:5284/api/Tipo_Personaje/{tipo.Id}",
                        MethodHttp.PUT,
                        tipo
                    );
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
    }
}