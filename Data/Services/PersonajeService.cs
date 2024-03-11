using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarea_asp.Data.Models;
using Newtonsoft.Json;
using System.Text;

namespace Tarea_asp.Data.Services
{
    public class PersonajeService
    {
        public async Task<Response<string>> Create(Personaje personaje) {
            Response<string> response = new Response<string>();
            try
            {
                response.Message = (await
                    Consumer.Execute<Personaje>(
                        "https://localhost:7128/api/Personaje",
                        MethodHttp.GET,
                        personaje
                    )).Message;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<Response<List<Personaje>>> GetAll()
        {
            Response<List<Personaje>> response = new Response<List<Personaje>>();
            List<Personaje> personajes = new List<Personaje>();
            try
            {
                response = await Consumer
                    .Execute<List<Personaje>>(
                        "http://localhost:5284/api/Personaje",
                        MethodHttp.GET,
                        personajes
                    );
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<Response<Personaje>> Update(Personaje personaje)
        {
            Response<Personaje> response = new Response<Personaje>();
            try
            {
                response = await Consumer
                    .Execute<Personaje>(
                        $"http://localhost:5284/api/Personaje/{personaje.Id}",
                        MethodHttp.PUT,
                        personaje
                    );
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<Response<string>> Delete(Personaje personaje)
        {
            Response<string> response = new Response<string>();
            try
            {
                response.Message = (await
                    Consumer.Execute<Personaje>(
                        $"https://localhost:7128/api/Personaje/{personaje.Id}",
                        MethodHttp.DELETE,
                        personaje
                    )).Message;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<Response<Personaje>> GetOne(Personaje personaje)
        {
            Response<Personaje> response = new Response<Personaje>();
            try
            {
                response = await Consumer
                    .Execute<Personaje>(
                        $"http://localhost:5284/api/Personaje/{personaje.Id}",
                        MethodHttp.PUT,
                        personaje
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