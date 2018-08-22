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
    public partial class InformeGeneral : Form
    {
        public InformeGeneral()
        {
            InitializeComponent();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            ConexMySQL conex = new ConexMySQL();

            //TOTAl CLIENTES
            conex.open();
            DataTable total = conex.selectQuery("SELECT COUNT(*) " +
                              "FROM cliente ");
            conex.close();
            textBox7.Text = total.Rows[0][0].ToString();

            //TOTAL CUENTAS CORRIENTES
            conex.open();
            total = conex.selectQuery("SELECT COUNT(*) " +
                                     "FROM cuenta_corriente ");
            conex.close();
            textBox8.Text = total.Rows[0][0].ToString();

            //CLIENTES NUEVOS ENTRE FECHAS
            try
            {
                DateTime.ParseExact(textBox1.Text, "yyyy-MM-dd", null);
                DateTime.ParseExact(textBox6.Text, "yyyy-MM-dd", null);

                conex.open();
                total = conex.selectQuery("SELECT COUNT(*) " +
                                          "FROM cliente " +
                                          "WHERE fecha_creacion_cli >= ?fecha_desde and fecha_creacion_cli <= ?fecha_hasta",
                                          "?fecha_desde", textBox1.ToString(),
                                          "?fecha_hasta", textBox6.ToString());
                conex.close();
                textBox9.Text = total.Rows[0][0].ToString();
            }
            catch (Exception fecha)
            {
                MessageBox.Show("Error en formato de fechas. \nException del tipo " + fecha.GetType());
            }
        }

        
    }
}
