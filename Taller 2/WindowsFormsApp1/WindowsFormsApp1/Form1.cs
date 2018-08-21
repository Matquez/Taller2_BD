using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private const string V = "WHERE id_cliente = ?id_cliente;";

        public Form1()
        {
            InitializeComponent();
        }

        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*ConexMySQL conex = new ConexMySQL();
            conex.open();
            conex.executeNonQuery("INSERT INTO administrador(id_admin, password) " +
                                 "VALUES (?administrador, ?password );",
                                 "?id_admin", "123",
                                 "?password", "12345");
            conex.close();*/
            Admin ventanaAdmin = new Admin(true);//le pasamos true para que despliegue las opcienes de cuenta corriente
            ventanaAdmin.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin ventanaAdmin = new Admin(false);//le pasamos false para que despliegue las opciones de eliminar cuenta corriente
            ventanaAdmin.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Deposito ventanaDeposito = new Deposito();
            ventanaDeposito.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Giro ventanaGiro = new Giro();
            ventanaGiro.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            InformeEstado ventanaInformeEstado = new InformeEstado();
            ventanaInformeEstado.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            InformeCuentasCerradas ventanaInfoCuentasCerradas = new InformeCuentasCerradas();
            ventanaInfoCuentasCerradas.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            InformeGeneral ventanaInformeGeneral = new InformeGeneral();
            ventanaInformeGeneral.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MovimientosCuenta ventanaMovCuentas = new MovimientosCuenta();
            ventanaMovCuentas.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            CambiarDir ventanaDir = new CambiarDir();
            ventanaDir.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }
    }

}
