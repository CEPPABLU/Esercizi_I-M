using System;
using System.Collections.Generic;

namespace Eser_Merc.Models;

public partial class Variazione
{
    public int VariazioneId { get; set; }

    public string Colore { get; set; } = null!;

    public string Taglia { get; set; } = null!;

    public int QuantitaStock { get; set; }

    public bool? IsDisponibile { get; set; }

    public decimal Prezzo { get; set; }

    public decimal? PrezzoOf { get; set; }

    public DateTime? DataInScon { get; set; }

    public DateTime? DataFinScon { get; set; }

    public int ProdottoRif { get; set; }

    public DateTime? Deleted { get; set; }

    public virtual Prodotto ProdottoRifNavigation { get; set; } = null!;
}
