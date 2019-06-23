using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBreak.DALC;

namespace OnBreakLibrary
{
    public class ClienteCollection
    {

        OnBreakEntities bd = new OnBreakEntities();

        public IEnumerable<Object> ReadAll()
        {
            return (from c in this.bd.Cliente
                    join a in this.bd.ActividadEmpresa on c.IdActividadEmpresa equals a.IdActividadEmpresa
                    join t in this.bd.TipoEmpresa on c.IdTipoEmpresa equals t.IdTipoEmpresa
                    let RUT = c.RutCliente
                    let Contacto = c.NombreContacto
                    let Mail = c.MailContacto
                    let Actividad = a.Descripcion
                    let TipoEmpresa = t.Descripcion

                    select new
                    {
                        RUT,
                        c.RazonSocial,
                        Contacto,
                        Mail,
                        c.Direccion,
                        c.Telefono,
                        Actividad,
                        TipoEmpresa

                    }).ToList();
        }

        public bool AgregarCliente(Cliente cliente)
        {
            try
            {
                OnBreak.DALC.Cliente c = new OnBreak.DALC.Cliente();


                c.RutCliente = cliente.RutCliente;
                c.RazonSocial = cliente.RazonSocial;
                c.NombreContacto = cliente.NombreContacto;
                c.MailContacto = cliente.MailContacto;
                c.Direccion = cliente.Direccion;
                c.Telefono = cliente.Telefono;
                c.IdActividadEmpresa = cliente.IdActividadEmpresa;
                c.IdTipoEmpresa = cliente.IdTipoEmpresa;

                this.bd.Cliente.Add(c);
                this.bd.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ModificarCliente(Cliente cliente)
        {
            try
            {
                OnBreak.DALC.Cliente c = this.bd.Cliente.Find(cliente.RutCliente);
                c.RazonSocial = cliente.RazonSocial;
                c.NombreContacto = cliente.NombreContacto;
                c.MailContacto = cliente.MailContacto;
                c.Direccion = cliente.Direccion;
                c.Telefono = cliente.Telefono;
                c.IdActividadEmpresa = cliente.IdActividadEmpresa;
                c.IdTipoEmpresa = cliente.IdTipoEmpresa;

                this.bd.Entry(c).State = System.Data.EntityState.Modified;
                this.bd.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool EliminarCliente(string rut)
        {
            try
            {
                OnBreak.DALC.Cliente c = bd.Cliente.Find(rut);
                bd.Cliente.Remove(c);
                bd.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Cliente BuscarClientePorRut(string rut)
        {
            try
            {
                return (from c in this.bd.Cliente
                        where c.RutCliente == rut
                        select new Cliente()
                        {

                            RutCliente = c.RutCliente,
                            RazonSocial = c.RazonSocial,
                            NombreContacto = c.NombreContacto,
                            MailContacto = c.MailContacto,
                            Direccion = c.Direccion,
                            Telefono = c.Telefono,
                            IdActividadEmpresa = c.IdActividadEmpresa,
                            IdTipoEmpresa = c.IdTipoEmpresa

                        }).First();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Cliente BuscarClientePorTipo(int tipo)
        {
            try
            {
                return (from c in this.bd.Cliente
                        where c.IdTipoEmpresa == tipo
                        select new Cliente()
                        {

                            RutCliente = c.RutCliente,
                            RazonSocial = c.RazonSocial,
                            NombreContacto = c.NombreContacto,
                            MailContacto = c.MailContacto,
                            Direccion = c.Direccion,
                            Telefono = c.Telefono,
                            IdActividadEmpresa = c.IdActividadEmpresa,
                            IdTipoEmpresa = c.IdTipoEmpresa

                        }).First();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Cliente BuscarClientePorActividad(int actividad)
        {
            try
            {
                return (from c in this.bd.Cliente
                        where c.IdActividadEmpresa == actividad
                        select new Cliente()
                        {

                            RutCliente = c.RutCliente,
                            RazonSocial = c.RazonSocial,
                            NombreContacto = c.NombreContacto,
                            MailContacto = c.MailContacto,
                            Direccion = c.Direccion,
                            Telefono = c.Telefono,
                            IdActividadEmpresa = c.IdActividadEmpresa,
                            IdTipoEmpresa = c.IdTipoEmpresa

                        }).First();
            }
            catch (Exception)
            {

                return null;
            }
        }


        public IEnumerable<Object> ClienteFiltrarPorRut(string rut)
        {
            try
            {
                return (from c in this.bd.Cliente
                        join a in this.bd.ActividadEmpresa on c.IdActividadEmpresa equals a.IdActividadEmpresa
                        join t in this.bd.TipoEmpresa on c.IdTipoEmpresa equals t.IdTipoEmpresa
                        let RUT = c.RutCliente
                        let Contacto = c.NombreContacto
                        let Mail = c.MailContacto
                        let Actividad = a.Descripcion
                        let TipoEmpresa = t.Descripcion
                            where c.RutCliente == rut

                        select new
                        {
                            RUT,
                            c.RazonSocial,
                            Contacto,
                            Mail,
                            c.Direccion,
                            c.Telefono,
                            Actividad,
                            TipoEmpresa

                        }).ToList();
            }
            catch (Exception)
            {

                return null;
            }
        }


        public IEnumerable<Object> ClienteFiltrarPorTipo(int tipoEmpresa)
        {
            try
            {
                return (from c in this.bd.Cliente
                        join a in this.bd.ActividadEmpresa on c.IdActividadEmpresa equals a.IdActividadEmpresa
                        join t in this.bd.TipoEmpresa on c.IdTipoEmpresa equals t.IdTipoEmpresa
                        let RUT = c.RutCliente
                        let Contacto = c.NombreContacto
                        let Mail = c.MailContacto
                        let Actividad = a.Descripcion
                        let TipoEmpresa = t.Descripcion
                            where c.IdTipoEmpresa == tipoEmpresa

                        select new
                        {
                            RUT,
                            c.RazonSocial,
                            Contacto,
                            Mail,
                            c.Direccion,
                            c.Telefono,
                            Actividad,
                            TipoEmpresa

                        }).ToList();
            }
            catch (Exception)
            {

                return null;
            }
        }


        public IEnumerable<Object> ClienteFiltrarPorActividad(int actividad)
        {
            try
            {
                return (from c in this.bd.Cliente
                        join a in this.bd.ActividadEmpresa on c.IdActividadEmpresa equals a.IdActividadEmpresa
                        join t in this.bd.TipoEmpresa on c.IdTipoEmpresa equals t.IdTipoEmpresa
                        let RUT = c.RutCliente
                        let Contacto = c.NombreContacto
                        let Mail = c.MailContacto
                        let Actividad = a.Descripcion
                        let TipoEmpresa = t.Descripcion
                        where c.IdActividadEmpresa == actividad

                        select new
                        {
                            RUT,
                            c.RazonSocial,
                            Contacto,
                            Mail,
                            c.Direccion,
                            c.Telefono,
                            Actividad,
                            TipoEmpresa

                        }).ToList();
            }
            catch (Exception)
            {

                return null;
            }

            
        }


    }
}