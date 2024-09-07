using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Administrador : Form
    {
        public Administrador()
        {
            InitializeComponent();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAñadirVenana_Click(object sender, EventArgs e)
        {
            Añadir  añadir = new Añadir();
            añadir.Show();

        }

        private void btnEditarVentana_Click(object sender, EventArgs e)
        {
            Editar editar = new Editar();
            editar.Show();
        }
    }
}
