using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HiSafeCore;
using MySql.Data.MySqlClient;

namespace HadronWarrantyCaed
{
    public partial class DataBaseConfigForm : Form
    {
        DataBaseMySqlClass db_connector_obj;
        string _server_txt;
        string _port_txt;
        string _db_txt;
        string _username_txt;
        string _password_txt;

        static string connection_string;

        public bool connected_status = false;


        private string ConnectionStringDB
        {//"datasource=127.0.0.1;port=3306;username=root;password=;database=test;" <---- format 
            get
            {
                return "datasource=" + _server_txt + ";port=" + _port_txt + ";username=" + _username_txt + ";password=" + _password_txt + ";database=" + _db_txt + ";";
            }
        }

        public DataBaseConfigForm()
        {
            InitializeComponent();
        }

        private void DataBaseConfigForm_Load(object sender, EventArgs e)
        {

        }

        private void connect_db_btn_Click(object sender, EventArgs e)
        {

            _server_txt = ip_name_host_txt.Text;
            _port_txt = host_port_txt.Text;
            _db_txt = database_name_txt.Text;
            _username_txt = username_txt.Text;
            _password_txt = password_txt.Text;

            //string connectionstring = "datasource=localhost;port=3306;username=nima;password=1234;database=hadronwarrantycard;";
            connection_string = ConnectionStringDB;
            db_connector_obj = new DataBaseMySqlClass(ConnectionStringDB);
            if (db_connector_obj.conenctDB())
            {
                db_conenction_status_label.Text = "Connect To DB Successfully"; // Alert
                db_conenction_status_label.ForeColor = Color.DarkGreen;
                connected_status = true;
            }
            else
            {
                db_conenction_status_label.Text = "Coudn't Connect To DB " + Environment.NewLine + " Check The Connection Details And Try Again"; // Alert
                db_conenction_status_label.ForeColor = Color.Maroon;
                connected_status = false;
            }


        }

        private void test_host_server_btn_Click(object sender, EventArgs e)
        {

        }

        private void DataBaseConfigForm_VisibleChanged(object sender, EventArgs e)
        {
            if (DataBaseMySqlClass.ConenctionStatus)
            {
                db_conenction_status_label.Text = "Connect To DB Successfully"; // Alert
                db_conenction_status_label.ForeColor = Color.DarkGreen;
            }
        }
    }
}
