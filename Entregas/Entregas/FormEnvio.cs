using BL.Entregas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entregas
{
    public partial class FormEnvio : Form
    {
        EntregasBL _entregas;
        ClienteBL _clienteBL;

        public FormEnvio()
        {
            InitializeComponent();

            _entregas = new EntregasBL();
            listaEntregasBindingSource.DataSource = _entregas.ObtenerEntregas();

           

           _clienteBL = new ClienteBL();
            listadeClientesBindingSource.DataSource = _clienteBL.ObtenerClientes();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form formEntrega = new FormClientes();
            formEntrega.MdiParent = this;
            formEntrega.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form formFactura = new FormFactura();
            formFactura.MdiParent = this;
            formFactura.Show();
        }

        private void FormEnvio_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            _entregas.CancelarCambios();
            DeshabilitarHabilitarBotones(true);
            
        }

        private void listaEntregasBindingNavigatorSaveItem_Click(object sender, EventArgs e)//GUARDAR NUEVA ENTREGA
        {
            listaEntregasBindingSource.EndEdit();
            var entrega = (Entrega)listaEntregasBindingSource.Current;

            var resultado = _entregas.GuardarEntrega(entrega);

            if (resultado.Exitoso == true)
            {
                listaEntregasBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);
                MessageBox.Show("Entrega generada");
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)///AGREGAR NUEVA ENTREGA
        {
            _entregas.AgregarEntrega();
            listaEntregasBindingSource.MoveLast();

            DeshabilitarHabilitarBotones(false);
        }

        private void DeshabilitarHabilitarBotones(bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;

            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;
            toolStripButtonCancelar.Visible = !valor;         
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            
            if (IDtextBox1.Text != "")
            {
                var resultado = MessageBox.Show("Desea eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(IDtextBox1.Text);
                    Eliminar(id);
                }                
            }            
        }

        private void Eliminar(int id)
        {
            
            var resultado = _entregas.EliminarEntrega(id);
            if (resultado == true)
            {
                listaEntregasBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Ocurrió un error al eliminar el registro");
            }
        }
    }
}
