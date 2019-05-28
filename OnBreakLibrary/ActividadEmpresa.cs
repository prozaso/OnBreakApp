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
        private string _descripcion;


        public ActividadEmpresa()
        {

        }

        public ActividadEmpresa(int _idActividadEmpresa, string _descripcion)
        {
            IdActividadEmpresa = _idActividadEmpresa;
            Descripcion = _descripcion;
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
