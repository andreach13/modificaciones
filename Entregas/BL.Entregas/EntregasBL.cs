using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Entregas
{
    public class EntregasBL
    {
        public BindingList<Entregas> ListaEntregas { get; set; }

        public EntregasBL()
        {
            ListaEntregas = new BindingList<Entregas>();

        }

        public BindingList<Entregas> ObtenerEntregas()
        {
            return ListaEntregas;
        }
    }

    public class Entregas: EntregasDetalle
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public Clientes Cliente { get; set; }

    }

    public class EntregasDetalle
    {
        public string TipoPaquete { get; set; }
        public double Peso { get; set; }
        public double Costo { get; set; }
        public double Subtotal { get; set; }
        public double Impuesto { get; set; }
        public double Total { get; set; }
        public string FormadePago { get; set; }
        public string EstadodePago { get; set; }
        public string Status { get; set; }
        public string Descripcion { get; set; }
    }
    
}
