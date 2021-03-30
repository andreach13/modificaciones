using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Entregas
{
    public class FacturaBL
    {
        Contexto _contexto;

        public BindingList<Factura> ListaFacturas { get; set; }

        public FacturaBL()
        {
            _contexto = new Contexto();
        }

        public  BindingList<Factura> ObtenerFacturas()
        {
            _contexto.Facturas.Include("FacturaDetalle").Load();
            ListaFacturas = _contexto.Facturas.Local.ToBindingList();

            return ListaFacturas;
        }

        public void AgregarFactura()
        {
            var nuevaFactura = new Factura();
            _contexto.Facturas.Add(nuevaFactura);
        }

        public void CancelarCambios()
        {
            foreach (var item in _contexto.ChangeTracker.Entries())
            {
                item.State = EntityState.Unchanged;
                item.Reload();
            }
        }

        public Comprobar GuardarFactura(Factura factura)
        {
            var resultado = Validar(factura);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }            
            _contexto.SaveChanges();
            resultado.Exitoso = true;
            return resultado;
        }


        private Comprobar Validar(Factura factura)
        {
            var resultado = new Comprobar();
            resultado.Exitoso = true;

            return resultado;
        }

        public bool AnularFactura(int id)
        {
            foreach (var factura in ListaFacturas)
            {
                if (factura.Id == id)
                {
                    factura.Activo = false;

                    _contexto.SaveChanges();
                    return true;
                }
            }
            return false;
        }


    }

    public class Factura
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public Clientes Cliente { get; set; }
        public BindingList<FacturaDetalle> FacturaDetalle { get; set; }
        //public double Subtotal { get; set; }
        //public double Impuesto { get; set; }
        //public double Total { get; set; }
        public bool Activo { get; set; }

        public Factura()
        {
            Fecha = DateTime.Now;
            Activo = true;
            FacturaDetalle = new BindingList<FacturaDetalle>();
        }
    }


    public class FacturaDetalle
    {
        public int Id { get; set; }
        public int EntregaId { get; set; }
        public Entrega Delivery { get; set; }
    }

    public class Comprobar
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
    }
}
