using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreakLibrary
{
    public class TipoEvento
    {

        private int _idTipoEvento;
        private string _descripcion;

        public TipoEvento()
        {

        }

        public TipoEvento(int idTipoEvento, string descripcion)
        {
            IdTipoEvento = idTipoEvento;
            Descripcion = descripcion;
        }

        private string Descripcion
        {
            get
            {
                return _descripcion;
            }
            set
            {
                _descripcion = value;
            }
        }

        public int IdTipoEvento
        {
            get
            {
                return _idTipoEvento;
            }
            set
            {
                _idTipoEvento = value;
            }
        }
    }
}
