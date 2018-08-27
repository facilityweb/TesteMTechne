using Autofac;
using MTechneTeste.Application.AppServices;
using MTechneTeste.Application.Interfaces;
using MTechneTeste.Domain.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MTechneTeste.Agenda.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Novo()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetContatos()
        {
            var lista = MTechneContainer.Container.Resolve<IContatoApplication>().GetContatos();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }
    }
}