using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSCalendarAPI.Helpers
{
    public class Seguranca
    {
        public static bool VerificaChave(string chave)
        {
            if (chave?.CompareTo(Constantes.Chave) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
