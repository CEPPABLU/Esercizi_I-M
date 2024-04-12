namespace EserMarioKart.Models
{
    public class Squadra
    {
        public int SquadraID { get; set; }
        public string CodiceS { get; set; } = Guid.NewGuid().ToString();
        public string? NomeS { get; set; }
        public int Budget { get; set; } = 10;
        public List<Personaggio> Personaggios { get; } = new List<Personaggio>();
    }
}
