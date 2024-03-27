using Gestione_Negozio_Abbigliamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestione_Negozio_Abbigliamento.DAL
{
    internal class UtenteDAL : IDAL<Utente>
    {
        public bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Utente> findALL()
        {
            throw new NotImplementedException();
        }

        public Utente findById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Utente t)
        {
            bool risultato = false;
            using(TaskGestioneNegozioAbbigliamentoContext ctx = new TaskGestioneNegozioAbbigliamentoContext())
            {
                ctx.Utentes.Add(t);
            }
        }

        public bool update(Utente t)
        {
            throw new NotImplementedException();
        }
    }
}
