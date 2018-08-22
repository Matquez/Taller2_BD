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
    public partial class NuevaCuenta : Form
    {
        bool exito;//variable que nos indica que la transaccion fue hecha con exito
        public NuevaCuenta()
        {
            InitializeComponent();
            exito = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //agregamos la nueva cuenta a la base de datos y luego desplegamos un mensaje
            ConexMySQL conex = new ConexMySQL();
            conex.open();
            
            if (conex.executeNonQuery("INSERT INTO cuenta_corriente(numero_cuenta, saldo_cuenta, fecha_estado_actual, id_estado_actual) " +
                                    "VALUES (?numero_cuenta, ?saldo_cuenta, ?fecha_estado_actual, (SELECT id_estado_cuenta " +
                                                                                                  "FROM estado_cuenta " +
                                                                                                  "WHERE nom_estado = 'abierta') );",
                                    "?numero_cuenta", numeroCuenta.Text,
                                    "?saldo_cuenta", saldoIni.Text,
                                    "?fecha_estado_actual", DateTime.Today.ToString("yyyy-MM-dd")
                                     ) > 0)
            {
                MessageBox.Show("Cuenta corriente creada con exito");
                exito = true;//transaccion exitosa.
            }
            else
            {
                MessageBox.Show("ERROR al crear Cuenta corriente.");
            }
            conex.close();
            
            this.Close(); //cerramos la ventana
        }
        public bool getExito()
        {
            return this.exito;
        }
    }
}
