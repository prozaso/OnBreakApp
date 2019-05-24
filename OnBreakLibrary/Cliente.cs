using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreakLibrary
{
    public class Cliente
    {

        private String _rut;
        private String _razonSocial;
        private String _nombre;
        private String _mail;
        private String _direccion;
        private String _telefono;
        private int _idActividadEmpresa;
        private int _idTipoEmpresa;

        public Cliente(string rut, string razonSocial, string nombre, string mail, string direccion, string telefono, int idActividadEmpresa, int idTipoEmpresa)
        {
            Rut = rut;
            RazonSocial = razonSocial;
            Nombre = nombre;
            Mail = mail;
            Direccion = direccion;
            Telefono = telefono;
            IdActividadEmpresa = idActividadEmpresa;
            IdTipoEmpresa = idTipoEmpresa;
        }

        public Cliente()
        {

        }

        public string Rut
        {
            get
            {
                return _rut;
            }

            set
            {
                _rut = value;
            }
        }

        public string RazonSocial
        {
            get
            {
                return _razonSocial;
            }

            set
            {
                _razonSocial = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                _nombre = value;
            }
        }

        public string Mail
        {
            get
            {
                return _mail;
            }

            set
            {
                _mail = value;
            }
        }

        public string Direccion
        {
            get
            {
                return _direccion;
            }

            set
            {
                _direccion = value;
            }
        }

        public string Telefono
        {
            get
            {
                return _telefono;
            }

            set
            {
                _telefono = value;
            }
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

        public int IdTipoEmpresa
        {
            get
            {
                return _idTipoEmpresa;
            }

            set
            {
                _idTipoEmpresa = value;
            }
        }        
    }
}