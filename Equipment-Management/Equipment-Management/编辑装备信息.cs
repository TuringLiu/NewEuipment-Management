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
    public partial class 编辑装备信息 : Form
    {
        public 编辑装备信息()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int i = 装备基本信息.i;
            try
            {
                if (i == 1)
                {
                    if (DBClass_xu.conn.State != ConnectionState.Open)//检查连接状态是否为已连接
                    {
                        DBClass_xu.conn.Open();
                    }

                   
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DBClass_xu.conn;
                    cmd.CommandText = "Insert ArmsInfo(Zbid,Zbname,Zbspec,Zbkind,Zbunit)values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                    cmd.ExecuteNonQuery();

                    DataSet dsMyDataBase = new DataSet();
                    SqlDataAdapter daBaseInform = new SqlDataAdapter("Select*From ArmsInfo", DBClass_xu.conn);
                    daBaseInform.Fill(dsMyDataBase, "ArmsInfo");

                    mystr.data.DataSource = dsMyDataBase.Tables["ArmsInfo"];
                    MessageBox.Show("添加成功");
                    DBClass_xu.conn.Close();
                    Close();


                }
                else if (i == 2)
                {
                    if (DBClass_xu.conn.State != ConnectionState.Open)//检查连接状态是否为已连接
                    {
                        DBClass_xu.conn.Open();
                    }
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DBClass_xu.conn;
                    cmd.CommandText = "update ArmsInfo set[Zbid]='" + textBox1.Text + "'" +
                      ",[Zbname]='" + textBox2.Text + "'" +
                      ",[Zbspec]='" + textBox3.Text + "'" +
                      ",[Zbkind]='" + textBox4.Text + "'" +
                      ",[Zbunit]='" + textBox5.Text + "'"+
                      "where[Zbid]='"+ mystr.str + "'";
                    cmd.ExecuteNonQuery();

                    DataSet dsMydataBase = new DataSet();
                    SqlDataAdapter daBaseInform = new SqlDataAdapter("Select*From ArmsInfo", DBClass_xu.conn);
                    daBaseInform.Fill(dsMydataBase, "ArmsInfo");

                    mystr.data.DataSource = dsMydataBase.Tables["ArmsInfo"];
                    MessageBox.Show("成功修改数据");
                    DBClass_xu.conn.Close();
                    Close();
                }

            
            }
            
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + " 打开数据库失败");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
