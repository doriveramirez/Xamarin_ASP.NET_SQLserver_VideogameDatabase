using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Reporting.WinForms;

namespace winRdlc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.visor.RefreshReport();
        }

        private void b1_Click(object sender, EventArgs e)
        {
            string p1 = t1.Text.Trim();
            string p2 = dt1.Value.ToShortDateString();
            string p3 = dt2.Value.ToShortDateString();
            dtsEjemplo dtsE = new dtsEjemplo();


            #region "CREA TABLA DE EJEMPLO"

            DataTable tabla = new DataTable();
            DataColumn col = new DataColumn("d1");
            col.DataType = System.Type.GetType("System.String");
            tabla.Columns.Add(col);
            col = new DataColumn("d2");
            col.DataType = System.Type.GetType("System.String");
            tabla.Columns.Add(col);
            col = new DataColumn("d3");
            col.DataType = System.Type.GetType("System.String");
            tabla.Columns.Add(col);
            col = new DataColumn("d4");
            col.DataType = System.Type.GetType("System.String");
            tabla.Columns.Add(col);
            col = new DataColumn("d5");
            col.DataType = System.Type.GetType("System.String");
            tabla.Columns.Add(col);

            #endregion


            for (int i = 0; i < 10;i++)
            {
                DataRow linea = tabla.NewRow();
                linea["d1"] = "Linea " + (i+1).ToString();
                linea["d2"] = "Linea " + (i + 1).ToString();
                linea["d3"] = "Linea " + (i + 1).ToString();
                linea["d4"] = "Linea " + (i + 1).ToString();
                linea["d5"] = "Linea " + (i + 1).ToString();

                tabla.Rows.Add(linea);
            }

            dtsE.Tables.RemoveAt(0);    //Eliminamos la tabla que crea por defecto
            dtsE.Tables.Add(tabla);     //Añadimos la tabla que acabamos de crear

            dtsEjemploBindingSource.DataSource = dtsE;
            dtsEjemploBindingSource.DataMember = "Table1";

            //Array que contendrá los parámetros
            ReportParameter[] parameters = new ReportParameter[3];
            //Establecemos el valor de los parámetros
            parameters[0] = new ReportParameter("p1", p1);
            parameters[1] = new ReportParameter("p2", p2);
            parameters[2] = new ReportParameter("p3", p3);
            //Pasamos el array de los parámetros al ReportViewer
            visor.LocalReport.SetParameters(parameters);

            visor.Width = 1032;
            visor.Height = 600;
            visor.Visible = true;
            visor.RefreshReport();

        }
    }
}
