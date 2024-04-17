using System;
using System.Collections.Generic;

namespace Eser_Impiegato.Models;

public partial class CittaResidenza
{
    public int CittaResidenzaId { get; set; }

    public string NomeCitta { get; set; } = null!;

    public int ProvinciaRif { get; set; }

    public virtual ProvinciaResidenza ProvinciaRifNavigation { get; set; } = null!;
}
