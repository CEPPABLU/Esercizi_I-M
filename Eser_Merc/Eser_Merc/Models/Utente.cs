using System;
using System.Collections.Generic;

namespace Eser_Merc.Models;

public partial class Utente
{
    public int UtenteId { get; set; }

    public string Nominativo { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordUtente { get; set; } = null!;

    public DateTime? Deleted { get; set; }

    public virtual ICollection<Ordine> Ordines { get; set; } = new List<Ordine>();
}
