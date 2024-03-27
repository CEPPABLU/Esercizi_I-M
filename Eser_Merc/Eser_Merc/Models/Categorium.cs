using System;
using System.Collections.Generic;

namespace Eser_Merc.Models;

public partial class Categorium
{
    public int CategoriaId { get; set; }

    public string Nome { get; set; } = null!;

    public DateTime? Deleted { get; set; }

    public virtual ICollection<Prodotto> Prodottos { get; set; } = new List<Prodotto>();
}
