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

namespace Equipment_Management.装备库存管理框
{
   /* public static class DBClass
    {
        public static String strConn = "Data Source=.;Initial Catalog = MSSQLSERVER;uid=zhangli;pwd=201608";
        public static SqlConnection conn = new SqlConnection(strConn);
    }*/

    public partial class 仓库信息管理添加 : Form
    {
        public static class DBClass
        {
            public static String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608";
            public static SqlConnection conn = new SqlConnection(strConn);

        }
       
        public 仓库信息管理添加()
        {
            InitializeComponent();
        }

        

        private void 仓库信息管理添加仓库编号_TextChanged(object sender, EventArgs e)
        {
           // DBClass.conn.Open();
        }

        private void 仓库信息管理添加添加_Click(object sender, EventArgs e)
        {
            bool i = true;
            DBClass.conn.Open();

            //异常处理
            while (i)
            {
                
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBClass.conn;
                cmd.CommandText = "select Sname from Storehouse";
                SqlDataReader reader = cmd.ExecuteReader();
                int m = 0;
                while(reader.Read())
                {
                    if(string.Compare(仓库信息管理添加仓库名称.Text ,reader[0].ToString())==0)
                    {
                        m++;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                reader.Close();
                if (仓库信息管理添加仓库编号.Text == "" || 仓库信息管理添加仓库名称.Text == "" || 仓库信息管理添加仓库备注.Text == "")
                {
                    MessageBox.Show("请完善添加信息！");
                    this.Show();
                    DBClass.conn.Close();
                    break;
                }
                else
                {
                    if (m != 1)
                    {
                        try
                        {
                            cmd.CommandText = "insert into Storehouse(Sid,Sname,Memo)values('" + 仓库信息管理添加仓库编号.Text + "','"
                                + 仓库信息管理添加仓库名称.Text + "','"
                                + 仓库信息管理添加仓库备注.Text + "')";
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString()+"执行失败");
                        }
                        DBClass.conn.Close();
                        this.Close();
                        break;
                    }
                    else
                    {
                        MessageBox.Show("仓库名称已经存在！");
                        this.Show();
                        DBClass.conn.Close();
                        break;
                    }
                    
                }
            }
            
        }

        private void 仓库信息管理添加取消_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 仓库信息管理添加_Load(object sender, EventArgs e)
        {

        }
    }
}
