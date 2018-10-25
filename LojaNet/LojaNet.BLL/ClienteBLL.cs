using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaNet.Models;
using LojaNet.DAL;

namespace LojaNet.BLL
{
    public class ClienteBLL : IClienteDados
    {
        //INICIO - Método construtor para não ficar estanciando a classe
        private IClienteDados dal;

        public ClienteBLL(IClienteDados clienteDados)
        {
            this.dal = clienteDados;
        }

        public ClienteBLL()
        {
        }

        //FIM



        //Vamos Implementar IClienteDados
        public void Alterar(Cliente cliente)
        {
            Validar(cliente);

            if (string.IsNullOrEmpty(cliente.Id))
            {
                throw new Exception("O id deve ser informado");

            }


            dal.Alterar(cliente);
        }
        public void Excluir(string Id)
        {

            if (string.IsNullOrEmpty(Id))
            {
                throw new Exception("O id deve ser informado");

            }

            dal.Excluir(Id);
        }

        public void Incluir(Cliente cliente)
        {
            //Se o nome for nulo vai apresentar a mensagem
            Validar(cliente);


            //Se o Id for nulo vai vamos criar um Id com o Guid.NewGuid()
            if (string.IsNullOrEmpty(cliente.Id))
            {
                cliente.Id = Guid.NewGuid().ToString();

            }

            //Vamos Estanciar a Classe DAL e chamar o metodo Insert

            dal.Incluir(cliente);

        }

        private static void Validar(Cliente cliente)
        {
            if (string.IsNullOrEmpty(cliente.Nome))
            {
                throw new ApplicationException("O nome deve ser informado");

            }
        }

        public Cliente ObterPorEmail(string email)
        {
            return dal.ObterPorEmail(email);
        }

        public Cliente ObterPorId(string Id)
        {
            return dal.ObterPorId(Id);
        }

        public List<Cliente> ObterTodos()
        {            
            var lista = dal.ObterTodos();
            return lista;
        }
    }
}
