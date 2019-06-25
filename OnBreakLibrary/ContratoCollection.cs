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

        //Listar todo
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
                        a.Observaciones,

                    }).ToList();
        }

        //Gestiones
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
                c.Creacion = contrato.Creacion;
                c.Termino = contrato.Termino;
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

        public bool TerminarContrato(Contrato contrato)
        {
            try
            {
                OnBreak.DALC.Contrato c = this.bd.Contrato.Find(contrato.Numero);
                c.Realizado = contrato.Realizado;

                this.bd.Entry(c).State = System.Data.EntityState.Modified;
                this.bd.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        //buscadores
        public Contrato BuscarContratoPorRut(string rut)
        {
            try
            {
                return (from c in this.bd.Contrato
                        where c.RutCliente == rut

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

        public Contrato BuscarContratoPorNumero(string numero)
        {
            try
            {
                return (from c in this.bd.Contrato
                        join cl in this.bd.Cliente
                            on c.RutCliente equals cl.RutCliente
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

        public Contrato BuscarContratoPorTipo(int tipoEvento)
        {
            try
            {
                return (from c in this.bd.Contrato
                        join m in this.bd.ModalidadServicio
                            on c.IdTipoEvento equals m.IdTipoEvento
                        join t in this.bd.TipoEvento
                            on m.IdTipoEvento equals t.IdTipoEvento
                        join cl in this.bd.Cliente
                            on c.RutCliente equals cl.RutCliente
                        where c.IdTipoEvento == tipoEvento

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

        //filtros
        public IEnumerable<Object> ContratoListarFiltroNumero(string numero)
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

        public IEnumerable<Object> ContratoListarFiltroRutCliente(string rutCliente)
        {
            try
            {
                return (from c in this.bd.Contrato
                        join cl in this.bd.Cliente
                            on c.RutCliente equals cl.RutCliente
                        join m in this.bd.ModalidadServicio
                            on c.IdModalidad equals m.IdModalidad
                        join t in this.bd.TipoEvento
                            on c.IdTipoEvento equals t.IdTipoEvento
                        let Rut = cl.RutCliente
                        let Modalidad = m.Nombre.Trim()
                        let Evento = t.Descripcion
                        let HoraInicio = c.FechaHoraInicio
                        let HoraTermino = c.FechaHoraTermino
                            where c.RutCliente == rutCliente

                        select new
                        {
                            c.Numero,
                            c.Creacion,
                            c.Termino,
                            cl.RutCliente,
                            Modalidad,
                            Evento,
                            HoraInicio,
                            HoraTermino,
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
                            where a.IdTipoEvento == tipoEvento

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




    }
}
