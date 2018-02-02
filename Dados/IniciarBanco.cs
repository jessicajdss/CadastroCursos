using System;
using System.Linq;
using CursosProfissionalizantes.Models;

namespace CadastroCursos.Dados {
    public class IniciarBanco {
        public static void Inicializar(EscolaContexto contexto){
            contexto.Database.EnsureCreated();
            if (contexto.CursoGeral.Any()){
                return;
            }
            var cursogeral = new CursoGeral()
                {NomeCursoGeral = "Informática e TI"};
            contexto.CursoGeral.Add(cursogeral);

            var cursoespecifico = new CursoEspecifico()
                {IdCursoGeral=1, NomeCursoEspecifico = "Tecnologia WEB", DataInicio=DateTime.Parse("2018-02-02"),DataFim=DateTime.Parse("2018-02-20"),HoraInicio=DateTime.Parse("15:00"),HoraFim=DateTime.Parse("17:00"),PeriodoSemana="Terças e Quintas"};
            contexto.CursoEspecifico.Add(cursoespecifico);

            contexto.SaveChanges();
        }
        
    }
}