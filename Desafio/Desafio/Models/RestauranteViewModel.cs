using System;

namespace Desafio.Models
{
    public class RestauranteViewModel
    {
        public string Name { get; set; }
        public TimeSpan HoraAbertura { get; set; }

        public TimeSpan HoraFechamento { get; set; }
    }
}
