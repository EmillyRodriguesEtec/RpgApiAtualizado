using Microsoft.AspNetCore.Mvc;
using RpgApiAvaliacao.Models;
using RpgApiAvaliacao.Models.Enuns;
using  System.Linq;

namespace RpgApiAvaliacao.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PersonagensExercicioController: ControllerBase
    {
        private static List<Personagem> personagens = new List<Personagem>()
        {
            //Colar os objetos da lista do chat aqui
            new Personagem() { Id = 1, Nome = "Frodo", PontosVida=100, Forca=17, Defesa=23, Inteligencia=33, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 2, Nome = "Sam", PontosVida=100, Forca=15, Defesa=25, Inteligencia=30, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 3, Nome = "Galadriel", PontosVida=100, Forca=18, Defesa=21, Inteligencia=35, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 4, Nome = "Gandalf", PontosVida=100, Forca=18, Defesa=18, Inteligencia=37, Classe=ClasseEnum.Mago },
            new Personagem() { Id = 5, Nome = "Hobbit", PontosVida=100, Forca=20, Defesa=17, Inteligencia=31, Classe=ClasseEnum.Cavaleiro },
            new Personagem() { Id = 6, Nome = "Celeborn", PontosVida=100, Forca=21, Defesa=13, Inteligencia=34, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 7, Nome = "Radagast", PontosVida=100, Forca=25, Defesa=11, Inteligencia=35, Classe=ClasseEnum.Mago }
        };

        // metodos
        [HttpGet("{nome}")]
        public IActionResult GetByNome (string nome){
            Personagem personagemNome = personagens.FirstOrDefault(p => p.Nome == nome);
            if (personagemNome == null){
                return NotFound("Não foi encontrado um personagem com esse nome");
            }
            else{
                return Ok(personagemNome);
            }
        }

        [HttpPost("PostValidacao")]
        public IActionResult PostValidacao (Personagem personagemAdicionado)
        {
            if(personagemAdicionado.Defesa < 10 || personagemAdicionado.Inteligencia > 30)
            {
                return BadRequest("A defesa precisa ser maior que 10 ou a inteligência menor que 30");
            }
            else{
                personagens.Add(personagemAdicionado);
                return Ok(personagens);
            }

        }

        [HttpPost("PostValidacaoMago")]
        public IActionResult PostValidacaoMago (Personagem personagemAdicionado)
        {
            if(personagemAdicionado.Inteligencia < 35)
            {
                return BadRequest("A inteligência precisa ser maior que 35");
            }
            else{
                personagens.Add(personagemAdicionado);
                return Ok(personagens);
            }

        }

        [HttpGet("GetEstatisticas")]
        public IActionResult GetEstatisticas()
        {
            int soma = personagens.Sum(p => p.Inteligencia);
            return Ok(personagens + " " + soma);
        }

    }

    }