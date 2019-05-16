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

        public Contrato(int numero, DateTime creacionContrato, DateTime terminoContrato, DateTime inicioEvento, DateTime terminoEvento, string horaInicio, string horaTermino, string direccion, bool vigente, int tipo, string observaciones, Cliente cliente, int asistentes, int personalAdicional, double valorEvento)
        {
            _numero = numero;
            _creacionContrato = creacionContrato;
            _terminoContrato = terminoContrato;
            _inicioEvento = inicioEvento;
            _terminoEvento = terminoEvento;
            _horaInicio = horaInicio;
            _horaTermino = horaTermino;
            _direccion = direccion;
            _vigente = vigente;
            _tipo = tipo;
            _observaciones = observaciones;
            _cliente = cliente;
            _asistentes = asistentes;
            _personalAdicional = personalAdicional;
            _valorEvento = valorEvento;
        }

        public int Numero { get => _numero; set => _numero = value; }
        public DateTime CreacionContrato { get => _creacionContrato; set => _creacionContrato = value; }
        public DateTime TerminoContrato { get => _terminoContrato; set => _terminoContrato = value; }
        public DateTime InicioEvento { get => _inicioEvento; set => _inicioEvento = value; }
        public DateTime TerminoEvento { get => _terminoEvento; set => _terminoEvento = value; }
        public string HoraInicio { get => _horaInicio; set => _horaInicio = value; }
        public string HoraTermino { get => _horaTermino; set => _horaTermino = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public bool Vigente { get => _vigente; set => _vigente = value; }
        public int Tipo { get => _tipo; set => _tipo = value; }
        public string Observaciones { get => _observaciones; set => _observaciones = value; }
        public Cliente Cliente { get => _cliente; set => _cliente = value; }
        public int Asistentes { get => _asistentes; set => _asistentes = value; }
        public int PersonalAdicional { get => _personalAdicional; set => _personalAdicional = value; }
        public double ValorEvento { get => _valorEvento; set => _valorEvento = value; }
    }
}
