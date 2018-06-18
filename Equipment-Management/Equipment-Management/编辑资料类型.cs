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
    public partial class 编辑资料类型 : Form
    {
        public 编辑资料类型()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

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
                    cmd.CommandText = "Insert DataTypes(TypeId,TypeName)values('" + textBox1.Text + "','" + textBox2.Text + "')";
                    cmd.ExecuteNonQuery();

                    DataSet dsMyDataBase = new DataSet();
                    SqlDataAdapter daBaseInform = new SqlDataAdapter("Select*From DataTypes", DBClass_xu.conn);
                    daBaseInform.Fill(dsMyDataBase, "DataTypes");

                    mystr.data.DataSource = dsMyDataBase.Tables["DataTypes"];
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
                    cmd.CommandText = "update DataTypes set[TypeId]='" + textBox1.Text + "'" +
                      ",[TypeName]='" + textBox2.Text + "'" +
                      "where[TypeId]='" + mystr.data.CurrentRow.Cells[0].Value + "'";
                    cmd.ExecuteNonQuery();

                    DataSet dsMydataBase = new DataSet();
                    SqlDataAdapter daBaseInform = new SqlDataAdapter("Select*From DataTypes", DBClass_xu.conn);
                    daBaseInform.Fill(dsMydataBase, "DataTypes");

                    mystr.data.DataSource = dsMydataBase.Tables["DataTypes"];
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
