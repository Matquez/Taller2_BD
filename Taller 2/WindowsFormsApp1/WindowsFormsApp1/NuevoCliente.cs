using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class NuevoCliente : Form
    {
        public NuevoCliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Creamos el nuevo cliente en la base de datos y luego lanzamos un mensaje
            MessageBox.Show("Se ha creado el cliente con exito");
            this.Close();//cerramos la ventana
        }
    }
}
