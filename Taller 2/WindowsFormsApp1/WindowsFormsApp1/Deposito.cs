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
                conex.executeNonQuery("INSERT INTO transaccion_cuenta(id_cuenta_corriente, monto_transaccion, fecha_transaccion, hora_transaccion, id_tipo_transaccion) " +
                                      "VALUES ((SELECT id_cuenta_corriente " +
                                               "FROM cuenta_corriente " +
                                               "WHERE numero_cuenta = ?numero_cuenta), ?monto_transaccion, ?fecha_transaccion, ?hora_transaccion, (SELECT id_tipo_transaccion " +
                                                                                                                                                  "FROM tipo_transaccion " +
                                                                                                                                                  "WHERE tipo_transaccion = 'deposito'))",
                                        "?numero_cuenta", textBox1.Text,
                                        "?monto_transaccion", textBox2.Text,
                                        "?fecha_transaccion", DateTime.Today.ToString("yyyy-MM-dd"),
                                        "?hora_transaccion", DateTime.Now.ToShortTimeString());
            }
            else
            {
                MessageBox.Show("ERROR en Deposito.");
            }

            conex.close();
        }
    }
}
