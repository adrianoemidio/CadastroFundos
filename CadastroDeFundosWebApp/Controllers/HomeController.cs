using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadastroDeFundosWebApp.Models;
using FundosDataLibrary.BusinessLogic;

namespace CadastroDeFundosWebApp.Controllers
{
    public class HomeController : Controller
    {

        private static List<String> searchList = new List<String> {

                   "CPNJ",
                   "Razão Social",
                   "Nome Fantasia",
                   "Código no Sistema",
                   "Gestor",
                   "Custodiante ",
                   "Administrador"
            };


        public ActionResult Create()
        {
            var data = InstituicaoProcessor.Load();

            List<String> instituicoes = new List<String>();

            foreach (var row in data)
            {
                instituicoes.Add(row.Nome);
            }

            ViewBag.instituicoes = new SelectList(instituicoes);

            return View();

         }

        public ActionResult CreateImport(long id)
        {
            var data = InstituicaoProcessor.Load();

            List<String> instituicoes = new List<String>();

            foreach (var row in data)
            {
                instituicoes.Add(row.Nome);
            }

            ViewBag.instituicoes = new SelectList(instituicoes);

            FundosDataLibrary.Models.FundoModel dados;

            try { dados = FundosProcessor.LoadCodigoDoSistema(id).FirstOrDefault(); }
            catch { return View(); }

            FundoModel fundo = new FundoModel
            {
                CNPJ = dados.CNPJ,
                RazaoSocial = dados.RazaoSocial,
                NomeFantasia = dados.NomeFantasia,
                CodigoDoSistema = dados.CodigoDoSistema,
                Gestor = dados.Gestor,
                Custodiante = dados.Custodiante,
                Administrador = dados.Administrador,
                TaxaDeAdministracao = dados.TaxaDeAdministracao,
                DiasParaLiquidacao = dados.DiasParaLiquidacao,
                ResgateAutomatico = dados.ResgateAutomatico
            };

            return View("Create", fundo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FundoModel model)
        {

            var data = InstituicaoProcessor.Load();

            List<String> instituicoes =
                new List<String>();

            foreach (var row in data)
            {
                instituicoes.Add(row.Nome);
            }

            ViewBag.instituicoes = new SelectList(instituicoes);

            if (ModelState.IsValid)
            {
                int c = FundosProcessor.CreateFundo(model.CNPJ, model.RazaoSocial, model.NomeFantasia, model.CodigoDoSistema
                                , model.Gestor, model.Custodiante, model.Administrador, model.TaxaDeAdministracao,
                                model.DiasParaLiquidacao, model.ResgateAutomatico);

                return RedirectToAction("Search");
            }

            return View();
        }

        public ActionResult Search()
        {
            ViewBag.Message = "Busca de Fundos";

            ViewBag.SearchType = new SelectList(searchList);

           return View();
        }

        [HttpPost]
        public ActionResult Search(string searchValue, FormCollection form)
        {

            string searchType = form["SearchType"].ToString();

            ViewBag.Message = "Busca de Fundos";
                                               

            ViewBag.SearchType = new SelectList(searchList);
                       
            List<FundosDataLibrary.Models.FundoModel> dados;

            switch (searchType)
            {
                case "CPNJ":
                    try { dados = FundosProcessor.LoadCNPJ(Convert.ToInt32(searchValue)); }
                    catch { return View(); }
                    
                    break;
                case "Razão Social":
                    dados = FundosProcessor.LoadRazaoSocial(searchValue);
                    break;
                case "Nome Fantasia":
                    dados = FundosProcessor.LoadNomeFantasia(searchValue);
                    break;
                case "Código no Sistema":
                    try { dados = FundosProcessor.LoadCodigoDoSistema(Convert.ToInt32(searchValue)); }
                    catch { return View(); }
                    break;
                case "Gestor":
                    dados = FundosProcessor.LoadGestor(searchValue);
                    break;
                case "Custodiante ":
                    dados = FundosProcessor.LoadCustodiante(searchValue);
                    break;
                case "Administrador":
                    dados = FundosProcessor.LoadAdministrador(searchValue);
                    break;
                default:
                    return View();
            }

            if (dados.Count == 0)
                return View();

            //var dados = FundosProcessor.LoadFundos();
            List<FundoModel> fundos = new List<FundoModel>();

            foreach (var row in dados)
            {
                fundos.Add(new FundoModel
                {
                    CNPJ = row.CNPJ,
                    RazaoSocial = row.RazaoSocial,
                    NomeFantasia = row.NomeFantasia,
                    CodigoDoSistema = row.CodigoDoSistema,
                    Gestor = row.Gestor,
                    Custodiante = row.Custodiante,
                    Administrador = row.Administrador,
                    TaxaDeAdministracao = row.TaxaDeAdministracao,
                    DiasParaLiquidacao = row.DiasParaLiquidacao,
                    ResgateAutomatico = row.ResgateAutomatico
                });
            }

            return View(fundos);
        }

        public ActionResult Edit(long id)
        {
            var dadosFundos = FundosProcessor.LoadCodigoDoSistema(id).FirstOrDefault();
            var dataInstituicoes = InstituicaoProcessor.Load();


            //var dados = FundosProcessor.LoadFundos();
            FundoModel fundo = new FundoModel
                {
                    CNPJ = dadosFundos.CNPJ,
                    RazaoSocial = dadosFundos.RazaoSocial,
                    NomeFantasia = dadosFundos.NomeFantasia,
                    CodigoDoSistema = dadosFundos.CodigoDoSistema,
                    Gestor = dadosFundos.Gestor,
                    Custodiante = dadosFundos.Custodiante,
                    Administrador = dadosFundos.Administrador,
                    TaxaDeAdministracao = dadosFundos.TaxaDeAdministracao,
                    DiasParaLiquidacao = dadosFundos.DiasParaLiquidacao,
                    ResgateAutomatico = dadosFundos.ResgateAutomatico
                };

            List<String> instituicoes = new List<String>();

            foreach (var row in dataInstituicoes)
            {
                instituicoes.Add(row.Nome);
            }

            ViewBag.instituicoes = new SelectList(instituicoes);

            return View(fundo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FundoModel model)
        {

            var data = InstituicaoProcessor.Load();

            List<String> instituicoes =
                new List<String>();

            foreach (var row in data)
            {
                instituicoes.Add(row.Nome);
            }

            ViewBag.instituicoes = new SelectList(instituicoes);

            if (ModelState.IsValid)
            {
 
                FundosProcessor.UpdateFundo(model.CNPJ, model.RazaoSocial, model.NomeFantasia,
                                            model.CodigoDoSistema, model.Gestor, model.Custodiante,
                                            model.Administrador, model.TaxaDeAdministracao,
                                            model.DiasParaLiquidacao, model.ResgateAutomatico);

                return RedirectToAction("Search");

            }

            return View();

        }

        public ActionResult List()
        {
            var dados = FundosProcessor.LoadFundos();
            List<FundoModel> fundos = new List<FundoModel>();

            foreach (var row in dados)
            {
                fundos.Add(new FundoModel
                {
                    CNPJ = row.CNPJ,
                    RazaoSocial = row.RazaoSocial,
                    NomeFantasia = row.NomeFantasia,
                    CodigoDoSistema = row.CodigoDoSistema,
                    Gestor = row.Gestor,
                    Custodiante = row.Custodiante,
                    Administrador = row.Administrador,
                    TaxaDeAdministracao = row.TaxaDeAdministracao,
                    DiasParaLiquidacao = row.DiasParaLiquidacao,
                    ResgateAutomatico = row.ResgateAutomatico
                });
            }

            return View(fundos);
        }

        public ActionResult Delete(long id)
        {
            var dados = FundosProcessor.LoadCodigoDoSistema(id).FirstOrDefault();

            //var dados = FundosProcessor.LoadFundos();
            FundoModel fundo = new FundoModel
            {
                CNPJ = dados.CNPJ,
                RazaoSocial = dados.RazaoSocial,
                NomeFantasia = dados.NomeFantasia,
                CodigoDoSistema = dados.CodigoDoSistema,
                Gestor = dados.Gestor,
                Custodiante = dados.Custodiante,
                Administrador = dados.Administrador,
                TaxaDeAdministracao = dados.TaxaDeAdministracao,
                DiasParaLiquidacao = dados.DiasParaLiquidacao,
                ResgateAutomatico = dados.ResgateAutomatico
            };

            return View(fundo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(long id)
        {
            FundosProcessor.DeleteFundo(id);

            return RedirectToAction("Search");
        }

        public ActionResult HistorySearch()
        {

            return View();

        }

        [HttpPost]
        public ActionResult HistorySearch(int dayValue,int monthValue,
                            int yearValue, int hourValue, int minValue)
        {

            DateTime date = new DateTime(yearValue, monthValue, dayValue, hourValue, minValue, 0);



            var dados = FundoHistoryProcessor.Load(1, date);

            List<FundoHistoryModel> fundos = new List<FundoHistoryModel>();

            foreach (var row in dados)
            {
                fundos.Add(new FundoHistoryModel
                {
                    CNPJ = row.CNPJ,
                    RazaoSocial = row.RazaoSocial,
                    NomeFantasia = row.NomeFantasia,
                    CodigoDoSistema = row.CodigoDoSistema,
                    Gestor = row.Gestor,
                    Custodiante = row.Custodiante,
                    Administrador = row.Administrador,
                    TaxaDeAdministracao = row.TaxaDeAdministracao,
                    DiasParaLiquidacao = row.DiasParaLiquidacao,
                    ResgateAutomatico = row.ResgateAutomatico
                    
                });
            }




            return View(fundos);

        }

    }
}