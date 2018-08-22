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
    public partial class NuevoCliente : Form
    {
        public NuevoCliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Creamos el nuevo cliente en la base de datos y luego lanzamos un mensaje
            ConexMySQL conex = new ConexMySQL();
            conex.open();

            if (conex.executeNonQuery("INSERT INTO cliente(rut_cliente, nombre_cliente, fecha_creacion_cli, direccion) " +
                "                     VALUES (?rut_cliente, ?nombre_cliente, ?fecha_creacion_cli, ?direccion);",
                                    "?rut_cliente", textBox1.Text,
                                    "?nombre_cliente",textBox2.Text,
                                    "?fecha_creacion_cli", DateTime.Today.ToString("yyyy-MM-dd"),
                                    "?direccion", textBox3.Text
                                     ) > 0)
            {
                MessageBox.Show("Cliente agregado con exito");
            }
            else
            {
                MessageBox.Show("ERROR al intentar agregar el cliente. Revise los datos.");
            }
            conex.close();
            
            this.Close();//cerramos la ventana
        }
    }
}
