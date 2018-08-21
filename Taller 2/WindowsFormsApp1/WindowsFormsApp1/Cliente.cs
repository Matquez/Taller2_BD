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
    public partial class Cliente : Form
    {
        public Cliente()
        {
            InitializeComponent();
        }

        private void registrar_Click(object sender, EventArgs e)
        {
            NuevoCliente ventanaNuevoCliente = new NuevoCliente();
            ventanaNuevoCliente.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConexMySQL conex = new ConexMySQL();
            conex.open();

            DataTable tabla = conex.selectQuery("SELECT rut_cliente " +
                                                "FROM cliente " +
                                                "WHERE rut_cliente = ?rut_cliente",
                                                "?rut_cliente", textBox1.Text);
            conex.close();
            //si se cumple la condicion creamos una nueva cuenta corriente
            if (tabla.Rows.Count > 0)
            {
                NuevaCuenta ventanaCuenta = new NuevaCuenta();
                ventanaCuenta.ShowDialog();
            }
            //si no le mandamos un mensaje para que registre al cliente
            else
            {
                MessageBox.Show("El id de cliente no ha sido encontrado, porfavor intente con un id correcto o registre un nuevo cliente");
            }
        }
    }
}
