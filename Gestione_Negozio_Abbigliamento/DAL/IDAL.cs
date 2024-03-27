using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Gestione_Negozio_Abbigliamento.DAL
{
    internal interface IDAL<T>
    {
        bool Insert(T t);
        List <T> findALL();
        T findById(int id);
        bool delete(int id);
        bool update(T t);

    }
}
