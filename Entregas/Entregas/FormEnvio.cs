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
    }
}
