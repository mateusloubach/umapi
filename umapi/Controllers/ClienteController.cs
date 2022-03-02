using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using umapi.Data;

namespace umapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private static List<Cliente> membros = new List<Cliente>
        {
            new Cliente
            {
                Id = 1,
                firstName = "Kiko",
                lastName = "Loureiro",
                motherName = "Maria",
                email = "kikoloureiro@email.com",
                end = "Rio de Janeiro",
                cpf = "12345678911",
            }
        };
        private readonly DataContext _dataContext;
        public ClienteController(DataContext context)
        {
            _dataContext = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> Get()
        {
            return Ok(membros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            var membro = await _dataContext.Membros.FindAsync(id);
            if (membro == null)
                return BadRequest("Cliente não existe.");
            return Ok(membro);
        }

        [HttpPost]
        public async Task<ActionResult<List<Cliente>>> AddCliente(Cliente cliente)
        {
            _dataContext.Membros.Add(cliente);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Membros.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Cliente>>> UpdateCliente(Cliente request)
        {
            var dbmembros = membros.Find(c => c.Id == request.Id);
            if (dbmembros == null)
                return BadRequest("Cliente não existe.");

            dbmembros.firstName = request.firstName;
            dbmembros.lastName = request.lastName;
            dbmembros.motherName = request.motherName;
            dbmembros.email = request.email;
            dbmembros.end = request.end;
            dbmembros.cpf = request.cpf;

            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Membros.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Cliente>>> Delete(int id)
        {
            var cliente = membros.Find(c => c.Id == id);
            if (cliente == null)
                return BadRequest("Cliente não existe.");

            _dataContext.Membros.Remove(cliente);
            await _dataContext.SaveChangesAsync();

            return Ok(membros);
        }
    }
}
