using System;
using System.Collections.Generic;

namespace Gestione_Negozio_Abbigliamento.Models;

public partial class Categorium
{
    public int CategoriaId { get; set; }

    public string? Nome { get; set; }

    public virtual ICollection<Prodotto> Prodottos { get; set; } = new List<Prodotto>();
}
