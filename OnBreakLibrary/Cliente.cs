using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreakLibrary
{
    public class Cliente
    {

        private int _rut;
        private String _razonSocial;
        private String _nombre;
        private String _mail;
        private String _direccion;
        private String _telefono;
        private int _actividadEmpresa;
        private int _tipoEmpresa;

        public Cliente(int rut, string razonSocial, string nombre, string mail, string direccion, string telefono, int actividadEmpresa, int tipoEmpresa)
        {
            _rut = rut;
            _razonSocial = razonSocial;
            _nombre = nombre;
            _mail = mail;
            _direccion = direccion;
            _telefono = telefono;
            _actividadEmpresa = actividadEmpresa;
            _tipoEmpresa = tipoEmpresa;
        }

        public int Rut { get => _rut; set => _rut = value; }
        public string RazonSocial { get => _razonSocial; set => _razonSocial = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Mail { get => _mail; set => _mail = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public int ActividadEmpresa { get => _actividadEmpresa; set => _actividadEmpresa = value; }
        public int TipoEmpresa { get => _tipoEmpresa; set => _tipoEmpresa = value; }
    }
}
