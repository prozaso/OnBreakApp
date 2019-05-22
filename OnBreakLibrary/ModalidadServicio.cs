using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreakLibrary
{
    public class ModalidadServicio
    {

        private string _idModalidad;
        private int _idTipoEvento;
        private string _nombre;
        private float _valorBase;
        private int _personalBase;

        public ModalidadServicio(string idModalidad, int idTipoEvento, string nombre, float valorBase, int personalBase)
        {
            IdModalidad = idModalidad;
            IdTipoEvento = idTipoEvento;
            Nombre = nombre;
            ValorBase = valorBase;
            PersonalBase = personalBase;
        }

        public ModalidadServicio()
        {

        }

        public int PersonalBase
        {
            get
            {
                return _personalBase;
            }
            set
            {
                _personalBase = value;
            }
        }

        public float ValorBase
        {
            get
            {
                return _valorBase;
            }
            set
            {
                _valorBase = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _nombre.Trim();
            }
            set
            {
                _nombre = value.Trim();
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

        public string IdModalidad
        {
            get
            {
                return _idModalidad;
            }
            set
            {
                _idModalidad = value;
            }
        }
    }
}
