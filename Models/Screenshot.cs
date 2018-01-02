using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSCalendarAPI.Models
{
    public class Screenshot : IModelBase
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        public long IdGame { get; set; }
        public DateTime Atualizacao { get; set; }

    }
}
