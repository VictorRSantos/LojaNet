using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaNet.Models
{
    public class Pedido
    {
        //Nuemro do Pedido
        public int Id { get; set; }
        //Data e Hora do Pedido
        public DateTime Data { get; set; }
        //Dados do Cliente (Id,Nome,Email,Telefone)
        public Cliente Cliente { get; set; }

        public FormaPagamentoEnum FormaPagamento { get; set; }

        public List<Item> Items { get; set; }

        //Item do Pedido É uma classe interna, nota fiscal
        public class Item
        {
            //Ordem 
            public int Ordem { get; set; }
            //Qual o produto que está sendo comprado
            public Produto Produto { get; set; }
            //Quantidade do produto
            public int Quantidade { get; set; }
            //Preço do produto atual
            public decimal Preco { get; set; }

        }


    }
}
