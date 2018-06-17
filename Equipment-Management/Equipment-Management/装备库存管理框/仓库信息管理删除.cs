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

namespace Equipment_Management.装备库存管理框
{

    public partial class 仓库信息管理删除 : Form
    {
        public static class DBClass
        {
            public static String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; 
            public static SqlConnection conn = new SqlConnection(strConn);
            
        }
        public 仓库信息管理删除(DataRowView dv):this()
        {
            label4.Text = dv["Sid"].ToString();
            label5.Text = dv["Sname"].ToString();
            label6.Text = dv["Memo"].ToString();
        }
        public 仓库信息管理删除()
        {
            InitializeComponent();
        }

        private void 仓库信息管理删除删除_Click(object sender, EventArgs e)
        {
            
                /*DBClass.conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBClass.conn;
                try
                {
                    cmd.CommandText = string.Format("delete from Storehouse where Sid={0}", label4.Text);
                    cmd.ExecuteNonQuery();
                }
                catch(Exception)
                {
                    MessageBox.Show("执行失败");
                }
            DBClass.conn.Close();
            this.Close();*/
            
        }
    }
}
