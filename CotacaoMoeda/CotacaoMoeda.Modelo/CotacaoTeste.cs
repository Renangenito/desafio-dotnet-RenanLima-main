using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotacaoMoeda.Modelo
{
    public class CotacaoTeste
    {
       
        public int Id { get; set; }
        public string name { get; set; } = "";
        public string bid { get; set; }
        public string ask { get; set; }
        public DateTime DataHoraCotacao { get; set; }
    }
}
