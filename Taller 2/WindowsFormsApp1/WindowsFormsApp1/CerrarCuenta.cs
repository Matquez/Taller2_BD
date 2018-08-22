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
    public partial class CerrarCuenta : Form
    {
        public CerrarCuenta()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConexMySQL conex = new ConexMySQL();
            conex.open();

           DataTable delCuenta = conex.selectQuery("SELECT id_cuenta_corriente " +
                             "FROM cliente_cuenta_corriente " +
                             "WHERE cliente_cuenta_corriente.id_cliente = (SELECT id_cliente " +
                                                                          "FROM cliente " +
                                                                          "WHERE rut_cliente = ?rut_cliente)" +
                             "and cliente_cuenta_corriente.id_cuenta_corriente = (SELECT id_cuenta_corriente " +
                                                                                  "FROM cuenta_corriente " +
                                                                                  "WHERE numero_cuenta = ?numero_cuenta)",
                              "?rut_cliente", textBox1.Text,
                              "?numero_cuenta", textBox2.Text);
            conex.close();
            if (delCuenta.Rows.Count > 0)//verificar que exista el cliente y la cuenta
            {
                //inutilizar la cuenta
                conex.open();
                conex.executeNonQuery("UPDATE cuenta_corriente " +
                                      "SET id_estado_actual = (SELECT id_estado_cuenta " +
                                                              "FROM estado_cuenta " +
                                                              "WHERE nom_estado = 'cerrada') " +
                                      "WHERE id_cuenta_corriente = ?id_cuenta_corriente;",
                                      "?id_cuenta_corriente", delCuenta.Rows[0][0].ToString());
                conex.close();
                MessageBox.Show("Cuenta eliminada con exito");
                this.Close();
            }
            else
            {
                MessageBox.Show("Los datos son incorrectos vuelva a intentarlo");
            }
            
        }
    }
}
