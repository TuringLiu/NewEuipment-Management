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
    public partial class 出库信息管理添加 : Form
    {
        public static class DBClass
        {
            public static String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608";
            public static SqlConnection conn = new SqlConnection(strConn);

        }
        public 出库信息管理添加()
        {
            InitializeComponent();
        }

        private void 出库信息管理添加_Load(object sender, EventArgs e)
        {
            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);

            conn.Open();

            //conn.Open();
            DataSet dsMyDataBase = new DataSet();
            SqlDataAdapter daBaseInform = new SqlDataAdapter("Select [Zbid],[Zbprice],[Zbnum],[MakeDate],[Sid] From ArmsSurplus", conn);
            daBaseInform.Fill(dsMyDataBase, "ArmsSurplus");

            dateGridView出库信息管理添加库存装备信息.DataSource = dsMyDataBase.Tables["ArmsSurplus"];
            dateGridView出库信息管理添加库存装备信息.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;



            SqlCommand cmd = new SqlCommand();
            SqlCommand cmd2 = new SqlCommand();
            SqlCommand cmd3 = new SqlCommand();
            cmd.Connection = conn;
            cmd2.Connection = conn;
            string s_cmd = "select distinct Zbid from ArmsSurplus";
            string s_cmd2 = "select distinct Sid from Storehouse";
            string s_cmd3 = "select Zbnum from ArmsSurplus";
            cmd.CommandText = s_cmd;
            cmd2.CommandText = s_cmd2;
            cmd3.CommandText = s_cmd3;
            SqlDataReader reader1 = cmd.ExecuteReader();
            while (reader1.Read())
            {
                出库管理添加装备编号.Items.Add(reader1[0].ToString());
            }
            reader1.Close();
            SqlDataReader reader2 = cmd2.ExecuteReader();

            while (reader2.Read())
            {
                出库管理添加仓库编号.Items.Add(reader2[0].ToString());
            }

            reader2.Close();
            DateTime DT = System.DateTime.Now;
            string riqi = System.DateTime.Now.ToString("yyyyMMdd");
            出库管理添加装备价格.Text = "";
            出库管理添加库存数量.Text = "";
            出库管理添加出库日期.Text = riqi;


            SqlDataAdapter sda = new SqlDataAdapter("select Zbnum from ArmsSurplus", conn);
            SqlDataReader reader3 = cmd.ExecuteReader();
            int i = 0;
            while (reader3.Read())
            {
                cmd.CommandText = string.Format("delete from ArmsSurplus where Zbnum = '" + i + "'", conn);               
            }
            reader3.Close();

            conn.Close();
        }

        private void 出库管理添加装备类别_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*出库管理添加装备名称.Items.Clear();
            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);
            string s = 出库管理添加装备编号.SelectedItem.ToString();

            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            string s_cmd = string.Format("select Zbname from ArmsInfo where Zbkind=\'{0}'", s);

            cmd.CommandText = s_cmd;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                出库管理添加装备名称.Items.Add(reader[0].ToString());
            }
            reader.Close();
            conn.Close();*/
        }

        private void 出库信息管理添加添加_Click(object sender, EventArgs e)
        {
            bool i = true;
            DBClass.conn.Open();

            //异常处理
            while (i)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBClass.conn;
                

                if (出库管理添加装备编号.Text == ""||出库管理添加仓库编号.Text==""||
                    出库管理添加出库类型.Text==""||出库管理添加库存数量.Text==""||
                    出库管理添加批准人.Text=="")
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
                        string ZBbianhao = 出库管理添加装备编号.Text;
                        //string s = 出库管理添加装备名称.Text;
                        //string s_cmd = string.Format("SELECT Zbid  FROM ArmsInfo WHERE Zbname = '{0}'", s);
                        //string ZBbianhao = null;
                        DateTime DT = System.DateTime.Now;
                        string CKbianhao = System.DateTime.Now.ToString().Replace("/", "").Replace(" ", "").Replace(":", "");
                        string CKbianhaogai = CKbianhao.Substring(4, 8);
                        string CKshijian = System.DateTime.Now.ToString("yyyyMMdd");
                       /* SqlCommand cmd2 = new SqlCommand(s_cmd, DBClass.conn);
                        SqlDataReader dr = cmd2.ExecuteReader();
                        while (dr.Read())
                        {
                            ZBbianhao = dr[0].ToString();
                        }
                        dr.Close();*/
                        cmd.CommandText = "insert into Takeout( ToId,Zbid,Ttype,Zbprice,Zbnum,Sid ,Ryname1,Ryname,OptDate)values('"
                             //+ 入库添加装备类别.Text + "','"
                             //+ 入库添加装备名称.Text + "','"
                             + CKbianhaogai + "','"
                             + ZBbianhao + "','"
                             + 出库管理添加出库类型.Text + "','"
                             + 出库管理添加装备价格.Text + "','"
                             + 出库管理添加出库数量.Text + "','"
                             + 出库管理添加仓库编号.Text + "','"
                             //+ 入库添加总价格.Text + "','"   //未添加并且未计算
                             //+ 出库管理添加备注.Text + "','"
                             + 出库管理添加批准人.Text + "','"
                             + 出库管理添加经办人.Text + "','"
                             + CKshijian + "')";
                        cmd.ExecuteNonQuery();
                        string ckbianhao=dateGridView出库信息管理添加库存装备信息.SelectedRows[0].Cells[4].Value.ToString();
                        string zbbianhao= dateGridView出库信息管理添加库存装备信息.SelectedRows[0].Cells[0].Value.ToString();
                        string zbprice= dateGridView出库信息管理添加库存装备信息.SelectedRows[0].Cells[1].Value.ToString();
                        string CKshuliang = 出库管理添加出库数量.Text;
                        cmd.CommandText = string.Format("update ArmsSurplus set Zbnum=Zbnum-{0} where Sid={1} and Zbid={2} and Zbprice={3}" , CKshuliang, ckbianhao,zbbianhao,zbprice);
                        cmd.ExecuteNonQuery();

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

        private void 出库管理添加装备类别_SelectionChangeCommitted(object sender, EventArgs e)
        {
            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);
            string ZBbianhao = 出库管理添加装备编号.SelectedItem.ToString();
            /* string s_cmd = string.Format("SELECT Zbid  FROM ArmsInfo WHERE Zbname = '{0}'", s);
             string ZBbianhao = null;
             SqlCommand cmd2 = new SqlCommand(s_cmd, DBClass.conn);
             SqlDataReader dr = cmd2.ExecuteReader();
             while (dr.Read())
             {
                 ZBbianhao = dr[0].ToString();
             }
             dr.Close();*/

            //string b = 出库管理添加装备名称.SelectedItem.ToString();
            string c_cmd = null;


            try
            {
                conn.Open();
                DataSet dsMyDataBase = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                if(出库管理添加仓库编号.Text.Trim()!="")
                {
                    string c = 出库管理添加仓库编号.SelectedItem.ToString();
                    c_cmd = string.Format("select [Zbid],[Zbprice],[Zbnum],[MakeDate],[Sid] from ArmsSurplus where Zbid like '%{0}%'and Sid like '%{1}%'", ZBbianhao, c);
                }
                else
                {
                    c_cmd = string.Format("select [Zbid],[Zbprice],[Zbnum],[MakeDate],[Sid] from ArmsSurplus where Zbid like '%{0}%'", ZBbianhao);
                }
                //string c_cmd = string.Format("select * from ArmsSurplus where Zbid like '%{0}%'and Sid like '%{1}%'", ZBbianhao,c);
                //c_cmd = string.Format("select * from ArmsSurplus where Zbid like '%{0}%'", ZBbianhao);

                cmd = new SqlCommand(c_cmd, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dateGridView出库信息管理添加库存装备信息.DataSource = ds.Tables[0];
                /*SqlDataAdapter daBaseInform = new SqlDataAdapter("Select MakeDate From Storeln where MakeDate= '"+ s_cmd +"'",conn);
                daBaseInform.Fill(dsMyDataBase, "Storeln");

                dataGridView入库信息管理添加.DataSource = dsMyDataBase.Tables["Storeln"];
                dataGridView入库信息管理添加.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;*/

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败");
            }
        }

        private void 出库管理添加仓库编号_SelectionChangeCommitted(object sender, EventArgs e)
        {
            String strConn = "Data Source=DESKTOP-5MJOVVC;Initial Catalog=Equipment Management Information System;uid=zhangli;pwd=201608"; ;
            SqlConnection conn = new SqlConnection(strConn);
            string CKbianhao = 出库管理添加仓库编号.SelectedItem.ToString();
            /* string s_cmd = string.Format("SELECT Zbid  FROM ArmsInfo WHERE Zbname = '{0}'", s);
             string ZBbianhao = null;
             SqlCommand cmd2 = new SqlCommand(s_cmd, DBClass.conn);
             SqlDataReader dr = cmd2.ExecuteReader();
             while (dr.Read())
             {
                 ZBbianhao = dr[0].ToString();
             }
             dr.Close();*/

            //string b = 出库管理添加装备名称.SelectedItem.ToString();
            string c_cmd = null;


            try
            {
                conn.Open();
                DataSet dsMyDataBase = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                if (出库管理添加装备编号.Text.Trim() != "")
                {
                    string ZBbianhao = 出库管理添加装备编号.SelectedItem.ToString();
                    c_cmd = string.Format("select [Zbid],[Zbprice],[Zbnum],[MakeDate],[Sid] from ArmsSurplus where Zbid like '%{0}%'and Sid like '%{1}%'", ZBbianhao, CKbianhao);
                }
                else
                {
                    c_cmd = string.Format("select [Zbid],[Zbprice],[Zbnum],[MakeDate],[Sid] from ArmsSurplus where Sid like '%{0}%'", CKbianhao);
                }
                //string c_cmd = string.Format("select * from ArmsSurplus where Zbid like '%{0}%'and Sid like '%{1}%'", ZBbianhao,c);
                //c_cmd = string.Format("select * from ArmsSurplus where Zbid like '%{0}%'", ZBbianhao);

                cmd = new SqlCommand(c_cmd, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dateGridView出库信息管理添加库存装备信息.DataSource = ds.Tables[0];
                /*SqlDataAdapter daBaseInform = new SqlDataAdapter("Select MakeDate From Storeln where MakeDate= '"+ s_cmd +"'",conn);
                daBaseInform.Fill(dsMyDataBase, "Storeln");

                dataGridView入库信息管理添加.DataSource = dsMyDataBase.Tables["Storeln"];
                dataGridView入库信息管理添加.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;*/

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "打开数据库失败");
            }
        }

        private void dateGridView出库信息管理添加库存装备信息_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
            /*if (this.dateGridView出库信息管理添加库存装备信息.SelectedRows.Count!=0)
            {
                this.出库管理添加装备价格.Text = dateGridView出库信息管理添加库存装备信息.SelectedRows[0].Cells[2].Value.ToString();
                this.出库管理添加库存数量.Text = dateGridView出库信息管理添加库存装备信息.SelectedRows[0].Cells[3].Value.ToString();
                
            }*/
        }

        private void dateGridView出库信息管理添加库存装备信息_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (this.dateGridView出库信息管理添加库存装备信息.SelectedRows.Count != 0)
            {
                this.出库管理添加装备价格.Text = dateGridView出库信息管理添加库存装备信息.SelectedRows[0].Cells[1].Value.ToString();
                this.出库管理添加库存数量.Text = dateGridView出库信息管理添加库存装备信息.SelectedRows[0].Cells[2].Value.ToString();
                this.出库管理添加仓库编号.Text = dateGridView出库信息管理添加库存装备信息.SelectedRows[0].Cells[4].Value.ToString();
                this.出库管理添加装备编号.Text = dateGridView出库信息管理添加库存装备信息.SelectedRows[0].Cells[0].Value.ToString();

            }
        }

        private void 出库信息管理添加取消_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
