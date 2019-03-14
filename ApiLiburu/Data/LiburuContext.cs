using ApiLiburu.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ApiLiburu.Data
{
    public class LiburuContext : DbContext
    {
        public LiburuContext() : base("name=cadenalibro") { }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Genero> Generos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<LiburuContext>(null);
        }
    }
}