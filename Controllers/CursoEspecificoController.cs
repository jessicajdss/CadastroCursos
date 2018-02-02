using System.Collections.Generic;
using System.Linq;
using CadastroCursos.Dados;
using CursosProfissionalizantes.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroCursos.Controllers
{
    [Route ("api/[controller]")]
    public class CursoEspecificoController : Controller
    {
        CursoEspecifico ce = new CursoEspecifico();

        readonly EscolaContexto contexto;

        public CursoEspecificoController(EscolaContexto contexto){
            this.contexto = contexto;
        }
        
        [HttpGet]
        public IEnumerable<CursoEspecifico> Listar(){
            return contexto.CursoEspecifico.ToList();           
        }
    }
}