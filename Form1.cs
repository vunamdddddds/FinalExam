using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Kiemtracuoiki
{
    public partial class Form1 : Form
    {
        string querry = "Data Source=DESKTOP-MI1NE8C\\SQLEXPRESS;Initial Catalog=DieuTraDS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        SqlConnection SqlConnection=new SqlConnection();
        SqlCommand SqlCommand = new SqlCommand();
        SqlDataAdapter SqlDataAdapter = new SqlDataAdapter();
        DataTable DataTable = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      public   void loaddata()
        {
            using (SqlConnection=new SqlConnection(querry))
            {
                try {
                SqlConnection.Open();   
                    SqlCommand=SqlConnection.CreateCommand();
                    SqlCommand.CommandText = "select * from CongDan";
                    SqlDataAdapter.SelectCommand = SqlCommand;
                    DataTable.Clear();
                    SqlDataAdapter.Fill(DataTable);
                    dataGridView1.DataSource=DataTable;
                
                
                } catch(Exception ex) { MessageBox.Show("error:"+ex); } finally { if (SqlConnection.State==ConnectionState.Open) {
                        SqlConnection.Close();                     
} }

            } 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loaddata();
        }
    }
}
