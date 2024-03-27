using System;
using System.Collections.Generic;

namespace Eser_Merc.Models;

public partial class Prodotto
{
    public int ProdottoId { get; set; }

    public string Marca { get; set; } = null!;

    public string Descrizione { get; set; } = null!;

    public string? Image { get; set; }

    public int CategoriaRif { get; set; }

    public DateTime? Deleted { get; set; }

    public virtual Categorium CategoriaRifNavigation { get; set; } = null!;

    public virtual ICollection<Variazione> Variaziones { get; set; } = new List<Variazione>();
}
