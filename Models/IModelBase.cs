using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSCalendarAPI.Models
{
    //Interface Modelo para Utilizar em toda Model
    public interface IModelBase
    {
       int Id { get; set; }
       DateTime Atualizacao { get; set; }
    }
}
