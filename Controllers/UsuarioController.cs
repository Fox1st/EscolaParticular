using System;
using System.Collections.Generic;
using EscolaParticular.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace EscolaParticular.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Usuario u)
        {
            UsuarioRepository ur = new UsuarioRepository();
            Usuario usuario = ur.QueryLogin(u);
            if (usuario != null)
            {
                HttpContext.Session.SetInt32("idUsuario", usuario.Id);
                HttpContext.Session.SetString("nomeUsuario", usuario.Nome);
                HttpContext.Session.SetString("tipoUsuario", usuario.TipoUsuario);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Mensagem = "Falha no Login";
                return View();
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View();
        }

        public IActionResult Cadastro()
        {
            if (HttpContext.Session.GetInt32("idUsuario") == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            else if (HttpContext.Session.GetString("tipoUsuario").Contains("D") || HttpContext.Session.GetString("tipoUsuario").Contains("M"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult Cadastro(Usuario usr)
        {
            UsuarioRepository cusr = new UsuarioRepository();
            cusr.Insert(usr);
            return View();
        }
        public IActionResult Listar()
        {
            if (HttpContext.Session.GetInt32("idUsuario") == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            else if (HttpContext.Session.GetString("tipoUsuario").Contains("D") || HttpContext.Session.GetString("tipoUsuario").Contains("M"))
            {
                UsuarioRepository nusr = new UsuarioRepository();
                List<Usuario> usr = nusr.Query("A");
                return View(usr);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
        [HttpPost]
        public IActionResult Listar(string usuario)
        {
            UsuarioRepository nusr = new UsuarioRepository();
            List<Usuario> usr = nusr.Query(usuario);
            return View(usr);
        }
        public IActionResult Editar()
        {
            if (HttpContext.Session.GetInt32("idUsuario") == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            else if (HttpContext.Session.GetString("tipoUsuario").Contains("D") || HttpContext.Session.GetString("tipoUsuario").Contains("M"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult Editar(Usuario usr)
        {
            UsuarioRepository nusr = new UsuarioRepository();
            nusr.Update(usr);
            return View();
        }
        public IActionResult Deletar()
        {
            if (HttpContext.Session.GetInt32("idUsuario") == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            else if (HttpContext.Session.GetString("tipoUsuario").Contains("D") || HttpContext.Session.GetString("tipoUsuario").Contains("M"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult Deletar(int id)
        {
            UsuarioRepository nusr = new UsuarioRepository();
            nusr.Delete(id);
            return View();
        }
    }
}