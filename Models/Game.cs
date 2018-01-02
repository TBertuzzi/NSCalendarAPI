using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSCalendarAPI.Models
{
    public class Game : IModelBase
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public DateTime DataLancamento { get; set; }
        public string ImgUrl { get; set; }
        public bool Lancado { get; set; }
        public string Descricao { get; set; }
        public long IdGame { get; set; }
        public DateTime Atualizacao { get; set; }
    }
}
