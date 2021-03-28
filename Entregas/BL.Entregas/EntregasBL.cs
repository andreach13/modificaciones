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
        public BindingList<Entrega> ListaEntregas { get; set; }

        public EntregasBL()
        {
            ListaEntregas = new BindingList<Entrega>();

        }

        public BindingList<Entrega> ObtenerEntregas()
        {
            return ListaEntregas;
        }


        //BOTONES DE GUARDAR 
        public bool GuardarEntrega(Entrega entrega)
        {
            if (entrega.Id == 0)
            {
                entrega.Id = ListaEntregas.Max(item => item.Id)+1;
            }
            return true;
        }


        

        // Funcion AGREGAMOS UN NUEVA ENTREGA
        public void AgregarEntrega()
        {
            var nuevaEntrega = new Entrega();
            ListaEntregas.Add(nuevaEntrega);
        }


        //BOTONES DE Eliminar
        public bool EliminarEntrega(int Id)
        {
            foreach (var entrega in ListaEntregas)
            {
                if (entrega.Id == Id)
                {
                    ListaEntregas.Remove(entrega);
                    return true;
                }
            }
            return false;
        }

        private Comprobacion Validar(Entrega entrega)
        {
            var resultado = new Comprobacion();
            resultado.Exitoso = true;

            if (entrega.Cliente.NombredeEmpresa == "")
            {
                resultado.Mensaje = "Ingrese el nombre del remitente";
                resultado.Exitoso = false;
            }
            if (entrega.Cliente.Direccion == "")
            {
                resultado.Mensaje = "Ingrese una direccion de entrega";
                resultado.Exitoso = false;
            }
            if (entrega.TipoPaquete == "")
            {
                resultado.Mensaje = "Especifique que paquete se envía";
                resultado.Exitoso = false;
            }
            if (entrega.EstadodePago == "")
            {
                resultado.Mensaje = "Especifique el estado del pago sobre el envio";
                resultado.Exitoso = false;
            }
            if (entrega.EstadodePago == "")
            {
                resultado.Mensaje = "Especifique la forma de pago";
                resultado.Exitoso = false;
            }
            if (entrega.Status != true)
            {
                resultado.Mensaje = "Indique el status del envio";
                resultado.Exitoso = false;
            }



            return resultado;
        }

    }

    public class Entrega: EntregaDetalles
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public Clientes Cliente { get; set; }
    }

    public class EntregaDetalles
    {
        public string TipoPaquete { get; set; }
        public double Peso { get; set; }
        public double Costo { get; set; }
        public double Subtotal { get; set; }
        public double Impuesto { get; set; }
        public double Total { get; set; }
        public string FormadePago { get; set; }
        public string EstadodePago { get; set; }
        public bool Status { get; set; }
        public string Observaciones { get; set; }
    }

    public class Comprobacion
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
    }
}
