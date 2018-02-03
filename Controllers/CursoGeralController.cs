using System.Collections.Generic;
using System.Linq;
using CadastroCursos.Dados;
using CursosProfissionalizantes.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroCursos.Controllers
{
    [Route ("api/[controller]")]
    public class CursoGeralController : Controller
    {
        CursoGeral cg = new CursoGeral();

        readonly EscolaContexto contexto;

        public CursoGeralController(EscolaContexto contexto){
            this.contexto = contexto;
        }
        
        /// <summary>
        /// teste   
        /// </summary>
        /// <returns>teste</returns>
        [HttpGet]
        public IEnumerable<CursoGeral> Listar(){
            return contexto.CursoGeral.ToList();           
        }

        [HttpGet("{id}")]
        public CursoGeral Listar(int id){
            return contexto.CursoGeral.Where(x=>x.IdCursoGeral==id).FirstOrDefault();
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody]CursoGeral cg){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            contexto.CursoGeral.Add(cg);
            int x = contexto.SaveChanges();
            if(x>0)
                return Ok();
            else
                return BadRequest();
        }


        [HttpPut("{id}")]
        public IActionResult Atualizar(int id,[FromBody] CursoGeral cg){

            if(cg == null || cg.IdCursoGeral!=id){
                return BadRequest();
            }
            var curso = contexto.CursoGeral.Where(x=>x.IdCursoGeral==id).FirstOrDefault();
            if(curso==null)
                return NotFound();

            curso.IdCursoGeral = cg.IdCursoGeral;
            curso.NomeCursoGeral = cg.NomeCursoGeral;

            contexto.CursoGeral.Update(curso);
            int rs = contexto.SaveChanges();
            
            if(rs>0)
                return Ok();
            else
                return BadRequest();
        }

        [HttpDelete("{id}")]

        public IActionResult Apagar(int id){
            var curso = contexto.CursoGeral.Where(x=>x.IdCursoGeral==id).FirstOrDefault();
            if (curso == null){
                return NotFound();
            }
            contexto.CursoGeral.Remove(curso);
            int rs = contexto.SaveChanges();
            if(rs > 0)
                return Ok();
            else
                return BadRequest();                
        }

        
    }
}