using System;
using System.Collections.Generic;

namespace Eser_Impiegato.Models;

public partial class ProvinciaResidenza
{
    public int ProvinciaResidenzaId { get; set; }

    public string NomeProvincia { get; set; } = null!;

    public string Sigla { get; set; } = null!;

    public virtual ICollection<CittaResidenza> CittaResidenzas { get; set; } = new List<CittaResidenza>();
}
