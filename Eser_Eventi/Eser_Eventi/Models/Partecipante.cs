using System;
using System.Collections.Generic;

namespace Eser_Eventi.Models;

public partial class Partecipante
{
    public int PartecipanteId { get; set; }

    public string Nome { get; set; } = null!;

    public string Contatto { get; set; } = null!;

    public string Biglietto { get; set; } = null!;

    public int EventoRif { get; set; }

    public DateTime? Deleted { get; set; }

    public virtual Evento EventoRifNavigation { get; set; } = null!;
}
