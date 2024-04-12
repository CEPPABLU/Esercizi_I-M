namespace EserMarioKart.Models
{
    public class Personaggio
    {
        public int PersonaggioID { get; set; }
        public string CodiceP { get; set; } = Guid.NewGuid().ToString();

        public string? NomeP { get; set; }

        public string? Categoria { get; set; }
        public int? Costo { get; set; }

        public int? SquadraRIF { get; set; } // Chiave esterna
        public Squadra? SquadraRIFNavigation { get; set; }
    }
}
