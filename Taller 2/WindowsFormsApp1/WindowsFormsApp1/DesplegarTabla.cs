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
    public partial class DesplegarTabla : Form
    {
        private String fechaIni;
        private String fechaFin;

        public DesplegarTabla(String fechaIni, String fechaFin)
        {
            InitializeComponent();
            this.fechaIni = fechaIni;
            this.fechaFin = fechaFin;
        }

        private void DesplegarTabla_Load(object sender, EventArgs e)
        {
            ConexMySQL conex = new ConexMySQL();
            conex.open();
            DataTable tabla = conex.selectQuery("SELECT * " +
                                                "FROM cuenta_corriente " +
                                                "WHERE fecha_estado_actual >= ?fecha_ini and fecha_estado_actual <= ?fecha_fin and id_estado_actual = (SELECT id_estado_cuenta FROM estado_cuenta WHERE nom_estado = 'Cerrada')",
                                                "?fecha_ini", this.fechaIni, "?fecha_fin", this.fechaFin);

            dataGridView1.DataSource = tabla;
        }

        
    }
}
