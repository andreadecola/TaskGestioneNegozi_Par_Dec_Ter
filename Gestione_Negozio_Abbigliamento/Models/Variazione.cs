using System;
using System.Collections.Generic;

namespace Gestione_Negozio_Abbigliamento.Models;

public partial class Variazione
{
    public int VariazioneId { get; set; }

    public int? ProdottoRif { get; set; }

    public string? Colore { get; set; }

    public string? Taglia { get; set; }

    public int? Quantità { get; set; }

    public decimal? PrezzoPieno { get; set; }

    public decimal? PrezzoOfferta { get; set; }

    public DateOnly? DataInizioOfferta { get; set; }

    public DateOnly? DataFineOfferta { get; set; }

    public virtual ICollection<OrdineProdotto> OrdineProdottos { get; set; } = new List<OrdineProdotto>();

    public virtual Prodotto? ProdottoRifNavigation { get; set; }
}
