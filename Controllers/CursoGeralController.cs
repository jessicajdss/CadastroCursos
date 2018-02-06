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
        ///   Retorna lista de Cursos Gerais 
        /// </summary>
        /// <returns>Cursos Gerais</returns>
        /// <response code="200"> Retorna uma lista de cursos gerais </response>
        /// <response code="400"> Ocorreu um erro </response>
        [HttpGet]
        [ProducesResponseType(typeof(List<CursoGeral>),200)]
        [ProducesResponseType(typeof(string),400)]
        public IActionResult Listar(){
            try{
                return Ok(contexto.CursoGeral.ToList());           
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // public IEnumerable<CursoGeral> Listar(){
        //     return contexto.CursoGeral.ToList();           
        // }

    /// <summary>
    /// Busca um curso pelo seu ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Retorna um curso geral</returns>
    /// <response code="200"> Retorna um curso geral </response>
    /// <response code="400"> Ocorreu um erro </response>
    /// <response code="404"> Curso Não Encontrado </response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<CursoGeral>),200)]
        [ProducesResponseType(typeof(string),400)]
        [ProducesResponseType(typeof(string),404)]
        public IActionResult Listar(int id){
            
            try{
                CursoGeral curso = contexto.CursoGeral.Where(x=>x.IdCursoGeral==id).FirstOrDefault();

                if(curso == null){
                    return NotFound("Curso Geral não encontrado");
                }
                return Ok (curso);
            }
            catch(System.Exception ex){
                return BadRequest(ex.Message);
            }
        }
    /// <summary>
    /// Cadastra uma nova área
    /// </summary>
    /// <param name="cg"></param>
    /// <remarks>
    /// Modelo de dados que deve ser enviado para cadastrar a area request:
    /// 
    /// POST/CursoGeral:
    ///     {
    ///         "nome" :"nome do curso geral"     
    ///     }
    /// </remarks>
    ///  <response code="200"> Retorna curso geral cadastrado </response>
    /// <response code="400"> Ocorreu um erro </response>
        [HttpPost]
        [ProducesResponseType(typeof(List<CursoGeral>),200)]
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