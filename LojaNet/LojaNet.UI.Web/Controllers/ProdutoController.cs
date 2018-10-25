using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaNet.Models;


namespace LojaNet.UI.Web.Controllers
{
    [Authorize]
    public class ProdutoController : Controller
    {
        private IProdutosDados bll;


        public ProdutoController()
        {
            bll = AppContainer.ObterProdutoBLL();
        }


        //Excluir
        public ActionResult Excluir(string Id)
        {
            var produto = bll.ObterPorId(Id);
            return View(produto);
        }

        //Excluir Post
        [HttpPost]
        public ActionResult Excluir(string Id, FormCollection form)
        {
            try
            {
                bll.Excluir(Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
                var produto = bll.ObterPorId(Id);
                return View(produto);
            }
        }


        //Alterar
        public ActionResult Alterar(string Id)
        {
            var produto = bll.ObterPorId(Id);
            return View(produto);
        }
        //Alterar (post)
        [HttpPost]
        public ActionResult Alterar(Produto produto)
        {
            try
            {
                bll.Alterar(produto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(produto);
            }

        }


        //Detalhes
        public ActionResult Detalhes(string Id)
        {
            var produto = bll.ObterPorId(Id);
            return View(produto);

        }


        //Incluir
        public ActionResult Incluir()
        {
            var prod = new Produto();
            return View(prod);

        }

        //Incluir (Post)
        [HttpPost]
        public ActionResult Incluir(Produto produto)
        {
            try
            {
                
                bll.Incluir(produto);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(produto);
            }
        }

        
        //Index
        public ActionResult Index()
        {

            var lista = bll.ObterTodos();
            return View(lista);
        }


      


    }
}