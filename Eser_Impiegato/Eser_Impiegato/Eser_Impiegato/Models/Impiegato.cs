using System;
using System.Collections.Generic;

namespace Eser_Impiegato.Models;

public partial class Impiegato
{
    public int ImpiegatoId { get; set; }

    public string Matricola { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string Cognome { get; set; } = null!;

    public DateOnly DataNascita { get; set; }

    public string Ruolo { get; set; } = null!;

    public string Reparto { get; set; } = null!;

    public string IndirizzoResidenza { get; set; } = null!;

    public string CittaResidenza { get; set; } = null!;

    public string ProvinciaResidenza { get; set; } = null!;
}
