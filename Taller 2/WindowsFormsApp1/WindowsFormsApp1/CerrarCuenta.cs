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
            if (true)//verificar que exista el cliente y la cuenta
            {
                //inutilizar la cuenta
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
