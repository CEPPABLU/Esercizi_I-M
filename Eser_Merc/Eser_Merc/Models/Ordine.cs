using System;
using System.Collections.Generic;

namespace Eser_Merc.Models;

public partial class Ordine
{
    public int OrdineId { get; set; }

    public int QuantitaOrd { get; set; }

    public DateTime DataOrd { get; set; }

    public int UtenteRif { get; set; }

    public DateTime? Deleted { get; set; }

    public virtual Utente UtenteRifNavigation { get; set; } = null!;
}
