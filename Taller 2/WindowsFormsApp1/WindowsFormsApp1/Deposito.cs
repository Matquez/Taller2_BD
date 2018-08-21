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
    public partial class Deposito : Form
    {
        public Deposito()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConexMySQL conex = new ConexMySQL();
            conex.open();

            if(conex.executeNonQuery("UPDATE cuenta_corriente " +
                                  "SET saldo_cuenta = saldo_cuenta + ?nuevo_saldo_cuenta " +
                                  "WHERE numero_cuenta = ?numero_cuenta;",
                                  "?nuevo_saldo_cuenta", textBox2.Text,
                                  "?numero_cuenta", textBox1.Text) > 0)
            {
                MessageBox.Show("Deposito realizado con exito.");
            }
            else
            {
                MessageBox.Show("ERROR en Deposito.");
            }

            conex.close();
        }
    }
}
