using LogicaAplicacionUsuarios.ICRoles;
using LogicaAplicacionUsuarios.ICUsuarios;
using LogicaDeNegocioUsuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MundialProg3.Models;
using System;
using System.Collections.Generic;

namespace MundialProg3.Controllers
{
    public class UsuarioController : Controller
    {

        public IAltaUsuario AltaUsuario;
        public IBuscarUsuarioPorNombre UsuarioPorNombre;
        public ILogin Login;
        public IFindAll FindAllRoles;
        public IFindById FindByIdRoles;
        public IAdd AgregarRol;

        public UsuarioController(IAltaUsuario altaUsuario, IBuscarUsuarioPorNombre usuarioPorNombre, ILogin login,
                                IFindAll findAllRoles, IFindById findByIdRoles, IAdd agregarRol)
        {
            this.AltaUsuario = altaUsuario;
            this.UsuarioPorNombre = usuarioPorNombre;
            this.Login = login;
            this.FindAllRoles = findAllRoles;
            this.FindByIdRoles = findByIdRoles;
            this.AgregarRol = agregarRol;
        }


        #region LOGIN
        public IActionResult InicioSesion()
        {
            ViewModelUsuarios vmRoles = new ViewModelUsuarios();
            vmRoles.TodosLosRoles = FindAllRoles.FindAll();

            return View("InicioSesion",vmRoles);
        }

        [HttpPost]
        public IActionResult IniciarSesion(string email, string password, int idRol)
        {
            try
            {
                Usuarios usu = new Usuarios();
                Roles rolBuscado = FindByIdRoles.FindById(idRol);

                if (idRol == 1 && Login.Login(email, password, idRol) != null) // 1 = rol admin
                {
                    usu = UsuarioPorNombre.BuscarUsuarioPorNombre(email);
                    HttpContext.Session.SetString("Rol", usu.MisRoles[0].Nombre);
                    return RedirectToAction("Index", "Home");

                }
                else if (idRol == 2 && Login.Login(email, password, idRol) != null) // 2 = rol apostador
                {
                    usu = UsuarioPorNombre.BuscarUsuarioPorNombre(email);
                    HttpContext.Session.SetString("Rol", rolBuscado.Nombre);
                    return RedirectToAction("Index", "Home");

                }
                else if (idRol == 3 && Login.Login(email, password, idRol) != null) // 3 = rol invitado
                {
                    usu = UsuarioPorNombre.BuscarUsuarioPorNombre(email);
                    HttpContext.Session.SetString("Rol", rolBuscado.Nombre);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View("InicioSesion");
                }
            }
            catch (Exception ex)
            {

                return ViewBag.Error = ex.Message;
            }


        }
        #endregion


        #region AltaUsuario

        public IActionResult AgregarUsuario()
        {
            
            return View("AgregarUsuario");
        }

        [HttpPost]    
        public IActionResult CrearUsuario(Usuarios nuevoUsuario)
        {

            try
            {

                nuevoUsuario.MisRoles = new List<Roles>();
                Roles rol = FindByIdRoles.FindById(3); // 3 = rol de invitado
                nuevoUsuario.MisRoles.Add(rol);
                AltaUsuario.Add(nuevoUsuario);

                return RedirectToAction("InicioSesion");


            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return RedirectToAction("InicioSesion");
            }

           
        }



        #endregion


        #region LOGOUT
        public IActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("InicioSesion");
        }
        #endregion

    }
}
