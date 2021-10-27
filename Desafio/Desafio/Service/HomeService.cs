using Desafio.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Desafio.Service
{
    public class HomeService
    {
        public HomeService()
        {
        }

        public List<RestauranteViewModel> GetRestaurantesByHora (TimeSpan hora)
        {
            var reader = new StreamReader(File.OpenRead(@"..\\Desafio\\Content\\restaurant-hours.csv"));
            var restaurantes = new List<RestauranteViewModel>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                if (values[1].Split("-").Length != 2)
                    continue;

                restaurantes.Add(new RestauranteViewModel
                {
                    Name = values[0],
                    HoraAbertura = TimeSpan.Parse(values[1].Split("-")[0]),
                    HoraFechamento = TimeSpan.Parse(values[1].Split("-")[1])
                });

            }

            restaurantes = restaurantes.Where(x => x.HoraAbertura <= hora && x.HoraFechamento >= hora).ToList();

            return restaurantes;
        }
    }
}
