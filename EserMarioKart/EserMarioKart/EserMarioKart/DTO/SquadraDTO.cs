using EserMarioKart.Models;

namespace EserMarioKart.DTO
{
    public class SquadraDTO
    {
        public string Code { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public int Budg { get; set; }
        public List<Personaggio> Pers { get; set; } = new List<Personaggio>();
    }
}
