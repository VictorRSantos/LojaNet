using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaNet.Models;
using LojaNet.BLL;
using LojaNet.DAL;

namespace LojaNet.UI.Web.Controllers
{
    public class ClienteController : Controller
    {
        private IClienteDados bll;

        public ClienteController()
        {
            bll = AppContainer.ObterClienteBLL();
        }

        public ActionResult Excluir(string id)
        {
            var cliente = bll.ObterPorId(id);
            return View(cliente);

        }

        [HttpPost]
        public ActionResult Excluir(string id, FormCollection form)
        {
            try
            {
                bll.Excluir(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //Adiciona erro no modelo
                ModelState.AddModelError(string.Empty, ex.Message);
                var cliente = bll.ObterPorId(id);
                return View(cliente);
            }
        }


        public ActionResult Alterar(string Id)
        {
            var cliente = bll.ObterPorId(Id);
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Alterar(Cliente cliente)
        {
            try
            {
                bll.Alterar(cliente);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //Adiciona erro no modelo
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(cliente);
            }
        }




        public ActionResult Detalhes(string Id)
        {
            var cliente = bll.ObterPorId(Id);
            return View(cliente);
        }


        public ActionResult Incluir()
        {
            var cliente = new Cliente();
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Incluir(Cliente cliente)
        {

            try
            {
                //vamos passar o cliente para Business Logic Layer, 
                //Vamos fazer uma referência para esse projeto add BLL
                
                bll.Incluir(cliente);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //Adiciona erro no modelo
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(cliente);
            }
          


        }


        public ActionResult Index()
        {
            
            var lista = bll.ObterTodos();
            return View(lista);
        }





    }
} 