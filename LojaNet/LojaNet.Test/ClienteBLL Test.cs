using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LojaNet.Models;
using LojaNet.BLL;

namespace LojaNet.Test
{
    
    [TestClass]
    public class ClienteBLL_Test
    {


        public class ClienteDALMock : IClienteDados
        {
            public void Alterar(Cliente cliente)
            {
            }

            public void Excluir(string Id)
            {
            }

            public void Incluir(Cliente cliente)
            {
            }

            public Cliente ObterPorEmail(string Email)
            {
                return null;

            }

            public Cliente ObterPorId(string Id)
            {
                return null;
            }

            public List<Cliente> ObterTodos()
            {
                return null;

            }
        }

        [TestMethod]
        public void IncluirNomeNotNullTest()
        {

            var cliente = new Cliente()
            {
                Nome = "José da Silva",
                Email = "victor@hotmail.com",
                Telefone = "9541452514"
            };

            var dal = new ClienteDALMock();
            var bll = new ClienteBLL();
            bool ok = false;
            try
            {
                bll.Incluir(cliente);
                ok = true;
            }
            catch (ApplicationException)
            {
                ok = true;

            }

            Assert.IsTrue(ok, "Deveria ter disparado um Exception");




        }

    




    [TestMethod]
        public void IncluirNomeNullTest()
        {

            var cliente = new Cliente()
            {
                Nome = null,
                Email = "victor@hotmail.com",
                Telefone = "9541452514"
            };

            var bll = new ClienteBLL();
            bool ok = false;
            try
            {
                bll.Incluir(cliente);
            }
            catch (ApplicationException)
            {
                ok = true;
                
            }

            Assert.IsTrue(ok, "Deveria ter disparado um Exception");




        }      
        
    }
}
