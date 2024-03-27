using System;
using System.Collections.Generic;

namespace Gestione_Negozio_Abbigliamento.Models;

public partial class Ordine
{
    public int OrdineId { get; set; }

    public int? UtenteRif { get; set; }

    public DateOnly? DataOrdine { get; set; }

    public string? Stato { get; set; }

    public virtual ICollection<OrdineProdotto> OrdineProdottos { get; set; } = new List<OrdineProdotto>();

    public virtual Utente? UtenteRifNavigation { get; set; }
}
