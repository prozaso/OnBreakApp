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
                    let Modalidad = c.Nombre.Trim()
                    let Evento = d.Descripcion
                    let HoraInicio = a.FechaHoraInicio
                    let HoraTermino = a.FechaHoraTermino


                    select new
                    {
                        a.Numero,
                        a.Creacion,
                        a.Termino,
                        b.RutCliente,
                        Modalidad,
                        Evento,
                        HoraInicio,
                        HoraTermino,
                        a.Asistentes,
                        a.PersonalAdicional,
                        a.Realizado,
                        a.ValorTotalContrato,
                        a.Observaciones

                    }).ToList();
        }

        public IEnumerable<Object> BuscarContratoPorNumero(string numero)
        {
            try
            {
                return (from a in this.bd.Contrato
                        join b in this.bd.Cliente
                            on a.RutCliente equals b.RutCliente
                        join c in this.bd.ModalidadServicio
                            on a.IdModalidad equals c.IdModalidad
                        join d in this.bd.TipoEvento
                            on a.IdTipoEvento equals d.IdTipoEvento
                        let Rut = b.RutCliente
                        let Modalidad = c.Nombre.Trim()
                        let Evento = d.Descripcion
                        let HoraInicio = a.FechaHoraInicio
                        let HoraTermino = a.FechaHoraTermino
                        where a.Numero == numero

                        select new 
                        {
                            a.Numero,
                            a.Creacion,
                            a.Termino,
                            b.RutCliente,
                            Modalidad,
                            Evento,
                            HoraInicio,
                            HoraTermino,
                            a.Asistentes,
                            a.PersonalAdicional,
                            a.Realizado,
                            a.ValorTotalContrato,
                            a.Observaciones

                        }).ToList();
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

        public IEnumerable<Object> ContratoListarFiltroNumero(string numero)
        {
            try
            {
                return (from a in this.bd.Contrato
                        where a.Numero == numero

                        select new
                        {
                            a.Numero,
                            a.Creacion,
                            a.Termino,
                            a.RutCliente,
                            a.FechaHoraInicio,
                            a.FechaHoraTermino,
                            a.Asistentes,
                            a.PersonalAdicional,
                            a.Realizado,
                            a.ValorTotalContrato,
                            a.Observaciones

                        }).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public IEnumerable<Object> ContratoListarFiltroRutCliente(string rutCliente)
        {
            try
            {
                return (from c in this.bd.Contrato
                        where c.RutCliente == rutCliente

                        select new
                        {
                            c.Numero,
                            c.Creacion,
                            c.Termino,
                            c.RutCliente,
                            c.IdModalidad,
                            c.IdTipoEvento,
                            c.FechaHoraInicio,
                            c.FechaHoraTermino,
                            c.Asistentes,
                            c.PersonalAdicional,
                            c.Realizado,
                            c.ValorTotalContrato,
                            c.Observaciones

                        }).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public IEnumerable<Object> ContratoListarFiltroTipoEvento(int tipoEvento)
        {
            try
            {
                return (from c in this.bd.Contrato
                        join m in this.bd.ModalidadServicio on c.IdModalidad equals m.IdModalidad
                        join t in this.bd.TipoEvento on c.IdTipoEvento equals t.IdTipoEvento
                        where c.IdTipoEvento == tipoEvento

                        select new
                        {
                            c.Numero,
                            c.Creacion,
                            c.Termino,
                            c.RutCliente,
                            m.Nombre,
                            t.IdTipoEvento,
                            c.FechaHoraInicio,
                            c.FechaHoraTermino,
                            c.Asistentes,
                            c.PersonalAdicional,
                            c.Realizado,
                            c.ValorTotalContrato,
                            c.Observaciones

                        }).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<Object> ContratoBuscarPorRut(string rut)
        {
            try
            {
                return (from c in this.bd.Contrato
                        join m in this.bd.ModalidadServicio on c.IdModalidad equals m.IdModalidad
                        join t in this.bd.TipoEvento on c.IdTipoEvento equals t.IdTipoEvento
                        where c.RutCliente == rut

                        select new
                        {
                            c.Numero,
                            c.Creacion,
                            c.Termino,
                            c.RutCliente,
                            m.Nombre,
                            t.IdTipoEvento,
                            c.FechaHoraInicio,
                            c.FechaHoraTermino,
                            c.Asistentes,
                            c.PersonalAdicional,
                            c.Realizado,
                            c.ValorTotalContrato,
                            c.Observaciones

                        }).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }


    }
}
