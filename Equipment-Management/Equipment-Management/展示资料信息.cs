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
    public partial class 展示资料信息 : Form
    {
        public 展示资料信息()
        {
            InitializeComponent();
        }

        private void 展示资料信息_Load(object sender, EventArgs e)
        {
            if (DBClass_xu.conn.State != ConnectionState.Open)//检查连接状态是否为已连接
            {
                DBClass_xu.conn.Open();
            }
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DBClass_xu.conn;

            string strcmd = "select DataNo from ArmsData where DataNo='" + mystr.str + "'";
            cmd.CommandText = strcmd;
            label2.Text = cmd.ExecuteScalar().ToString();
            
            
            strcmd= "select DataName from ArmsData where DataNo='" + mystr.str + "'";
            cmd.CommandText = strcmd;
            label3.Text = cmd.ExecuteScalar().ToString();

            strcmd ="select TypeId from ArmsData where DataNo='" + mystr.str + "'";
            cmd.CommandText = strcmd;
            label6.Text = cmd.ExecuteScalar().ToString();

            strcmd ="select Icount from ArmsData where DataNo='" + mystr.str + "'";
            cmd.CommandText = strcmd;
            label8.Text = cmd.ExecuteScalar().ToString();

            strcmd = "select Iprice from ArmsData where DataNo='" + mystr.str + "'";
            cmd.CommandText = strcmd;
            label10.Text = cmd.ExecuteScalar().ToString();

            strcmd ="select Memo from ArmsData where DataNo='" + mystr.str + "'";
            cmd.CommandText = strcmd;
            label12.Text = cmd.ExecuteScalar().ToString();

            strcmd ="select GreateDate from ArmsData where DataNo='" + mystr.str + "'";
            cmd.CommandText = strcmd;
            label14.Text = cmd.ExecuteScalar().ToString();
        }
    }
}
