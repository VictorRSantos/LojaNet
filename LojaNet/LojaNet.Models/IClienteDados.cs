using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaNet.Models
{
    public interface IClienteDados
    {

        //Vamos definir o modelo de manipulação de dados
        //Dentro da internface não tem public 

        //Metodo Insert
        void Incluir(Cliente cliente);

        void Alterar(Cliente cliente);

        void Excluir(string Id);

        List<Cliente> ObterTodos();

        Cliente ObterPorId(string Id);

        Cliente ObterPorEmail(string Email);



    }
}
