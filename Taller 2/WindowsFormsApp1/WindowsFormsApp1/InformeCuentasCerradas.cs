﻿using System;
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
    public partial class InformeCuentasCerradas : Form
    {
        public InformeCuentasCerradas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DesplegarTabla tabla = new DesplegarTabla(textBox1.Text, textBox2.Text);
            tabla.Show();
        }

    }
}
