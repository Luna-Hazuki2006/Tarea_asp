using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarea_asp.Data.Models;
using Newtonsoft.Json;
using System.Text;

namespace Tarea_asp.Data.Services
{
    public class EnemigoService
    {
        public async Task<Response<string>> Create(Enemigo enemigo) {
            Response<string> response = new Response<string>();
            try
            {
                response.Message = (await
                    Consumer.Execute<Enemigo, Enemigo>(
                        "https://localhost:7128/api/Enemigo",
                        MethodHttp.GET,
                        enemigo
                    )).Message;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return response;
        }

        public async Task<Response<List<Enemigo>>> GetAll()
        {
            Response<List<Enemigo>> response = new Response<List<Enemigo>>();
            List<Enemigo> enemigos = new List<Enemigo>();

            try
            {
                response = await Consumer
                    .Execute<List<Enemigo>, List<Enemigo>>(
                        "http://localhost:5284/api/Enemigo",
                        MethodHttp.GET,
                        enemigos
                    );
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<Response<Enemigo>> Update(Enemigo enemigo)
        {
            Response<Enemigo> response = new Response<Enemigo>();
            try
            {
                response = await Consumer
                    .Execute<Enemigo, Enemigo>(
                        $"http://localhost:5284/api/Enemigo/{enemigo.Id}",
                        MethodHttp.PUT,
                        enemigo
                    );
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<Response<string>> Delete(Enemigo enemigo)
        {
            Response<string> response = new Response<string>();
            try
            {
                response.Message = (await
                    Consumer.Execute<Enemigo, Enemigo>(
                        $"https://localhost:7128/api/Enemigo/{enemigo.Id}",
                        MethodHttp.DELETE,
                        enemigo
                    )).Message;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<Response<Enemigo>> GetOne(Enemigo enemigo)
        {
            Response<Enemigo> response = new Response<Enemigo>();
            try
            {
                response = await Consumer
                    .Execute<Enemigo, Enemigo>(
                        $"http://localhost:5284/api/Enemigo/{enemigo.Id}",
                        MethodHttp.PUT,
                        enemigo
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