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
    public partial class CambiarDir : Form
    {
        public CambiarDir()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConexMySQL conex = new ConexMySQL();
            conex.open();

            if(conex.executeNonQuery("UPDATE cliente " +
                                  "SET direccion = ?direccion " +
                                  "WHERE rut_cliente = ?rut_cliente;",
                                  "?direccion", textBox2.Text,
                                  "?rut_cliente", textBox1.Text) > 0)
            {
                MessageBox.Show("Actualizacion de direccion realizada con exito.");
            }
            else
            {
                MessageBox.Show("ERROR al Actualizar direccion.");
            }
            conex.close();

            this.Close();
        }

        
    }
}
