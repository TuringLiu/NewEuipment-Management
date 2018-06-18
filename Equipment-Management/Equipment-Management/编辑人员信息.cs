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
    public partial class 编辑人员信息 : Form
    {
        public 编辑人员信息()
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

                    string strcmd = "select DepId from Departments where DepName='" + mystr.str + "'";
                    cmd.CommandText = strcmd;
                    string save = cmd.ExecuteScalar().ToString();

                    cmd.CommandText = "Insert ArmsPerson(Ryid,Ryname,Sex,Nationaloty,Birth,Title,Rank,Political_Party,Culture_Level,Marital_Condition,Family_Place,Id_Card,Dep_Id,Position,UpperId,Memo)values('" + textBox2.Text + "','" + textBox1.Text + "','" + comboBox1.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Text + "','" + textBox11.Text + "','" + textBox10.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + textBox5.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + int.Parse(save) + "','" + textBox12.Text + "','" + textBox13.Text + "','" + textBox4.Text  +"')";
                                                      //  1     2     3    4           5     6    7           8           9            10                   11         12     13    14        15    16                  1                        2                        3                        4                       5                              6                          7                         8                      9                        10                   11                       12                     13                           14                      15                      16
                    cmd.ExecuteNonQuery();

                    DataSet dsMyDataBase = new DataSet();
                    SqlDataAdapter daBaseInform = new SqlDataAdapter("Select*From ArmsPerson", DBClass_xu.conn);
                    daBaseInform.Fill(dsMyDataBase, "ArmsPerson");

                    mystr.data.DataSource = dsMyDataBase.Tables["ArmsPerson"];
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

                    cmd.CommandText = "update ArmsPerson set[Ryid]='" + textBox2.Text + "'" +
                      ",[Ryname]='" + textBox1.Text + "'" +
                      ",[Sex]='" + comboBox1.Text + "'" +
                      ",[Nationaloty]='" + textBox3.Text + "'" +
                      ",[Birth]='" + dateTimePicker1.Text + "'" +
                      ",[Title]='" + textBox11.Text + "'" +
                      ",[Rank]='" + textBox10.Text + "'" +
                      ",[Political_Party]='" + comboBox2.Text + "'" +
                      ",[Culture_Level]='" + comboBox3.Text + "'" +
                      ",[Marital_Condition]='" + textBox5.Text + "'" +
                      ",[Family_Place]='" + textBox8.Text + "'" +
                      ",[Id_Card]='" + textBox9.Text + "'" +
                      ",[Dep_Id]='" + mystr.str2 + "'" +
                      ",[Position]='" + textBox12.Text + "'" +
                      ",[UpperId]='" + textBox13.Text + "'" +
                      ",[Memo]='" + textBox4.Text + "'" +
                      "where[Ryid]='" + mystr.str + "'";
                    cmd.ExecuteNonQuery();

                    DataSet dsMydataBase = new DataSet();
                    SqlDataAdapter daBaseInform = new SqlDataAdapter("Select*From ArmsPerson", DBClass_xu.conn);
                    daBaseInform.Fill(dsMydataBase, "ArmsPerson");

                    mystr.data.DataSource = dsMydataBase.Tables["ArmsPerson"];
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

        private void 编辑人员信息_Load(object sender, EventArgs e)
        {
            label17.Text = mystr.str2;
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}
