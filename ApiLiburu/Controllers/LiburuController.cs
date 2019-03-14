using ApiLiburu.Models;
using ApiLiburu.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace ApiLiburu.Controllers
{
    public class LiburuController : ApiController
    {
        RepositoryLiburu repo;

        public LiburuController()
        {
            this.repo = new RepositoryLiburu();
        }

        [Authorize]
        public List<Libro> GetLibros()
        {
            return this.repo.GetLibros();
        }

        [Authorize]
        [HttpGet]
        [Route("api/PerfilUsuario")]
        public Usuario PerfilUsuario()
        {
            ClaimsIdentity identidad = User.Identity as ClaimsIdentity;
            int idusuario = int.Parse(identidad.FindFirst(ClaimTypes.NameIdentifier).Value);
            Usuario user = this.repo.BuscarUsuario(idusuario);
            return user;
        }

        public Usuario Get(int id)
        {
            return this.repo.BuscarUsuario(id);
        }
    }
}
