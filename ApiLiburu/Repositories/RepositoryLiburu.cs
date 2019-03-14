using ApiLiburu.Data;
using ApiLiburu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiLiburu.Repositories
{
    public class RepositoryLiburu
    {
        LiburuContext context;

        public RepositoryLiburu()
        {
            this.context = new LiburuContext();
        }

        public List<Libro> GetLibros()
        {
            return this.context.Libros.ToList();
        }

        public List<Usuario> GetUsuarios()
        {
            return this.context.Usuarios.ToList();
        }
        public Usuario ExisteUsuario(String login, String password)
        {
            var consulta = from datos in context.Usuarios
                           where datos.Login == login &&
                           datos.Password == password
                           select datos;
            return consulta.FirstOrDefault();
        }

        public Usuario BuscarUsuario(int idusuario)
        {
            var consulta = from datos in context.Usuarios
                           where datos.IdUsuario == idusuario
                           select datos;
            return consulta.FirstOrDefault();
        }
    }
}