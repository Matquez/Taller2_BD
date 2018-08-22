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
    public partial class Giro : Form
    {
        public Giro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int saldo;
            int monto_requerido;
            ConexMySQL conex = new ConexMySQL();
            conex.open();
            DataTable tabla_giro = conex.selectQuery("SELECT saldo_cuenta " +
                                               "FROM cuenta_corriente " +
                                               "WHERE numero_cuenta = ?numero_cuenta",
                                               "?numero_cuenta", textBox1.Text);
            conex.close();

            if(tabla_giro.Rows.Count > 0)//Existe en la tabla cuentra_corriente
            {
                try
                {
                    saldo = Int32.Parse(tabla_giro.Rows[0][0].ToString());
                    monto_requerido = Int32.Parse(textBox2.Text);

                    if (monto_requerido > saldo )//No se realiza giro
                    {
                        if (saldo >= 200)
                        {
                            //Se cobran 200
                            conex.open();
                            conex.executeNonQuery("UPDATE cuenta_corriente " +
                                  "SET saldo_cuenta = saldo_cuenta - 200 " +
                                  "WHERE numero_cuenta = ?numero_cuenta;",
                                  "?numero_cuenta", textBox1.Text);
                            conex.close();

                            MessageBox.Show("Saldo insuficiente para realizar el giro. Se le cobraron $200.");
                        }
                        else //no se cobra nada
                        {
                            MessageBox.Show("Saldo insuficiente para realizar el giro.");
                        }
                    }
                    else 
                    {
                        //Se realiza el Giro y se cobran 100:
                        conex.open();
                        conex.executeNonQuery("UPDATE cuenta_corriente " +
                                  "SET saldo_cuenta = saldo_cuenta -100 - ?monto " +
                                  "WHERE numero_cuenta = ?numero_cuenta;",
                                  "?monto", textBox2.Text,
                                  "?numero_cuenta", textBox1.Text);
                        
                        //Guaradamos la info en la tabla transacciones:
                        conex.executeNonQuery("INSERT INTO transaccion_cuenta(id_cuenta_corriente, monto_transaccion, fecha_transaccion, hora_transaccion, id_tipo_transaccion) " +
                                      "VALUES ((SELECT id_cuenta_corriente " +
                                               "FROM cuenta_corriente " +
                                               "WHERE numero_cuenta = ?numero_cuenta), ?monto_transaccion, ?fecha_transaccion, ?hora_transaccion, (SELECT id_tipo_transaccion " +
                                                                                                                                                  "FROM tipo_transaccion " +
                                                                                                                                                  "WHERE tipo_transaccion = 'giro'))",
                                        "?numero_cuenta", textBox1.Text,
                                        "?monto_transaccion", textBox2.Text,
                                        "?fecha_transaccion", DateTime.Today.ToString("yyyy-MM-dd"),
                                        "?hora_transaccion", DateTime.Now.ToShortTimeString());
                        conex.close();

                    }
                }
                catch (Exception formate)
                {
                    MessageBox.Show("Error en el formato del monto, asegure que sea entero. " +
                        "\nException del tipo " + formate.GetType());

                }
            }

            
        }
    }
}