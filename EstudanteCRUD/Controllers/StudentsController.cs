using EstudanteCRUD.Data;
using EstudanteCRUD.Models;
using EstudanteCRUD.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace EstudanteCRUD.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : Controller
    {
        private readonly EstudanteCrudDbContext dbContext;

        public StudentsController(EstudanteCrudDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        ///  Retorna todos os estudantes (autenticado).
        /// </summary>
        /// <returns>Lista de estudantes</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não autorizado</response>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetStudents()
        {
            return Ok(await dbContext.Students.ToListAsync());
        }

        /// <summary>
        ///  Retorna um estudante específico (autenticado).
        /// </summary>
        /// <param name="id">Identificador de estudante</param>
        /// <returns>Dados do estudante</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="401">Não autorizado</response>
        /// <response code="404">Não encontrado</response>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]
        public async Task<IActionResult> GetStudent([FromRoute] int id)
        {
            var student = await dbContext.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        /// <summary>
        ///  Cria um novo estudante (autenticado).
        /// </summary>
        /// <remarks>
        /// Nome: nome do estudante. Idade: idade do estudante. Serie: série do estudante. NotaMedia: nota média do estudante. Endereco: endereço do estudante. NomePai: nome do pai do estudante. NomeMae: nome da mãe do estudante. DataNascimento: data de nascimento do estudante.
        /// </remarks>
        /// <param name="addStudentRequest">Dados do estudante</param>
        /// <returns>Objeto recém-criado</returns>
        /// <response code="201">Sucesso</response>
        /// <response code="401">Não autorizado</response>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> AddStudent(AddStudentRequest addStudentRequest)
        {
            var student = new Student()
            {
                Nome = addStudentRequest.Nome,
                Idade = addStudentRequest.Idade,
                Serie = addStudentRequest.Serie,
                NotaMedia = addStudentRequest.NotaMedia,
                Endereco = addStudentRequest.Endereco,
                NomePai = addStudentRequest.NomePai,
                NomeMae = addStudentRequest.NomeMae,
                DataNascimento = addStudentRequest.DataNascimento
            };

            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();

            return Ok(student);
        }

        /// <summary>
        ///  Atualiza um estudante existente (autenticado).
        /// </summary>
        /// <remarks>
        /// Nome: nome do estudante. Idade: idade do estudante. Serie: série do estudante. NotaMedia: nota média do estudante. Endereco: endereço do estudante. NomePai: nome do pai do estudante. NomeMae: nome da mãe do estudante. DataNascimento: data de nascimento do estudante.
        /// </remarks>
        /// <param name="id">Identificador de estudante</param>
        /// <param name="updateStudentRequest">Dados do estudante</param>
        /// <returns></returns>
        /// <response code="204">Sucesso</response>
        /// <response code="401">Não autorizado</response>
        /// <response code="404">Não encontrado</response>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] int id, UpdateStudentRequest updateStudentRequest)
        {
            var student = await dbContext.Students.FindAsync(id);

            if (student != null)
            {
                student.Nome = updateStudentRequest.Nome;
                student.Idade = updateStudentRequest.Idade;
                student.Serie = updateStudentRequest.Serie;
                student.NotaMedia = updateStudentRequest.NotaMedia;
                student.Endereco = updateStudentRequest.Endereco;
                student.NomePai = updateStudentRequest.NomePai;
                student.NomeMae = updateStudentRequest.NomeMae;
                student.DataNascimento = updateStudentRequest.DataNascimento;

                await dbContext.SaveChangesAsync();

                return Ok(student);
            }

            return NotFound();
        }

        /// <summary>
        ///  Deleta um estudante (autenticado).
        /// </summary>
        /// <param name="id">Identificador de estudante</param>
        /// <returns></returns>
        /// <response code="204">Sucesso</response>
        /// <response code="401">Não autorizado</response>
        /// <response code="404">Não encontrado</response>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            var student = await dbContext.Students.FindAsync(id);

            if (student != null)
            {
                dbContext.Remove(student);
                await dbContext.SaveChangesAsync();
                return Ok(student);
            }

            return NotFound();
        }
    }

}
