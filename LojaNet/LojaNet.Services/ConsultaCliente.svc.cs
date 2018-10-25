using LojaNet.BLL;
using LojaNet.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LojaNet.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ConsultaCliente" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ConsultaCliente.svc or ConsultaCliente.svc.cs at the Solution Explorer and start debugging.
    public class ConsultaCliente : IConsultaCliente
    {
        public ClienteInfo ConsultarPorEmail(string chave, string email)
        {
            if (chave != "1234567890@!")
            {
                return null;
            }

            ClienteInfo clienteInfo = null;
            var dal = new ClienteDAL();

            var bll = new ClienteDAL();
            var cliente = bll.ObterPorEmail(email);

            if (cliente == null)
            {
                return null;
            }
            else
            {
                clienteInfo = new ClienteInfo()
                {
                    Nome = cliente.Nome,
                    Email = cliente.Email,
                    Telefone = cliente.Telefone

                };
            }

            return clienteInfo;

        }
    }
}
