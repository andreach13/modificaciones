using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Entregas
{
    public class EntregasBL
    {
        Contexto _contexto;
        public BindingList<Entrega> ListaEntregas { get; set; }

        public EntregasBL()
        {
            _contexto = new Contexto();
            ListaEntregas = new BindingList<Entrega>();

        }

        public BindingList<Entrega> ObtenerEntregas()
        {
            _contexto.Entregas.Load();
            ListaEntregas = _contexto.Entregas.Local.ToBindingList();

            return ListaEntregas;
        }


        //BOTONES DE GUARDAR 
        public Comprobacion GuardarEntrega(Entrega entrega)
        {
            var resultado = Validar(entrega);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }
            _contexto.SaveChanges();

            resultado.Exitoso = true;
            return resultado;
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
                    _contexto.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        private Comprobacion Validar(Entrega entrega)
        {
            var resultado = new Comprobacion();
            resultado.Exitoso = true;

            //if (string.IsNullOrEmpty(entrega.Cliente.NombredeEmpresa) == true)
            //{
                //resultado.Mensaje = "Ingrese el nombre del remitente";
                //resultado.Exitoso = false;
            //}

            //if (string.IsNullOrEmpty(entrega.Cliente.Direccion) == true)
            //{
                //resultado.Mensaje = "Ingrese una direccion de entrega";
                //resultado.Exitoso = false;
            //}
            if (string.IsNullOrEmpty(entrega.TipoPaquete) == true)
            {
                resultado.Mensaje = "Especifique que paquete se envía";
                resultado.Exitoso = false;
            }
            if (string.IsNullOrEmpty(entrega.EstadodePago) == true)
            {
                resultado.Mensaje = "Especifique el estado del pago sobre el envio";
                resultado.Exitoso = false;
            }
            if (string.IsNullOrEmpty(entrega.EstadodePago) == true)
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
