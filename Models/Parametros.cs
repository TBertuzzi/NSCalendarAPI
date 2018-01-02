using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSCalendarAPI.Models
{
    public class Parametros : IModelBase
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Atualizacao { get; set; }
    }
}
