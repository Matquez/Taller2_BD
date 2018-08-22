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
    public partial class MovimientosCuenta : Form
    {
        public MovimientosCuenta()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConexMySQL conex = new ConexMySQL();
            conex.open();
            DataTable tabla = conex.selectQuery("SELECT id_cuenta_corriente " +
                                                "FROM cuenta_corriente " +
                                                "WHERE numero_cuenta = ?numero_cuenta",
                                                "?numero_cuenta", textBox1.Text);
            conex.close();
            if(tabla.Rows.Count > 0)//Existe la cuenta
            {
                try
                {
                    DateTime.ParseExact(textBox2.Text, "yyyy-MM-dd", null);
                    DateTime.ParseExact(textBox3.Text, "yyyy-MM-dd", null);

                    conex.open();
                    dataGridView1.DataSource = conex.selectQuery("SELECT * " +
                                  "FROM transaccion_cuenta " +
                                  "WHERE id_cuenta_corriente = ?id_cuenta and fecha_transaccion > ?fecha_desde and fecha_transaccion < ?fecha_hasta",
                                  "?id_cuenta", tabla.Rows[0][0].ToString(),
                                  "?fecha_desde", textBox2.Text,
                                  "?fecha_hasta", textBox3.Text);
                    conex.close();
                    
                }
                catch (Exception fecha)
                {
                    MessageBox.Show("Error en formato de fechas. \nException del tipo " + fecha.GetType());
                }

            }
            else
            {
                MessageBox.Show("No se encontró la cuenta.");
            }
             
        }
    }
}
