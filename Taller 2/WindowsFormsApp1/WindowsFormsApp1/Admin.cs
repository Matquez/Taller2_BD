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
    public partial class Admin : Form
    {
        private bool boleano;

        public Admin(bool boleanoPar)
        {
            InitializeComponent();
            this.boleano = boleanoPar;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ConexMySQL conex = new ConexMySQL();
            conex.open();

            DataTable tabla = conex.selectQuery("SELECT id_admin" +
                                                " FROM administrador " +
                                                "WHERE id_admin = ?id_admin and password = ?password",
                                                "?id_admin", id.Text,
                                                "?password", password.Text);
            conex.close();
            if (this.boleano == true)//para abrir la ventana crear cuenta
            {
                //Aqui verificamos que el id y la password ingresados concuerden con la de la base de datos
                if (tabla.Rows.Count > 0)
                {
                    Cliente ventanaCliente = new Cliente();
                    ventanaCliente.ShowDialog();
                }
                //Si no tiramos un mensaje de error
                else
                {
                    MessageBox.Show("El id de administrador o la contraseña ingresada no son correctas");
                }
            }
            else //para abrir la ventana de cerrar cuenta
            {
                //Aqui verificamos que el id y la password ingresados concuerden con la de la base de datos
                if (tabla.Rows.Count > 0)
                {
                    CerrarCuenta ventanaCerrarCuenta = new CerrarCuenta();
                    ventanaCerrarCuenta.ShowDialog();

                }
                //Si no tiramos un mensaje de error
                else
                {
                    MessageBox.Show("El id de administrador o la contraseña ingresada no son correctas");
                }
            }
        }
    }
}
