using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Equipment_Management
{
    public partial class 部门人员详细信息窗口 : Form
    {
        public int id;  // 成员id值
        public 部门人员详细信息窗口()
        {
            InitializeComponent();
        }

        // 重载构造函数
        public 部门人员详细信息窗口(int Id)
        {
            InitializeComponent();
            int id = Id;

            string conStr = "Data Source = VCC-PC; Initial Catalog = master; Integrated Security = SSPI";
            SqlConnection conn = new SqlConnection(conStr);
            try
            {
                conn.Open();
                //MessageBox.Show("打开数据库成功！");
                SqlCommand command = new SqlCommand("select * from ArmsPerson where Ryid = " + "'" + id.ToString() + "'", conn);  // 在departments表中查找
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())       // 填充信息
                {
                    部门人员详细信息姓名.Text = reader["Ryname"].ToString();
                    部门人员详细信息人员编号.Text = reader["Ryid"].ToString();
                    部门人员详细信息性别.Text = reader["Sex"].ToString();
                    部门人员详细信息民族.Text = reader["Nationaloty"].ToString();
                    部门人员详细信息生日.Text = reader["Birth"].ToString();
                    部门人员详细信息职务.Text = reader["Title"].ToString();
                    部门人员详细信息军衔.Text = reader["Rank"].ToString();
                    部门人员详细信息政治面貌.Text = reader["Political_Party"].ToString();
                    部门人员详细信息文化程度.Text = reader["Culture_Level"].ToString();
                    部门人员详细信息婚姻状况.Text = reader["Marital_Condition"].ToString();
                    部门人员详细信息籍贯.Text = reader["Family_Place"].ToString();
                    部门人员详细信息身份证号.Text = reader["Id_Card"].ToString();
                    部门人员详细信息所在部门编号.Text = reader["Dep_Id"].ToString();
                    部门人员详细信息工作岗位.Text = reader["Position"].ToString();
                    部门人员详细信息部门领导编号.Text = reader["UpperId"].ToString();

                    // 加载照片
                    string pic;
                    if (reader["photo"] != System.DBNull.Value)
                    {
                        pic = (string)reader["photo"];
                        byte[] imageBytes = Convert.FromBase64String(pic);
                        MemoryStream memoryStream = new MemoryStream(imageBytes);
                        // 转成图片
                        Image image = Image.FromStream(memoryStream);
                        部门人员详细信息照片.Image = image;
                    }
                   // else MessageBox.Show("您好！");
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
     

        }

        private void 部门人员详细信息窗口_Load(object sender, EventArgs e)
        {
            //label1.Text = id.ToString();
        }

    }
}
