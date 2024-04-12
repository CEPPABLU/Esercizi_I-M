using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EserEsa.Models;

[Table("Sistema")]
public partial class Sistema
{
    public int SistemaId { get; set; }

    public string Codice { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public virtual ICollection<OggettoCeleste> OggettoRifs { get; set; } = new List<OggettoCeleste>();
}
