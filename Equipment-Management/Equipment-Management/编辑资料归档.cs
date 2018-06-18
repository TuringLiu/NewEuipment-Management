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
    public partial class 编辑资料归档 : Form
    {
        public 编辑资料归档()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (mystr.i == 1)
                {
                    if (DBClass_xu.conn.State != ConnectionState.Open)//检查连接状态是否为已连接
                    {
                        DBClass_xu.conn.Open();
                    }

                    
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DBClass_xu.conn;
                    cmd.CommandText = "Insert DataIn(Id,InDate,DataNo,InCount,Usersname,Ryname,Detail,Flag)values('" + textBox1.Text +"','"+System.DateTime.Now.ToString()+"','"+textBox7.Text + "','" + textBox3.Text + "','" + textBox5.Text + "','" + textBox4.Text +"','"+textBox6.Text+"','"+ 0 + "')";
                    cmd.ExecuteNonQuery();
                    
                    DataSet dsMyDataBase = new DataSet();
                    SqlDataAdapter daBaseInform = new SqlDataAdapter("Select*From DataIn", DBClass_xu.conn);
                    daBaseInform.Fill(dsMyDataBase, "DataIn");
                    
                    mystr.data.DataSource = dsMyDataBase.Tables["DataIn"];
                    MessageBox.Show("添加成功");
                    DBClass_xu.conn.Close();
                    Close();


                }
                else if (mystr.i == 2)
                {
                    if (DBClass_xu.conn.State != ConnectionState.Open)//检查连接状态是否为已连接
                    {
                        DBClass_xu.conn.Open();
                    }
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DBClass_xu.conn;
                    cmd.CommandText = "update DataIn set[Id]='" + textBox1.Text + "'" +
                      ",[DataNo]='" + textBox7.Text + "'" +
                      ",[InCount]='" + textBox3.Text + "'" +
                      ",[Usersname]='" + textBox5.Text + "'" +
                      ",[Ryname]='" + textBox4.Text + "'" +
                      ",[Detail]='" + textBox6.Text + "'" +
                      ",[Flag]='" + 0 + "'" +
                      "where[Id]='" + mystr.num + "'";
                    cmd.ExecuteNonQuery();

                    DataSet dsMydataBase = new DataSet();
                    SqlDataAdapter daBaseInform = new SqlDataAdapter("Select*From DataIn", DBClass_xu.conn);
                    daBaseInform.Fill(dsMydataBase, "DataIn");

                    mystr.data.DataSource = dsMydataBase.Tables["DataIn"];
                    MessageBox.Show("成功修改数据");
                    DBClass_xu.conn.Close();
                    Close();
                }


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + " 打开数据库失败");
            }








        }
    }
}
