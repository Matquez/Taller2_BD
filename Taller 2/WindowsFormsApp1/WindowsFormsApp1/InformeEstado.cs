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
    public partial class InformeEstado : Form
    {
        public InformeEstado()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConexMySQL conex = new ConexMySQL();
            conex.open();
            DataTable tabla = conex.selectQuery("SELECT nom_estado " +
                                                                         "FROM estado_cuenta " +
                                                                         "WHERE id_estado_cuenta =(SELECT id_estado_cuenta FROM cuenta_corriente WHERE numero_cuenta = ?numero_cuenta)",
                                                                         "?numero_cuenta", textBox1.Text);
            conex.close();
            if(tabla.Rows.Count > 0)
            {
                label2.Text = "La cuenta se encuentra: " + tabla.Rows[0][0];
            }
            
        }
    }
}
