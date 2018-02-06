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


        [HttpGet("{id}")]
        public CursoEspecifico Listar(int id){
            return contexto.CursoEspecifico.Where(x=>x.IdCursoEspecifico==id).FirstOrDefault();
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody]CursoEspecifico ce){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            contexto.CursoEspecifico.Add(ce);
            int x = contexto.SaveChanges();
            if(x>0)
                return Ok();
            else
                return BadRequest();
        }


        [HttpPut("{id}")]
        public IActionResult Atualizar(int id,[FromBody] CursoEspecifico ce){

            if(ce == null || ce.IdCursoEspecifico!=id){
                return BadRequest();
            }
            var curso = contexto.CursoEspecifico.Where(x=>x.IdCursoEspecifico==id).FirstOrDefault();
            if(curso==null)
                return NotFound();

            curso.IdCursoEspecifico = ce.IdCursoEspecifico;
            curso.NomeCursoEspecifico = ce.NomeCursoEspecifico;

            contexto.CursoEspecifico.Update(curso);
            int rs = contexto.SaveChanges();
            
            if(rs>0)
                return Ok();
            else
                return BadRequest();
        }

        [HttpDelete("{id}")]

        public IActionResult Apagar(int id){
            var curso = contexto.CursoEspecifico.Where(x=>x.IdCursoEspecifico==id).FirstOrDefault();
            if (curso == null){
                return NotFound();
            }
            contexto.CursoEspecifico.Remove(curso);
            int rs = contexto.SaveChanges();
            if(rs > 0)
                return Ok();
            else
                return BadRequest();                
        }
    }
}