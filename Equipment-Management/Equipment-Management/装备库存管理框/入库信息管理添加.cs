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
    public partial class 入库信息管理添加 : Form
    {
        public static class DBClass
        {
            public static String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608";
            public static SqlConnection conn = new SqlConnection(strConn);

        }
        public 入库信息管理添加()
        {
            InitializeComponent();
        }

        private void 入库信息管理添加添加_Click(object sender, EventArgs e)
        {
            bool i = true;
            DBClass.conn.Open();

            //异常处理
            while (i)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBClass.conn;
                
                if (入库添加装备类别.Text == "" || 入库添加装备价格.Text == "" || 入库添加装备数量.Text == ""
                    ||入库添加入库类型.Text==""||入库添加生产日期.Text==""
                    ||入库添加仓库编号.Text==""||入库添加装备名称.Text==""||入库添加验收人.Text=="")
                {
                    MessageBox.Show("请完善添加信息！");
                    this.Show();
                    DBClass.conn.Close();
                    break;
                }
                else
                {
                    try
                    {
                        string s = 入库添加装备名称.Text;
                        string s_cmd = string.Format("SELECT Zbid  FROM ArmsInfo WHERE Zbname = '{0}'",s);
                        string ZBbianhao=null;
                        DateTime DT = System.DateTime.Now;
                        string RKbianhao = System.DateTime.Now.ToString().Replace("/","").Replace(" ","").Replace(":","");
                        string RKbianhaogai = RKbianhao.Substring(4,8);
                        string RKshijian = System.DateTime.Now.ToString("yyyyMMdd");
                        SqlCommand cmd2 = new SqlCommand(s_cmd, DBClass.conn);
                        SqlDataReader dr = cmd2.ExecuteReader();
                        while(dr.Read())
                        {
                            ZBbianhao = dr[0].ToString();
                        }
                        dr.Close();
                        
                        cmd.CommandText = "insert into Storeln( SiId,Zbid,SiType,Zbprice,Zbnum,MakeDate,Sid ,Memo,Ryname1,Ryname,OptDate)values('"
                             //+ 入库添加装备类别.Text + "','"
                             //+ 入库添加装备名称.Text + "','"
                             + RKbianhaogai + "','"
                             + ZBbianhao + "','"
                             + 入库添加入库类型.Text + "','"
                             + 入库添加装备价格.Text + "','"
                             + 入库添加装备数量.Text + "','"
                             + 入库添加生产日期.Text + "','"
                             + 入库添加仓库编号.Text + "','"
                             //+ 入库添加总价格.Text + "','"   //未添加并且未计算
                             + 入库添加备注.Text + "','"
                             + 入库添加验收人.Text + "','"
                             + 入库添加经办人.Text + "','"
                             + RKshijian + "')";
                        cmd.ExecuteNonQuery();

                        
                        //存入库存装备信息表
                        string s_mycmd1 = string.Format("select Sid from ArmsSurplus where Sid={0} and Zbid ={1} and Zbprice={2}", 入库添加仓库编号.Text, ZBbianhao, 入库添加装备价格.Text);
                        SqlCommand mycmd1 = new SqlCommand(s_mycmd1,DBClass.conn);
                        SqlDataReader mysdr1 = mycmd1.ExecuteReader();
                        if (mysdr1.HasRows)
                        {
                            mycmd1.CommandText =string.Format("update ArmsSurplus set Zbnum=Zbnum+{0}  where Sid={1} and Zbid={2} and Zbprice={3}", 入库添加装备数量.Text,入库添加仓库编号.Text, ZBbianhao, 入库添加装备价格.Text);
                            mysdr1.Close();
                            mycmd1.ExecuteNonQuery();
                        }
                        else
                        {
                            string KCZBbianhao = System.DateTime.Now.ToString().Replace("/", "").Replace(" ", "").Replace(":", "");
                            string KCZBbianhaogai = KCZBbianhao.Substring(4, 8);
                            cmd.CommandText = "insert into ArmsSurplus(SpId,Zbid,Zbprice,Zbnum,MakeDate,Sid,Memo)values('" + KCZBbianhaogai + "','"
                                + ZBbianhao + "','"
                                + 入库添加装备价格.Text + "','"
                                + 入库添加装备数量.Text + "','"
                                + 入库添加生产日期.Text + "','"
                                + 入库添加仓库编号.Text + "','"
                                + 入库添加备注.Text + "')";
                            mysdr1.Close();
                            cmd.ExecuteNonQuery();
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString() + "执行失败");
                    }
                    DBClass.conn.Close();
                    this.Close();
                    break;
                }
            }
        }

        private void 入库信息管理添加_Load(object sender, EventArgs e)
        {
            
            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);

            conn.Open();
            SqlCommand cmd = new SqlCommand();
            SqlCommand cmd2 = new SqlCommand();
            SqlCommand cmd3 = new SqlCommand();
            cmd.Connection = conn;
            cmd2.Connection = conn;
            string s_cmd = "select distinct Zbkind from ArmsInfo";
            string s_cmd2 = "select distinct Sid from Storehouse";
            //string s_cmd3=""
            cmd.CommandText = s_cmd;
            cmd2.CommandText = s_cmd2;
            SqlDataReader reader1 = cmd.ExecuteReader();
            while (reader1.Read())
            {              
                入库添加装备类别.Items.Add(reader1[0].ToString());
            }
            reader1.Close();
            SqlDataReader reader2 = cmd2.ExecuteReader();
            
            while(reader2.Read())
            {
                入库添加仓库编号.Items.Add(reader2[0].ToString());
            }
            
            reader2.Close();
            conn.Close();

        }

        private void 入库添加装备类别_SelectedIndexChanged(object sender, EventArgs e)
        {
            入库添加装备名称.Items.Clear();
            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);
            string s = 入库添加装备类别.SelectedItem.ToString();

            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            string s_cmd = string.Format("select Zbname from ArmsInfo where Zbkind=\'{0}'", s);

            cmd.CommandText = s_cmd;
            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                入库添加装备名称.Items.Add(reader[0]. ToString());
            }
            reader.Close();
            conn.Close();
        }

        private void 入库信息管理添加取消_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
