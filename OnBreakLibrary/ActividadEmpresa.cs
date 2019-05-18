using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreakLibrary
{
    public class ActividadEmpresa
    {
        private int _idActividadEmpresa;
        private String _descripcion;

        public ActividadEmpresa()
        {

        }

        public ActividadEmpresa(int _idActividadEmpresa, string _descripcion)
        {
            this._idActividadEmpresa = _idActividadEmpresa;
            this._descripcion = _descripcion;
        }

        public int IdActividadEmpresa
        {
            get
            {
                return _idActividadEmpresa;
            }

            set
            {
                _idActividadEmpresa = value;
            }
        }

        public string Descripcion
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
    }
}
