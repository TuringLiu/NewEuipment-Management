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
    public partial class 编辑资料信息 : Form
    {
        public 编辑资料信息()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void 编辑资料信息_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“equipment_Management_Information_SystemDataSet11.DataTypes”中。您可以根据需要移动或删除它。
            this.dataTypesTableAdapter.Fill(this.equipment_Management_Information_SystemDataSet11.DataTypes);

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

                    string  strcmd = "select TypeId from DataTypes where TypeName='" + comboBox1.Text+ "'";
                    cmd.CommandText = strcmd;
                    string  save = cmd.ExecuteScalar().ToString();
                    
                    cmd.CommandText = "Insert ArmsData(DataNo,DataName,TypeId,ICount,IPrice,Memo,GreateDate)values('" + 
                        textBox1.Text + "','" +
                        textBox2.Text + "','" + 
                        int.Parse(save) + "','" + 
                        textBox3.Text + "','" + 
                        textBox4.Text + "','"+
                        textBox5.Text+"','"+
                        System.DateTime.Now.ToString()+"')";
                    cmd.ExecuteNonQuery();

                    DataSet dsMyDataBase = new DataSet();
                    SqlDataAdapter daBaseInform = new SqlDataAdapter("Select*From ArmsData", DBClass_xu.conn);
                    daBaseInform.Fill(dsMyDataBase, "ArmsData");

                    mystr.data.DataSource = dsMyDataBase.Tables["ArmsData"];
                    MessageBox.Show("添加成功");
                    DBClass_xu.conn.Close();
                    Close();


                }
                else if (mystr.i == 2)
                {
                    mystr.str = mystr.data.CurrentRow.Cells[0].Value.ToString();
                    if (DBClass_xu.conn.State != ConnectionState.Open)//检查连接状态是否为已连接
                    {
                        DBClass_xu.conn.Open();
                    }
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = DBClass_xu.conn;

                    string strcmd = "select TypeId from DataTypes where TypeName='" + comboBox1.Text + "'";
                    cmd.CommandText = strcmd;
                    string save = cmd.ExecuteScalar().ToString();

                    cmd.CommandText = "update ArmsData set[DataNo]='" + textBox1.Text + "'" +
                      ",[DataName]='" + textBox2.Text + "'" +
                      ",[TypeId]='" + int.Parse(save) + "'" +
                      ",[ICount]='" + textBox3.Text + "'" +
                      ",[IPrice]='" + textBox4.Text + "'" +
                      ",[Memo]='" + textBox5.Text + "'" +
                      ",[GreateDate]='" + System.DateTime.Now.ToString() + "'" +
                      "where[DataNo]='" + mystr.str + "'";
                    cmd.ExecuteNonQuery();

                    DataSet dsMydataBase = new DataSet();
                    SqlDataAdapter daBaseInform = new SqlDataAdapter("Select*From ArmsData", DBClass_xu.conn);
                    daBaseInform.Fill(dsMydataBase, "ArmsData");

                    mystr.data.DataSource = dsMydataBase.Tables["ArmsData"];
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
