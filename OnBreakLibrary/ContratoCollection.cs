using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OnBreak.DALC;
using System.Windows;

namespace OnBreakLibrary
{
    public class ContratoCollection
    {

        OnBreakEntities bd = new OnBreakEntities();

        private List<int> _asistentes = new List<int>();
        private List<int> _personalAdicional = new List<int>();


        public IEnumerable<Object> ReadAll()
        {
            return (from a in this.bd.Contrato
                    join b in this.bd.Cliente
                        on a.RutCliente equals b.RutCliente
                    join c in this.bd.ModalidadServicio
                        on a.IdModalidad equals c.IdModalidad
                    join d in this.bd.TipoEvento
                        on a.IdTipoEvento equals d.IdTipoEvento
                    let Rut = b.RutCliente
                    let Modalidad = c.Nombre
                    let Evento = d.Descripcion
                    let HoraInicio = a.FechaHoraInicio
                    let HoraTermino = a.FechaHoraTermino

                    select new
                    {
                        a.Numero,
                        a.Creacion,
                        a.Termino,
                        b.RutCliente,
                        c.Nombre,
                        d.Descripcion,
                        HoraInicio,
                        HoraTermino,
                        a.Asistentes,
                        a.PersonalAdicional,
                        a.Realizado,
                        a.ValorTotalContrato,
                        a.Observaciones

                    }).ToList();
        }

        public Contrato BuscarContratoPorNumero(string numero)
        {
            try
            {
                return (from c in this.bd.Contrato
                        where c.Numero == numero
                        select new Contrato()
                        {

                            Numero = c.Numero,
                            Creacion = c.Creacion,
                            Termino = c.Termino,
                            RutCliente = c.RutCliente,
                            IdModalidad = c.IdModalidad,
                            IdTipoEvento = c.IdTipoEvento,
                            FechaHoraInicio = c.FechaHoraInicio,
                            FechaHoraTermino = c.FechaHoraTermino,
                            Asistentes = c.Asistentes,
                            PersonalAdicional = c.PersonalAdicional,
                            Realizado = c.Realizado,
                            ValorTotalContrato = c.ValorTotalContrato,
                            Observaciones = c.Observaciones

                        }).First();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool CrearContrato(Contrato contrato)
        {
            try
            {
                OnBreak.DALC.Contrato c = new OnBreak.DALC.Contrato();


                c.Numero = contrato.Numero;
                c.Creacion = contrato.Creacion;
                c.Termino = contrato.Termino;
                c.RutCliente = contrato.RutCliente;
                c.IdModalidad = contrato.IdModalidad;
                c.IdTipoEvento = contrato.IdTipoEvento;
                c.FechaHoraInicio = contrato.FechaHoraInicio;
                c.FechaHoraTermino = contrato.FechaHoraTermino;
                c.Asistentes = contrato.Asistentes;
                c.PersonalAdicional = contrato.PersonalAdicional;
                c.Realizado = contrato.Realizado;
                c.ValorTotalContrato = contrato.ValorTotalContrato;
                c.Observaciones = contrato.Observaciones;


                this.bd.Contrato.Add(c);
                this.bd.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ModificarContrato(Contrato contrato)
        {
            try
            {
                OnBreak.DALC.Contrato c = this.bd.Contrato.Find(contrato.Numero);
                c.Numero = contrato.Numero;
                c.RutCliente = contrato.RutCliente;
                c.IdModalidad = contrato.IdModalidad;
                c.IdTipoEvento = contrato.IdTipoEvento;
                c.FechaHoraInicio = contrato.FechaHoraInicio;
                c.FechaHoraTermino = contrato.FechaHoraTermino;
                c.Asistentes = contrato.Asistentes;
                c.PersonalAdicional = contrato.PersonalAdicional;
                c.ValorTotalContrato = contrato.ValorTotalContrato;
                c.Observaciones = contrato.Observaciones;

                this.bd.Entry(c).State = System.Data.EntityState.Modified;
                this.bd.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }


        public List<int> CantidadAsistentes()
        {

            for (int i = 0; i < 50; i++)
            {
                _asistentes.Add(i);
            }

            return _asistentes;
        }

        public List<int> PersonalAdicional()
        {

            for (int i = 0; i < 50; i++)
            {
                _personalAdicional.Add(i);
            }

            return _personalAdicional;
        }







    }
}
