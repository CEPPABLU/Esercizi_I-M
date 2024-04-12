using EserMarioKart.Models;

namespace EserMarioKart.DTO
{
    public class PersonaggioDTO
    {
        public string Code { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public string Cate { get; set; } = null!;
        public int? Cost { get; set; }
        public int? SqRif { get; set; }
        public Squadra? Squa { get; set; }
    }
}
