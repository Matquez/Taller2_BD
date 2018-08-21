namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.opcion1 = new System.Windows.Forms.Button();
            this.opcion2 = new System.Windows.Forms.Button();
            this.opcion3 = new System.Windows.Forms.Button();
            this.opcion4 = new System.Windows.Forms.Button();
            this.opcion5 = new System.Windows.Forms.Button();
            this.opcion6 = new System.Windows.Forms.Button();
            this.opcion7 = new System.Windows.Forms.Button();
            this.opcion8 = new System.Windows.Forms.Button();
            this.opcion9 = new System.Windows.Forms.Button();
            this.opcion10 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Bienvenido a servicio en linea de banco UCN";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Haga clicl izquierdo en la opcion que desee realizar";
            // 
            // opcion1
            // 
            this.opcion1.Location = new System.Drawing.Point(60, 55);
            this.opcion1.Name = "opcion1";
            this.opcion1.Size = new System.Drawing.Size(181, 23);
            this.opcion1.TabIndex = 5;
            this.opcion1.Text = "Apertura de cuenta corriente";
            this.opcion1.UseVisualStyleBackColor = true;
            this.opcion1.Click += new System.EventHandler(this.button1_Click);
            // 
            // opcion2
            // 
            this.opcion2.Location = new System.Drawing.Point(60, 84);
            this.opcion2.Name = "opcion2";
            this.opcion2.Size = new System.Drawing.Size(181, 23);
            this.opcion2.TabIndex = 6;
            this.opcion2.Text = "Cierre de cuenta";
            this.opcion2.UseVisualStyleBackColor = true;
            this.opcion2.Click += new System.EventHandler(this.button2_Click);
            // 
            // opcion3
            // 
            this.opcion3.Location = new System.Drawing.Point(60, 113);
            this.opcion3.Name = "opcion3";
            this.opcion3.Size = new System.Drawing.Size(181, 23);
            this.opcion3.TabIndex = 7;
            this.opcion3.Text = "Realizar deposito";
            this.opcion3.UseVisualStyleBackColor = true;
            this.opcion3.Click += new System.EventHandler(this.button3_Click);
            // 
            // opcion4
            // 
            this.opcion4.Location = new System.Drawing.Point(60, 142);
            this.opcion4.Name = "opcion4";
            this.opcion4.Size = new System.Drawing.Size(181, 23);
            this.opcion4.TabIndex = 8;
            this.opcion4.Text = "Realizar giro";
            this.opcion4.UseVisualStyleBackColor = true;
            this.opcion4.Click += new System.EventHandler(this.button4_Click);
            // 
            // opcion5
            // 
            this.opcion5.Location = new System.Drawing.Point(60, 171);
            this.opcion5.Name = "opcion5";
            this.opcion5.Size = new System.Drawing.Size(181, 23);
            this.opcion5.TabIndex = 9;
            this.opcion5.Text = "Informe de estado de cuenta";
            this.opcion5.UseVisualStyleBackColor = true;
            this.opcion5.Click += new System.EventHandler(this.button5_Click);
            // 
            // opcion6
            // 
            this.opcion6.Location = new System.Drawing.Point(309, 55);
            this.opcion6.Name = "opcion6";
            this.opcion6.Size = new System.Drawing.Size(181, 23);
            this.opcion6.TabIndex = 10;
            this.opcion6.Text = "Informe de cuentas cerradas";
            this.opcion6.UseVisualStyleBackColor = true;
            this.opcion6.Click += new System.EventHandler(this.button6_Click);
            // 
            // opcion7
            // 
            this.opcion7.Location = new System.Drawing.Point(309, 84);
            this.opcion7.Name = "opcion7";
            this.opcion7.Size = new System.Drawing.Size(181, 23);
            this.opcion7.TabIndex = 11;
            this.opcion7.Text = "Informe general del banco";
            this.opcion7.UseVisualStyleBackColor = true;
            this.opcion7.Click += new System.EventHandler(this.button7_Click);
            // 
            // opcion8
            // 
            this.opcion8.Location = new System.Drawing.Point(309, 113);
            this.opcion8.Name = "opcion8";
            this.opcion8.Size = new System.Drawing.Size(181, 23);
            this.opcion8.TabIndex = 12;
            this.opcion8.Text = "Informe movimientos de cuenta";
            this.opcion8.UseVisualStyleBackColor = true;
            this.opcion8.Click += new System.EventHandler(this.button8_Click);
            // 
            // opcion9
            // 
            this.opcion9.Location = new System.Drawing.Point(309, 142);
            this.opcion9.Name = "opcion9";
            this.opcion9.Size = new System.Drawing.Size(181, 23);
            this.opcion9.TabIndex = 13;
            this.opcion9.Text = "Actualizar direccion cliente";
            this.opcion9.UseVisualStyleBackColor = true;
            this.opcion9.Click += new System.EventHandler(this.button9_Click);
            // 
            // opcion10
            // 
            this.opcion10.Location = new System.Drawing.Point(309, 171);
            this.opcion10.Name = "opcion10";
            this.opcion10.Size = new System.Drawing.Size(181, 23);
            this.opcion10.TabIndex = 14;
            this.opcion10.Text = "Agregar cliente a cuenta existente";
            this.opcion10.UseVisualStyleBackColor = true;
            this.opcion10.Click += new System.EventHandler(this.button10_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(555, 365);
            this.Controls.Add(this.opcion10);
            this.Controls.Add(this.opcion9);
            this.Controls.Add(this.opcion8);
            this.Controls.Add(this.opcion7);
            this.Controls.Add(this.opcion6);
            this.Controls.Add(this.opcion5);
            this.Controls.Add(this.opcion4);
            this.Controls.Add(this.opcion3);
            this.Controls.Add(this.opcion2);
            this.Controls.Add(this.opcion1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Taller 2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button opcion1;
        private System.Windows.Forms.Button opcion2;
        private System.Windows.Forms.Button opcion3;
        private System.Windows.Forms.Button opcion4;
        private System.Windows.Forms.Button opcion5;
        private System.Windows.Forms.Button opcion6;
        private System.Windows.Forms.Button opcion7;
        private System.Windows.Forms.Button opcion8;
        private System.Windows.Forms.Button opcion9;
        private System.Windows.Forms.Button opcion10;
    }
}

