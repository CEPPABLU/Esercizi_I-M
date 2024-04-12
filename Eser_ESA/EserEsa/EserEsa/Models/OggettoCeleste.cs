using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EserEsa.Models;

[Table("OggettoCeleste")]
public partial class OggettoCeleste
{
    public int OggettoId { get; set; }

    public string Nome { get; set; } = null!;

    public string Codice { get; set; } = null!;

    public DateOnly DataScoperta { get; set; }

    public string Scopritore { get; set; } = null!;

    public string Tipologia { get; set; } = null!;

    public decimal Distanza { get; set; }

    public decimal AngoloPolare { get; set; }

    public decimal DistanzaRadiale { get; set; }

    public virtual ICollection<Sistema> SistemaRifs { get; set; } = new List<Sistema>();
}
