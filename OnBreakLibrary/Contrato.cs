using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreakLibrary
{
    public class Contrato
    {

        private int _numero;
        private DateTime _creacionContrato;
        private DateTime _terminoContrato;
        private DateTime _inicioEvento;
        private DateTime _terminoEvento;
        private String _horaInicio;
        private String _horaTermino;
        private String _direccion;
        private bool _vigente;
        private int _tipo;
        private String _observaciones;
        private Cliente _cliente;
        private int _asistentes;
        private int _personalAdicional;
        private double _valorEvento;

        public int Numero
        {
            get
            {
                return _numero;
            }

            set
            {
                _numero = value;
            }
        }

        public DateTime CreacionContrato
        {
            get
            {
                return _creacionContrato;
            }

            set
            {
                _creacionContrato = value;
            }
        }

        public DateTime TerminoContrato
        {
            get
            {
                return _terminoContrato;
            }

            set
            {
                _terminoContrato = value;
            }
        }

        public DateTime InicioEvento
        {
            get
            {
                return _inicioEvento;
            }

            set
            {
                _inicioEvento = value;
            }
        }

        public DateTime TerminoEvento
        {
            get
            {
                return _terminoEvento;
            }

            set
            {
                _terminoEvento = value;
            }
        }

        public string HoraInicio
        {
            get
            {
                return _horaInicio;
            }

            set
            {
                _horaInicio = value;
            }
        }

        public string HoraTermino
        {
            get
            {
                return _horaTermino;
            }

            set
            {
                _horaTermino = value;
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

        public bool Vigente
        {
            get
            {
                return _vigente;
            }

            set
            {
                _vigente = value;
            }
        }

        public int Tipo
        {
            get
            {
                return _tipo;
            }

            set
            {
                _tipo = value;
            }
        }

        public string Observaciones
        {
            get
            {
                return _observaciones;
            }

            set
            {
                _observaciones = value;
            }
        }

        public Cliente Cliente
        {
            get
            {
                return _cliente;
            }

            set
            {
                _cliente = value;
            }
        }

        public int Asistentes
        {
            get
            {
                return _asistentes;
            }

            set
            {
                _asistentes = value;
            }
        }

        public int PersonalAdicional
        {
            get
            {
                return _personalAdicional;
            }

            set
            {
                _personalAdicional = value;
            }
        }

        public double ValorEvento
        {
            get
            {
                return _valorEvento;
            }

            set
            {
                _valorEvento = value;
            }
        }

        public Contrato(int numero, DateTime creacionContrato, DateTime terminoContrato, DateTime inicioEvento, DateTime terminoEvento, string horaInicio, string horaTermino, string direccion, bool vigente, int tipo, string observaciones, Cliente cliente, int asistentes, int personalAdicional, double valorEvento)
        {
            Numero = numero;
            CreacionContrato = creacionContrato;
            TerminoContrato = terminoContrato;
            InicioEvento = inicioEvento;
            TerminoEvento = terminoEvento;
            HoraInicio = horaInicio;
            HoraTermino = horaTermino;
            Direccion = direccion;
            Vigente = vigente;
            Tipo = tipo;
            Observaciones = observaciones;
            Cliente = cliente;
            Asistentes = asistentes;
            PersonalAdicional = personalAdicional;
            ValorEvento = valorEvento;
        }

        
    }
}
