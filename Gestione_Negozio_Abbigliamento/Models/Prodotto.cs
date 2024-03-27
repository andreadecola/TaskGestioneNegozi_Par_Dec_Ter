using System;
using System.Collections.Generic;

namespace Gestione_Negozio_Abbigliamento.Models;

public partial class Prodotto
{
    public int ProdottoId { get; set; }

    public string? Nome { get; set; }

    public string? Descrizione { get; set; }

    public int? CategoriaRif { get; set; }

    public virtual Categorium? CategoriaRifNavigation { get; set; }

    public virtual ICollection<OrdineProdotto> OrdineProdottos { get; set; } = new List<OrdineProdotto>();

    public virtual ICollection<Variazione> Variaziones { get; set; } = new List<Variazione>();
}
