using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Extensoes
{
    public static class Conversoes
    {
        public static int GerarNumeroSequencialTicket(int codigo)
        {
            var anoAtual = DateTime.Now.ToString("yyyy");
            var mesAtual = DateTime.Now.ToString("MM");
            var diaAtual = DateTime.Now.ToString("dd");
            var sequencial = anoAtual + mesAtual + diaAtual + codigo;
            var NewSequencial = ConverterSequencialStrToInt(sequencial);
            return NewSequencial;
        }

        public static int ConverterSequencialStrToInt(string sequencial)
        {
            var sequencialInt = int.Parse(sequencial);
            return sequencialInt;
        }
    }
}
