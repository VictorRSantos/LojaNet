using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaNet.Models;
using LojaNet.DAL;

namespace LojaNet.BLL
{
    public class ProdutoBLL : IProdutosDados
    {
        private IProdutosDados dal;

        public ProdutoBLL(IProdutosDados produtosDados)
        {
            this.dal = produtosDados;
        }

        public void Validar(Produto produto)
        {
            if (String.IsNullOrEmpty(produto.Nome))
            {
                throw new Exception("O nome deve ser informado");

            }

            if (produto.Preco < 0)
            {
                throw new Exception("O preço deve ser maior ou igual a zero");
            }

        }

        

        public void Alterar(Produto produto)
        {
            Validar(produto);
            dal.Alterar(produto);
        }

        public void Excluir(string Id)
        {
            dal.Excluir(Id);
        }

        public void Incluir(Produto produto)
        {
            Validar(produto);
            if (string.IsNullOrEmpty(produto.Id))
            {
                produto.Id = Guid.NewGuid().ToString();
            }
            dal.Incluir(produto);
        }

        public Produto ObterPorId(string Id)
        {
            return dal.ObterPorId(Id);
        }

        public List<Produto> ObterTodos()
        {
            return dal.ObterTodos();
        }
    }
}
