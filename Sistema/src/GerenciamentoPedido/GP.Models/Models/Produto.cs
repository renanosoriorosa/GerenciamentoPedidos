using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GP.Models.Enums;

namespace GP.Models.Models
{
    public class Produto
    {
        public int Id { get; private set; }
        public string Codigo { get; private set; }
        public string Descricao { get; private set; }
        public TipoProdutoEnum TipoProduto { get; private set; }
    }
}
