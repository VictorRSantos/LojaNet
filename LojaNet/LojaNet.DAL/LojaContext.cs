using LojaNet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaNet.DAL
{
    public class LojaContext:DbContext
    {

        public LojaContext():base(DbHelper.conexao)
        {


        }

        //Conjunto de Dados 
        public DbSet<Produto> Produtos { get; set; }


    }
}
