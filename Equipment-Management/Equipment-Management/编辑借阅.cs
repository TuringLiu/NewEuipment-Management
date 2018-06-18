using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Equipment_Management.Program;

namespace Equipment_Management
{
    public partial class 编辑借阅 : Form
    {
        public 编辑借阅()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (DBClass_xu.conn.State != ConnectionState.Open)//检查连接状态是否为已连接
                {
                    DBClass_xu.conn.Open();
                }

               
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DBClass_xu.conn;
                    cmd.CommandText = "Insert DataLend(Id,DataNo,LendDate,Ryid,LendCount,Ryname,Flag)values('" + textBox1.Text + "','" + textBox2.Text + "','" + System.DateTime.Now.ToString() + "','" + textBox4.Text + "','" + textBox5.Text +"','"+ textBox6.Text + "','"+ 0 + "')";
                    cmd.ExecuteNonQuery();

                    DataSet dsMyDataBase = new DataSet();
                    SqlDataAdapter daBaseInform = new SqlDataAdapter("Select*From DataLend", DBClass_xu.conn);
                    daBaseInform.Fill(dsMyDataBase, "DataLend");

                    mystr.data.DataSource = dsMyDataBase.Tables["DataLend"];
                    MessageBox.Show("添加成功");
                    DBClass_xu.conn.Close();
                    Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + " 打开数据库失败");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void 编辑借阅_Load(object sender, EventArgs e)
        {

        }
    }
}
