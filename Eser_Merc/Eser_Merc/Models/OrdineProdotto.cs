using System;
using System.Collections.Generic;

namespace Eser_Merc.Models;

public partial class OrdineProdotto
{
    public int ProdottoRif { get; set; }

    public int UtenteRif { get; set; }

    public int VariazioneRif { get; set; }

    public virtual Prodotto ProdottoRifNavigation { get; set; } = null!;

    public virtual Utente UtenteRifNavigation { get; set; } = null!;

    public virtual Variazione VariazioneRifNavigation { get; set; } = null!;
}
