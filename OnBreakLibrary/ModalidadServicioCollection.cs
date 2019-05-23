using System;
using System.Collections;
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


        public List<ModalidadServicio> BuscarModalidad(int modalidad)
        {
            return (from t in this.bd.ModalidadServicio
                    where t.IdTipoEvento == modalidad
                    select new ModalidadServicio()
                    {
                        IdTipoEvento = t.IdTipoEvento,
                        Nombre = t.Nombre.Trim()
                    }).ToList();
        }

        //public List<ModalidadServicio> BuscarModalidad(int IdTipoEvento)
        //{

        //    return (from c in this.bd.ModalidadServicio
        //            where c.IdTipoEvento == IdTipoEvento
        //            select new ModalidadServicio()
        //            {

        //                IdTipoEvento = c.IdTipoEvento,
        //                Nombre = c.Nombre

        //            }).ToList();

        //}
    }
}