using System;
using System.Collections.Generic;
using System.Linq;
using Tarea_asp.Data.Models;
using Tarea_asp.Data.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Tarea_asp.Components
{
    public class WeatherBase : ComponentBase
    {
        [Parameter]
        public string? Param {get; set;}

        public string Message {get; set;} = "Valor inicial";
        public bool Control {get; set;}
        public DateTime Fecha {get; set;}

        [Inject]
        WeatherForecastService ForecastService {get; set;}

        public WeatherForecast[]? Forecasts;

        protected override async Task OnInitializedAsync() {
            if (Control) {
                await Task.Delay(500);
                Forecasts = await ForecastService.GetForecastAsync(Fecha);
            }
        }

        public override async Task SetParametersAsync(ParameterView parameters) {
            if (parameters.TryGetValue<string>(nameof(Param), out var value))
            {
                if (value is not null)
                {
                    Message = $"The value of 'Param' is {value}.";
                    Control = true; 
                    Fecha = DateTime.Now;
                } else {
                    Control = false;
                    Fecha = (DateTime.Now).AddDays(1);
                }
            }
            await base.SetParametersAsync(parameters);
        }
    }
}