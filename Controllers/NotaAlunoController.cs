using System.Collections.Generic;
using EscolaParticular.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace EscolaParticular.Controllers
{
    public class NotaAlunoController : Controller
    {
        public IActionResult Publicar()
        {
            if (HttpContext.Session.GetInt32("idUsuario") == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            else if (HttpContext.Session.GetString("tipoUsuario").Contains("P") || HttpContext.Session.GetString("tipoUsuario").Contains("D"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult Publicar(NotaAluno cna)
        {
            NotaAlunoRepository newna = new NotaAlunoRepository();
            newna.Insert(cna);
            ViewBag.Mensagem = "Nota publicada com sucesso";
            return View();
        }
        public IActionResult ListarNota()
        {
            if (HttpContext.Session.GetInt32("idUsuario") == null)
                return RedirectToAction("Login", "Usuario");
            
            NotaAlunoRepository newna = new NotaAlunoRepository();
            int? id = HttpContext.Session.GetInt32("idUsuario");
            List<NotaAluno> notas = newna.Query(id);
            return View(notas);
        }
        public IActionResult EditarNota()
        {
            if (HttpContext.Session.GetInt32("idUsuario") == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            else if (HttpContext.Session.GetString("tipoUsuario").Contains("P") || HttpContext.Session.GetString("tipoUsuario").Contains("D"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult EditarNota(NotaAluno notas)
        {
            NotaAlunoRepository newna = new NotaAlunoRepository();
            newna.Update(notas);
            ViewBag.Mensagem = "Nota editada com sucesso";
            return View();
        }
        public IActionResult DeletarNota()
        {
            if (HttpContext.Session.GetInt32("idUsuario") == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            else if (HttpContext.Session.GetString("tipoUsuario").Contains("P") || HttpContext.Session.GetString("tipoUsuario").Contains("D"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult DeletarNota(int id)
        {
            NotaAlunoRepository newna = new NotaAlunoRepository();
            newna.Delete(id);
            ViewBag.Mensagem = "Nota deletada com sucesso";
            return View();
        }
    }
}