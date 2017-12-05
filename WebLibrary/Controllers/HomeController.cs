using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebLibrary._Application;
using WebLibrary._Domain;
using WebLibrary.ViewModels;

namespace WebLibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILivroService LivroService;

        public HomeController(ILivroService livroService)
        {
            LivroService = livroService;
        }

        /// <summary>
        /// Sei que isso é uma falha de seguranca, deveria usar o protocolo correto para delete - HttpDelete
        /// Foi feito assim apenas por questao de tempo... considerem por favor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(Guid id)
        {
            LivroService.Delete(id);

            return RedirectToAction("index", "Home");
        }

        /// <summary>
        /// Aqui haveria validação de permissao, se registro existe etc
        /// E deixaria o automapper resolver as propriedades
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Editar(Guid id)
        {
            var livro = LivroService.GetById(id);

            var livroViewModel = new LivroViewModel
            {
                Autor = livro.Autor,
                Erros = livro.Erros,
                Id = livro.Id,
                IsValid = livro.IsValid(),
                Nome = livro.Nome
            };

            return View(livroViewModel);
        }

        /// <summary>
        /// Aqui haveriam diversas validacoes e novamente usaria o automapper para as propriedades
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Editar(LivroViewModel model)
        {
            var livro = new Livro(model.Id, model.Autor, model.Nome);

            LivroService.Update(livro);

            return RedirectToAction("index", "Home");
        }

        public ActionResult Grid(LivrosViewModel gridViewModel)
        {
            var livrosViewModel = GetGrid(gridViewModel);

            return PartialView("_gridPartial", livrosViewModel);
        }

        public ActionResult Index()
        {
            var model = new LivrosViewModel { Livros = new List<LivroViewModel>() };

            return View(model);
        }

        public ActionResult Novo()
        {
            var livroViewModel = new LivroViewModel();
            return View(livroViewModel);
        }

        [HttpPost]
        public ActionResult Novo(LivroViewModel model)
        {
            if (ValidateRecord(model))
            {
                return View(model);
            }

            var cargo = LivroService.Save(model.Autor, model.Nome);

            if (!cargo.IsValid())
            {
                var mensagem = string.Empty;

                mensagem = string.Join("<br />", cargo.Erros.ToList());

                TempData["MensagemDeErro"] = mensagem;
                return View(model);
            }

            TempData["MensagemDeSucesso"] = "Registro inserido com sucesso";

            return RedirectToAction("Index", "Home", new { });
        }

        public bool ValidateRecord(LivroViewModel model)
        {
            var exists = LivroService.VerifyIfExists(model.Autor, model.Nome);

            if (exists)
            {
                TempData["MensagemDeErro"] = "Já existe este livro cadastrado para este autor";
            }

            return exists;
        }

        private LivrosViewModel GetGrid(LivrosViewModel gridViewModel)
        {
            //Aqui geralmente eu usaria o automapper...
            var livros = LivroService.GetAll();

            var model = new LivrosViewModel { Livros = new List<LivroViewModel>() };

            foreach (var livro in livros)
            {
                model.Livros.Add(new LivroViewModel
                {
                    Autor = livro.Autor,
                    Erros = livro.Erros,
                    Id = livro.Id,
                    IsValid = livro.IsValid(),
                    Nome = livro.Nome
                });
            }

            return model;
        }
    }
}