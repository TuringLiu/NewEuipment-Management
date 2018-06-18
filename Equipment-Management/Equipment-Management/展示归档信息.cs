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
    public partial class 展示归档信息 : Form
    {
        public 展示归档信息()
        {
            InitializeComponent();
        }

        private void 展示归档信息_Load(object sender, EventArgs e)
        {
            if (DBClass_xu.conn.State != ConnectionState.Open)//检查连接状态是否为已连接
            {
                DBClass_xu.conn.Open();
            }
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DBClass_xu.conn;

            string strcmd = "select Id from DataIn where Id='" + mystr.num + "'";
            cmd.CommandText = strcmd;
            label2.Text = cmd.ExecuteScalar().ToString();


            strcmd = "select InDate from DataIn where Id='" + mystr.num + "'";
            cmd.CommandText = strcmd;
            label4.Text = cmd.ExecuteScalar().ToString();

            strcmd = "select DataNo from DataIn where Id='" + mystr.num + "'";
            cmd.CommandText = strcmd;
            label6.Text = cmd.ExecuteScalar().ToString();

            strcmd = "select InCount from DataIn where Id='" + mystr.num + "'";
            cmd.CommandText = strcmd;
            label8.Text = cmd.ExecuteScalar().ToString();

            strcmd = "select Usersname from DataIn where Id='" + mystr.num + "'";
            cmd.CommandText = strcmd;
            label10.Text = cmd.ExecuteScalar().ToString();

            strcmd = "select Ryname from DataIn where Id='" + mystr.num + "'";
            cmd.CommandText = strcmd;
            label12.Text = cmd.ExecuteScalar().ToString();

            strcmd = "select Detail from DataIn where Id='" + mystr.num + "'";
            cmd.CommandText = strcmd;
            label14.Text = cmd.ExecuteScalar().ToString();

            strcmd = "select Flag from DataIn where Id='" + mystr.num + "'";
            cmd.CommandText = strcmd;
            label16.Text = cmd.ExecuteScalar().ToString();
        }
    }
}
