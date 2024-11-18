using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Data.SQL_QueryDate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //ประเทศตัวแปรเชื่อมต่อ
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da;

        private void connect()
        {
            string server = @"HEART\SQLEXPRESS";
            string db = "Minimart";
            string strCon = string.Format("Data source ={0};Initial Catalog = {1};"
                + "Integrated Security=True;Encrypt=False", server, db);
            conn = new SqlConnection(strCon);
            conn.Open();
        }
        //

        private void disconnect()
        {
            connect();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            connect();
            showdata("select * from Products");
        }
        private void showdata(string sql)
        {
            
            da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showdata("select EmployeeID,Title+FirstName+' '+lastname EmpName, Position from Employees");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showdata("select * from Categories");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showdata("select * from Products");
        }
    }

}
