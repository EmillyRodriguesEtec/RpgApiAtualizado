using Microsoft.AspNetCore.Mvc;
namespace RpgApiAvaliacao.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PersonagensController : ControllerBase
    {
        private readonly DataContext _context; //declaração do atributo

        public PersonagensController(DataContext context)
        {
            //inicialização do atributo a partir de um parâmetro
            _context = context;
        }

        [HtppGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Personagem p = await _context.Personagens
                    .FirstOrDefaultAsync(pBusca => pBusca.Id == id);

                return Ok(p);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Personagem> lista = await _context.Personagens.ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    } //fim da classe do tipo controller
}