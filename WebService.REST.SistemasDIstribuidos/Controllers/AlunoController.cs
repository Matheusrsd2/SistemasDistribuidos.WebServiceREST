using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.REST.SistemasDIstribuidos.Model;

namespace WebService.REST.SistemasDIstribuidos.Controllers
{
    public class AlunoController : Controller
    {
        private readonly Aluno _aluno;
        public AlunoController(Aluno aluno)
        {
            _aluno = aluno;
        }

        /* Obtém todos os alunos */
        [Route("api/alunos/v1")]
        [HttpGet]
        public ActionResult ObterAlunos()
        {
            List<Aluno> alunos = _aluno.ListarAlunos();
            return Ok(alunos);
        }

        /* Obtém o aluno espefífico pelo nome */
        [Route("api/alunos/v1/{nome}")]
        [HttpGet]
        public ActionResult ObterAlunoPeloNome(string nome)
        {
            Aluno aluno = _aluno.ObterAlunoPeloNome(nome);
            if(aluno != null)
            {
                return Ok(aluno);
            }
            return StatusCode(404, "Aluno não foi localizado");

        }

        /* Adiciona um aluno novo na lista */
        [Route("api/alunos/v1")]
        [HttpPost]
        public ActionResult IncluirAluno ([FromBody] Aluno aluno)
        {
            try
            {
                _aluno.IncluirAluno(aluno);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return Created($"api/alunos/v1/{aluno}", aluno);
            
        }

        /* Exclui o aluno da lista através do nome */
        [Route("api/alunos/v1/{nome}")]
        [HttpDelete]
        public ActionResult RemoverAluno (string nome)
        {
            _aluno.RemoverAluno(nome);
            return Ok();
        }

        /*Edita o aluno buscando pelo nome */
        [Route("api/alunos/v1/{nome}")]
        [HttpPut]
        public ActionResult EditarAluno(string nome, [FromBody] Aluno model)
        {
            _aluno.EditarAluno(nome, model);
            return Ok();
        }
    }
}
