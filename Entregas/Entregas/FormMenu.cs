﻿using System;
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
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void rentasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            Acceso();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Acceso();
        }

        private void Acceso()
        {
            var formLogin = new FormLogin();
            formLogin.ShowDialog();

            toolStripStatusLabel1.Text = "Usuario: " + Utils.NombreUsuario;
        }

        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formCliente = new FormClientes();
            formCliente.MdiParent = this;
            formCliente.Show();

        }

        private void nuevoEnvíoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formEnvio = new FormEnvio();
            formEnvio.MdiParent = this;
            formEnvio.Show();
        }

        private void nuevaFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formFactura = new FormFactura();
            formFactura.MdiParent = this;
            formFactura.Show();
        }

        private void nuevaRutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formRuta = new FormRuta();
            formRuta.MdiParent = this;
            formRuta.Show();
        }

        private void generalToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void historialDeEnvíosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formReporteEntregas = new FormReporteEntregas();
            formReporteEntregas.MdiParent = this;
            formReporteEntregas.Show();
        }

        private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formReporteFacturas = new FormReporteFacturas();
            formReporteFacturas.MdiParent = this;
            formReporteFacturas.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formReporteClientes = new FormReportedeClientes();
            formReporteClientes.MdiParent = this;
            formReporteClientes.Show();
        }

        private void administracionDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formUsurios = new FormUsuarios();
            formUsurios.MdiParent = this;
            formUsurios.Show();
      
        }
    }
}
