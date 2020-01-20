namespace Reportview
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            //Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.label1 = new System.Windows.Forms.Label();
            this.t1 = new System.Windows.Forms.TextBox();
            this.dt1 = new System.Windows.Forms.DateTimePicker();
            this.dt2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.b1 = new System.Windows.Forms.Button();
            //this.visor = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dtsEjemploBindingSource = new System.Windows.Forms.BindingSource(this.components);
            //this.dtsEjemplo = new winRdlc.dtsEjemplo();
            ((System.ComponentModel.ISupportInitialize)(this.dtsEjemploBindingSource)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.dtsEjemplo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Título";
            // 
            // t1
            // 
            this.t1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.t1.Location = new System.Drawing.Point(50, 6);
            this.t1.Name = "t1";
            this.t1.Size = new System.Drawing.Size(329, 20);
            this.t1.TabIndex = 2;
            this.t1.Text = "TÍTULO DE PRUEBA";
            // 
            // dt1
            // 
            this.dt1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt1.Location = new System.Drawing.Point(438, 6);
            this.dt1.Name = "dt1";
            this.dt1.Size = new System.Drawing.Size(99, 20);
            this.dt1.TabIndex = 3;
            // 
            // dt2
            // 
            this.dt2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt2.Location = new System.Drawing.Point(584, 6);
            this.dt2.Name = "dt2";
            this.dt2.Size = new System.Drawing.Size(99, 20);
            this.dt2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(394, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Desde";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(543, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hasta";
            // 
            // b1
            // 
            this.b1.Location = new System.Drawing.Point(721, 7);
            this.b1.Name = "b1";
            this.b1.Size = new System.Drawing.Size(75, 23);
            this.b1.TabIndex = 7;
            this.b1.Text = "Imprimir";
            this.b1.UseVisualStyleBackColor = true;
            //this.b1.Click += new System.EventHandler(this.b1_Click);
            // 
            // visor
            // 
            //this.visor.Cursor = System.Windows.Forms.Cursors.SizeAll;
            //reportDataSource1.Name = "dtsEjemplo";
            //reportDataSource1.Value = this.dtsEjemploBindingSource;
            //this.visor.LocalReport.DataSources.Add(reportDataSource1);
            //this.visor.LocalReport.ReportEmbeddedResource = "winRdlc.infEjemplo.rdlc";
            //this.visor.Location = new System.Drawing.Point(12, 61);
            //this.visor.Name = "visor";
            //this.visor.Size = new System.Drawing.Size(784, 417);
            //this.visor.TabIndex = 0;
            // 
            // dtsEjemploBindingSource
            // 
            this.dtsEjemploBindingSource.DataMember = "dtsEjemplo";
            //this.dtsEjemploBindingSource.DataSource = this.dtsEjemplo;
            // 
            // dtsEjemplo
            // 
            //this.dtsEjemplo.DataSetName = "dtsEjemplo";
            //this.dtsEjemplo.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 565);
            this.Controls.Add(this.b1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dt2);
            this.Controls.Add(this.dt1);
            this.Controls.Add(this.t1);
            this.Controls.Add(this.label1);
            //this.Controls.Add(this.visor);
            this.Name = "Form1";
            this.Text = "Form1";
            //this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtsEjemploBindingSource)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.dtsEjemplo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox t1;
        private System.Windows.Forms.DateTimePicker dt1;
        private System.Windows.Forms.DateTimePicker dt2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button b1;
        private System.Windows.Forms.BindingSource dtsEjemploBindingSource;
        //private dtsEjemplo dtsEjemplo;
        //private Microsoft.Reporting.WinForms.ReportViewer visor;
    }
}

