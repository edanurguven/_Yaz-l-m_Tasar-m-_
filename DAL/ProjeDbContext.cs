using Microsoft.EntityFrameworkCore;
using System;

namespace DAL
{
    public class ProjeDbContext:DbContext
    {
        public DbSet<Malzeme> Malzemes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-DELL\SQLEXPRESS;Initial Catalog=dersProjeDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }

    public class Malzeme
    {
        public int Id { get; set; }
        public string malzemeler { get; set; }
        public string name { get; set; }

        public string UmlAdress { get; set; }

        public int KisiSayisi { get; set; }
        public double Sure { get; set; }

        public string Anlatim { get; set; }

    }
}
