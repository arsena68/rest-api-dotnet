
using AlunosApiArnaldo.Models;
using AlunosApiArnaldo.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlunosApiArnaldo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AlunosController : ControllerBase
    {
        private IAlunoService _alunoService;

        public AlunosController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }
        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunos() {
            try
            {

                var alunos = await _alunoService.GetAlunos();
                return Ok(alunos);
            }
            catch
            {
                //  return BadRequest("Request Inválido");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Alunos");
            }

        }

        [HttpGet("AlunosPorNome")]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>>
            GetAlunosByName([FromQuery] string nome)
        {
            try
            {
                var alunos = await _alunoService.GetAlunosByNome(nome);
                if (alunos == null)
                    return NotFound($"Não existem alunos com o critério {nome}");
                return Ok(alunos);
            }
            catch
            {
                return BadRequest("Request Inválido");

            }
        }

        [HttpGet("{id:int}", Name = "GetAluno")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            try
            {
                var aluno = await _alunoService.GetAluno(id);
                if (aluno == null)
                    return NotFound($"Não existe aluno com o Id {id}");
                return Ok(aluno);
            }
            catch
            {
                return BadRequest("Request Inválido");

            }
        }

        [HttpPost]
            public async Task<ActionResult> CreateAluno(Aluno aluno)
        {
            try
            {
                await _alunoService.CreateAluno(aluno);

                return CreatedAtRoute(nameof(GetAluno), new { id = aluno.Id }, aluno);
            }
            catch
            {
                return BadRequest("Request Inválido");

            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Aluno aluno)
        {
            try
            {
                if (aluno.Id == id)
                {
                    await _alunoService.UpdateAluno(aluno);
                    return Ok($"Aluno com id {id} foi atualizado com sucesso");
                }
                else
                {
                    return BadRequest("Dados inconsistentes");
                }
            }
            catch
            {
                return BadRequest("Request inválido");

            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Aluno aluno = await _alunoService.GetAluno(id);
                if (aluno != null)
                {
                    await _alunoService.DeleteAluno(aluno);
                    return Ok($"Aluno de id={id} excluído com sucesso");
                    //return Ok(id);
                }
                else
                {
                    return NotFound($"Aluno com id= {id} não encontrado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
