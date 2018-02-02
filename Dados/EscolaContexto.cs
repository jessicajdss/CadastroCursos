using CursosProfissionalizantes.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroCursos.Dados 
{
    public class EscolaContexto:DbContext
    {
        public EscolaContexto(DbContextOptions<EscolaContexto>options):base(options) {}
            public DbSet<CursoGeral> CursoGeral{get; set;}
            public DbSet<CursoEspecifico> CursoEspecifico{get; set;}

            protected override void OnModelCreating(ModelBuilder modelBuilder){
                modelBuilder.Entity<CursoGeral>().ToTable("CursoGeral");
                modelBuilder.Entity<CursoEspecifico>().ToTable("CursoEspecifico");
            }
    }
}