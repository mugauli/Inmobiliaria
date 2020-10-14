using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Reportes
{
    public partial class FrmReporteParcelas : Form
    {
        public FrmReporteParcelas()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
           
        }

        private void FrmReporteParcelas_Load(object sender, EventArgs e)
        {
            try
            {
                ConnectionInfo myConnectionInfo = new ConnectionInfo();
                myConnectionInfo.ServerName = "DESKTOP-8AVQA27";
                myConnectionInfo.DatabaseName = "dbventas";
                myConnectionInfo.UserID = "ventas";
                myConnectionInfo.Password = "ventas";

                rptParcelas rpt = new rptParcelas();
                rpt.SetDatabaseLogon(myConnectionInfo.UserID, myConnectionInfo.Password);
                //rpt.SetDatabaseLogon(myConnectionInfo.UserID, myConnectionInfo.Password, myConnectionInfo.ServerName, myConnectionInfo.DatabaseName);
                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
