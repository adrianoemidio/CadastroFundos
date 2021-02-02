using CadastroDeFundosWebApp.Models;
using FundosDataLibrary.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadastroDeFundosWebApp.Controllers
{
    public class InstituicoesController : Controller
    {
        // GET: Instituicoes
        public ActionResult List()
        {
            var data = InstituicaoProcessor.Load();

            List<InstituicaoFianceiraModel> instituicoes = new List<InstituicaoFianceiraModel>();

            foreach (var row in data)
            {
                instituicoes.Add(new InstituicaoFianceiraModel {Nome = row.Nome, Id = row.Id });
            }

            return View(instituicoes);
        }

        // GET: Instituicoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Instituicoes/Create
        [HttpPost]
        public ActionResult Create(InstituicaoFianceiraModel model)
        {
            try
            {
                InstituicaoProcessor.Save(model.Nome);

                return RedirectToAction("Search","Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Instituicoes/Edit/5
        public ActionResult Edit(int id)
        {
            var dado = InstituicaoProcessor.Load(id).FirstOrDefault();

            InstituicaoFianceiraModel instituicao = new InstituicaoFianceiraModel
            {
                Id = dado.Id,
                Nome = dado.Nome
            };

            return View(instituicao);
        }

        // POST: Instituicoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
         public ActionResult Edit(InstituicaoFianceiraModel model)
        {
            try
            {
                InstituicaoProcessor.Edit(model.Nome, model.Id);

                return RedirectToAction("Search","Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Instituicoes/Delete/5
        public ActionResult Delete(int id)
        {
            var dado = InstituicaoProcessor.Load(id).FirstOrDefault();

            InstituicaoFianceiraModel instituicao = new InstituicaoFianceiraModel
            {
                Id = dado.Id,
                Nome = dado.Nome
            };


            return View(instituicao);
        }

        // POST: Instituicoes/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                InstituicaoProcessor.Delete(id);

                return RedirectToAction("Search", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}
