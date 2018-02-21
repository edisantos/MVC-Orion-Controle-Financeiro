using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orion.DAL
{
    public class EntradaConta
    {
        [Key]
        public string id { get; set; }
        public string Nome { get; set; }
        public string TipoEntrada { get; set; }
        public string Valor { get; set; }
        public string Comentario { get; set; }
    }
}
