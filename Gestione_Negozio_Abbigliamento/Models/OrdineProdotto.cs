using System;
using System.Collections.Generic;

namespace Gestione_Negozio_Abbigliamento.Models;

public partial class OrdineProdotto
{
    public int OrdineRif { get; set; }

    public int ProdottoRif { get; set; }

    public int VariazioneRif { get; set; }

    public int? Quantità { get; set; }

    public virtual Ordine OrdineRifNavigation { get; set; } = null!;

    public virtual Prodotto ProdottoRifNavigation { get; set; } = null!;

    public virtual Variazione VariazioneRifNavigation { get; set; } = null!;
}
