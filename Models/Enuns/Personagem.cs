using RpgApiAvaliacao.Models.Enuns;
namespace RpgApiAvaliacao.Models.Enuns
{
    public class Personagem
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public int PontosVida { get; set; }
        public int Forca { get; set; }
        public int Defesa { get; set; }
        public int Inteligencia { get; set; }
        public ClasseEnum Classe { get; set; }
    }
}