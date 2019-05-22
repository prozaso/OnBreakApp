using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBreak.DALC;

namespace OnBreakLibrary
{
    public class ModalidadServicioCollection
    {

        OnBreakEntities bd = new OnBreakEntities();

        public List<ModalidadServicio> ListaModalidadServicio()
        {
            return (from t in this.bd.ModalidadServicio
                    select new ModalidadServicio()
                    {
                        IdTipoEvento = t.IdTipoEvento,
                        Nombre = t.Nombre.Trim()
                    }).ToList();
        }
    }
}